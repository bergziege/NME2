using NME2_Server_Manager.Nme2Ws;

namespace NME2_Server_Manager.Dto {
    class MissionObjectDto {

        private MissionObject _missionObject;

        public MissionObjectDto(Mission adjectedMission, bool test = true)
        {
            _missionObject = new MissionObject(){Mission = adjectedMission, Mission_Id = adjectedMission.Id, SimObject_Id = 1};
        }

        public MissionObjectDto(MissionObject missionObject) {
            _missionObject = missionObject;
        }

        public string Heading {
            get { return _missionObject.Heading.ToString(); }
            set { _missionObject.Heading = int.Parse(value); }
        }

        public string Lat {
            get { return _missionObject.Lat.ToString(); }
            set { _missionObject.Lat = double.Parse(value); }
        }

        public string Lon {
            get { return _missionObject.Lon.ToString(); }
            set { _missionObject.Lon = double.Parse(value); }
        }

        public MissionObject MissionObject {
            get { return this._missionObject; }
            set { this._missionObject = value; }
        }

        public string Name {
            get { return _missionObject.Simobject == null ? "No Simobject": _missionObject.Simobject.Name; }
        }

        public int Active {
            get { return _missionObject.Active; }
            set { _missionObject.Active = value; }
        }
    }
}
