using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NME2_Server_Manager.Nme2WsAdmin;

namespace NME2_Server_Manager.Converter
{
    class MissionObjectConverter
    {
        public static Nme2WsAdmin.MissionObject MissionObjectToAdmin(Nme2Ws.MissionObject nonAdminObject)
        {
            return new MissionObject(){Active = nonAdminObject.Active, Altitude = nonAdminObject.Altitude, Bank = nonAdminObject.Bank,
            Heading = nonAdminObject.Heading, Id = nonAdminObject.Id, Lat = nonAdminObject.Lat, Lon = nonAdminObject.Lon,
            Mission_Id = nonAdminObject.Mission_Id, OnGround = nonAdminObject.OnGround, Pitch = nonAdminObject.Pitch,
            SimObject_Id = nonAdminObject.SimObject_Id, Yaw = nonAdminObject.Yaw};
        }
    }
}
