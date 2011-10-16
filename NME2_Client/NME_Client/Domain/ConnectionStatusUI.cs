using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using NME2.Properties;

namespace NME2.Domain
{
    public class ConnectionStatusUi
    {
        private readonly ConnectionStatus _connectionStatus;

        public ConnectionStatusUi(ConnectionStatus connectionStatus)
        {
            _connectionStatus = connectionStatus;
        }

        public Color ConnectionStatusColor { get { return ConnectionStateToColor(); } }

        public string AvailableOperation { get { return GetAvailableOperationAsString(); } }

        private string GetAvailableOperationAsString()
        {
            switch (_connectionStatus)
            {
                case ConnectionStatus.Connected:
                    return "Disconnect";
                case ConnectionStatus.Disconnected:
                    return "Connect";
                case ConnectionStatus.Pending:
                    return "Reconnect";
                default:
                    return "-";
            }
        }

        public override string ToString()
        {
            return ConnectionStateToString();
        }


        private string ConnectionStateToString()
        {
            switch (_connectionStatus)
            {
                case ConnectionStatus.Connected:
                    return Resources.MainView_SimConnectStatus_Connected;
                case ConnectionStatus.Disconnected:
                    return Resources.MainView_SimConnectStatus_Disconnected;
                case ConnectionStatus.Pending:
                    return "Unbekannt";
                default:
                    return "-";
            }
        }

        private Color ConnectionStateToColor()
        {
            switch (_connectionStatus)
            {
                case ConnectionStatus.Connected:
                    return Color.Green;
                case ConnectionStatus.Disconnected:
                    return Color.Red;
                case ConnectionStatus.Pending:
                    return Color.Yellow;
                default:
                    return Color.Gray;
            }
        }
    }
}
