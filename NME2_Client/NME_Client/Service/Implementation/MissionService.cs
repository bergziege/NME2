using System;
using System.Collections.Generic;
using System.Linq;
using NME2.Dao;
using Microsoft.FlightSimulator.SimConnect;
using NME2.Domain;
using NME2.Domain.Dto;
using NME2.Nme2Ws;

namespace NME2.Service.Implementation
{
    public class MissionService: IMissionService
    {
        private ISimConnectService _simconnectService;
        //private ISettingsService _settingsService;

        IList<SimconnectSimObject> _currentObjectsInSim = new List<SimconnectSimObject>();
        IList<Mission> _localMissions = new List<Mission>();
        IList<Mission> _remoteMissions = new List<Mission>();

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="simconnectService"></param>
        /// <param name="settingsService"></param>
        public MissionService(ISimConnectService simconnectService, ISettingsService settingsService)
        {
            _simconnectService = simconnectService;
            //_settingsService = settingsService;

            _simconnectService.ObjectIdArrived += SimconnectServiceObjectIdArrived;
        }

        /// <summary>
        /// Wenn eine Object Id vom FSX empfangen wurde ...
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="objectId"></param>
        void SimconnectServiceObjectIdArrived(UInt32 requestId, UInt32 objectId)
        {
            _currentObjectsInSim.First(ob => ob.RequestId == requestId).ObjectId = objectId;
        }

        private void FuncShowObjects(Mission[] missionsToShow)
        {
            SIMCONNECT_DATA_INITPOSITION init;

            Nme2Ws.Nme2Ws ws = new Nme2Ws.Nme2Ws();
            IList<MissionObject> objects = ws.MissionObjectServiceGetMissionObjectsForMissions(missionsToShow);

            foreach (MissionObject missionObject in objects)
            {
                init.Airspeed = 0;
                init.Altitude = missionObject.Altitude;
                init.Bank = missionObject.Bank;
                init.Heading = missionObject.Heading;
                init.Latitude = missionObject.Lat;
                init.Longitude = missionObject.Lon;
                init.OnGround = missionObject.OnGround == 0 ? 0 : (uint)1;
                init.Pitch = missionObject.Pitch;

                int reqId = new Random().Next(0,999999);

                _currentObjectsInSim.Add(new SimconnectSimObject(){RequestId = reqId, MissionObject = missionObject});//reqId, missionObject);

                _simconnectService.AiCreateSimulatedObject(missionObject.Simobject.SimName, init, reqId);
            }
        }

        private bool _creatingmissions;

        /// <summary>
        /// Updates the scenery list on the UI
        /// </summary>
        public IList<MissionDto> GetMissionsForDisplay()
        {
            if (_creatingmissions) return null;
            _creatingmissions = true;
            IList<MissionDto> results = _localMissions.Select(mission => new MissionDto() {Name = mission.Name}).ToList();
            _creatingmissions = false;
            return results;
        }

        private void FuncRemoveMissionFromFs(Mission missionToRemove)
        {
            IList<SimconnectSimObject> toDelete = new List<SimconnectSimObject>();

            foreach (SimconnectSimObject simObject in
                _currentObjectsInSim.Where(simObject => simObject.MissionObject.Mission_Id == missionToRemove.Id))
            {
                _simconnectService.AiRemoveObject(simObject.ObjectId, simObject.RequestId);
                toDelete.Add(simObject);
            }

            foreach (SimconnectSimObject simObject in toDelete)
            {
                _currentObjectsInSim.Remove(simObject);
            }
        }

        public void FuncCheckMissions(double lat, double lon)
        {

            if (RequestTimerStop != null)
            {
                RequestTimerStop(this, EventArgs.Empty);
            }
            // Check for missions
            Nme2Ws.Nme2Ws ws = new Nme2Ws.Nme2Ws();
            _remoteMissions = ws.MissionServiceGetMissionsWithin(lat, lon);

            foreach (Mission mission in _remoteMissions)
            {
                bool exists = false;
                foreach (Mission local in _localMissions.Where(local => local.Id == mission.Id))
                {
                    exists = true;
                }
                if (exists)
                {
                    string locVersion = _localMissions.First(m => mission.Id == m.Id).Version;
                    string remVersion = mission.Version;
                    if (locVersion != remVersion)
                    {
                        FuncRemoveMissionFromFs(mission);
                        //FuncBuildMission(mission.Id.ToString());
                        FuncShowObjects(new[]{mission});
                    }
                }
                else
                {
                    //FuncBuildMission(mission.Id.ToString());
                    FuncShowObjects(new[] { mission });
                }
            }

            // Suche Missionen die nicht mehr Remote vorhanden sind und daher local gelöscht werden können.

            IList<Mission> deleteMissions = (from mission in _localMissions
                                             let found = _remoteMissions.Any(remMission => remMission.Id == mission.Id)
                                             where !found
                                             select mission).ToList();

            foreach (Mission toDelete in deleteMissions)
            {
                FuncRemoveMissionFromFs(toDelete);
            }
            deleteMissions.Clear();

            _localMissions = _remoteMissions.ToList();
            
            if (RequestTimerStart != null)
            {
                RequestTimerStart(this, EventArgs.Empty);
            }
        }

        public string ServerUrl
        {
            set { Staticfuncs.Serverpath = value; }
        }

        #region Implementation of IMissionService

        public event EventHandler RequestTimerStop;
        public event EventHandler RequestTimerStart;

        #endregion
    }
}