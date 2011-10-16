using System;
using System.Runtime.InteropServices;
using Microsoft.FlightSimulator.SimConnect;
using NME2.Domain;
using NME2.Domain.SimConnect;
using NME2.Properties;
using NME2.Service.Event;

namespace NME2.Service.Implementation
{
    class SimConnectService : ISimConnectService
    {
        #region Private Variablen

        // Declare a SimConnect object 
        SimConnect _mySimconnect;

        // User-defined win32 event
        const int WmUserSimconnect = 0x0402;

        private ConnectionStatus _connectionStatus = ConnectionStatus.Pending;

        private IntPtr _windowHandle;

        #endregion

        #region Öffentliche Methoden

        public SimConnectService(IntPtr windowHandle, SimConnect simConnect)
        {
            _windowHandle = windowHandle;
            _mySimconnect = simConnect;

        }

        #endregion

        #region Ereignisbehandung

        void mySimconnect_OnRecvAssignedObjectId(SimConnect sender, SIMCONNECT_RECV_ASSIGNED_OBJECT_ID data)
        {
            if (ObjectIdArrived != null)
            {
                ObjectIdArrived(data.dwRequestID, data.dwObjectID);
            }
        }

        /*
         * Wenn daten über simconnect empfangen werden
         */
        void simconnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            // auswertung request id
            switch ((DataRequests)data.dwRequestID)
            {
                // wenn req id 1
                case DataRequests.Request_1:
                    StructCoordinates s1 = (StructCoordinates)data.dwData[0];
                    //FuncGetPosition();
                    //FuncCheckMissions();
                    if (RequestCheckMIssions != null)
                    {
                        RequestCheckMIssions(s1.latitude, s1.longitude);
                    }
                    break;
                default:
                    // sonst nummer der unbekannten id in listbox schreiben
                    //funcPrintOut("Unknown request ID: " + data.dwRequestID);
                    break;
            }
        }

        /*
         * Wenn simconnect geschlossen wird
         */
        void simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            // click auf exit button
            if (_mySimconnect == null) return;
            //btnIndicator.BackColor = Color.Red;
            //Text = Resources.MainView_NME2_Disconnected;
            //timeGetPos.Enabled = false;
            _mySimconnect.Dispose();
            _mySimconnect = null;

            if (SimconnectDisconnected != null)
            {
                SimconnectDisconnected(this, EventArgs.Empty);
            }

            //FuncPrintOut(Resources.MainView_LOG_Connection_Closed);
            //btnConnect.Text = Resources.MainView_SimConnectStatus_Connected;
            //_alCurrentMissionIDs.Clear();
            //_alMissions.Clear();
            //_alRemoteMissionIDs.Clear();
        }

        /*
         * Wenn simconnect verbindung erfolgreich hergestellt wurde
         */
        void simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            // ausgabe in listbox

            if (SimconnectConnected != null)
            {
                SimconnectConnected(this, EventArgs.Empty);
            }

            //btnIndicator.BackColor = Color.Green;
            //Text = Resources.MainView_Title_Connected;
            //FuncPrintOut(Resources.MainView_LOG_Connected);
            //FuncPrintOut(data.szApplicationName);
            //timeGetPos.Enabled = true;
            //timeGetPos.Start();
            //btnConnect.Text = Resources.MainView_SimConnectStatus_Disconnected;
        }

        #endregion

        #region Private Methoden



        #endregion

        #region Implementation of ISimConnectService

        public void Connect()
        {
            // Connect to FS
            try
            {
                // neue simconnect verbindung aufbauen

                // event management für open
                _mySimconnect.OnRecvOpen += simconnect_OnRecvOpen;
                // event management für close
                _mySimconnect.OnRecvQuit += simconnect_OnRecvQuit;

                _mySimconnect.OnRecvAssignedObjectId += mySimconnect_OnRecvAssignedObjectId;
                // abfragedaten zur verbindung hinzufügen
                _mySimconnect.AddToDataDefinition(Definitions.StructCoordinates, "Plane Latitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                _mySimconnect.AddToDataDefinition(Definitions.StructCoordinates, "Plane Longitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

                // IMPORTANT: register it with the simconnect managed wrapper marshaller
                // if you skip this step, you will only receive a uint in the .dwData field.
                _mySimconnect.RegisterDataDefineStruct<StructCoordinates>(Definitions.StructCoordinates);

                // catch a simobject data request
                _mySimconnect.OnRecvSimobjectDataBytype += simconnect_OnRecvSimobjectDataBytype;

                _mySimconnect.RequestDataOnSimObjectType(DataRequests.Request_1, Definitions.StructCoordinates, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                _connectionStatus = ConnectionStatus.Connected;
            }
            catch (COMException ex)
            {
                // A connection to the SimConnect server could not be established 
                _connectionStatus = ConnectionStatus.Pending;
                Disconnect();
                throw new Exception(Resources.SimConnection_Error + ex.Message);
            }
        }

        public void Disconnect()
        {
            simconnect_OnRecvQuit(null, null);
            _connectionStatus = ConnectionStatus.Disconnected;
            _mySimconnect.Dispose();
            _mySimconnect = null;
        }

        public void ToggleConnection()
        {
            if (_connectionStatus != ConnectionStatus.Connected)
                Connect();
            else
                Disconnect();
        }

        public ConnectionStatus ConnectionStatus
        {
            get { return _connectionStatus; }
        }

        public void ListenToMessage()
        {
            if (_mySimconnect == null) return;
            _mySimconnect.ReceiveMessage();
        }

        public void AiCreateSimulatedObject(string objectName, SIMCONNECT_DATA_INITPOSITION init, int reqId)
        {
            _mySimconnect.AICreateSimulatedObject(objectName, init, RequestId.ObjectBase + reqId);
        }

        public void AiRemoveObject(UInt32 simObject, int enumOffset)
        {
            _mySimconnect.AIRemoveObject(simObject, RequestId.ObjectBase + enumOffset);
        }

        public void RequestDataFromFs()
        {
            if (_mySimconnect == null) return;
            _mySimconnect.RequestDataOnSimObjectType(DataRequests.Request_1, Definitions.StructCoordinates, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
        }

        public event EventHandler SimconnectDisconnected;
        public event EventHandler SimconnectConnected;
        public event CheckMissionsHandler RequestCheckMIssions;
        public event ObjectIdArrived ObjectIdArrived;

        #endregion
    }
}
