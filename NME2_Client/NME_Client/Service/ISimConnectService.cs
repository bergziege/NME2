using System;
using NME2.Domain;
using NME2.Domain.SimConnect;
using Microsoft.FlightSimulator.SimConnect;
using NME2.Service.Event;

namespace NME2.Service
{
    public interface ISimConnectService
    {
        void Connect();
        void Disconnect();

        void ToggleConnection();

        ConnectionStatus ConnectionStatus { get; }

        void ListenToMessage();

        void AiCreateSimulatedObject(string objectName, SIMCONNECT_DATA_INITPOSITION init, int reqId); // RequestId.ObjectBase +

        void AiRemoveObject(UInt32 simObject, int enumOffset);

        void RequestDataFromFs();

        event EventHandler SimconnectDisconnected;

        event EventHandler SimconnectConnected;

        event CheckMissionsHandler RequestCheckMIssions;

        event ObjectIdArrived ObjectIdArrived;
    }
}