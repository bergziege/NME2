using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NME2_Server_Manager.Nme2WsAdmin;

namespace NME2_Server_Manager.Converter
{
    class MissionConverter
    {
        public static Nme2WsAdmin.Mission MissionToAdmin(Nme2Ws.Mission nonAdminObject)
        {
            return new Mission(){Active = nonAdminObject.Active, CenterLat = nonAdminObject.CenterLat,
            CenterLon = nonAdminObject.CenterLon,Id = nonAdminObject.Id,Name = nonAdminObject.Name,
            MissionRange = nonAdminObject.MissionRange, Version = nonAdminObject.Version};
        }

        public static Nme2Ws.Mission AdminToMission(Nme2WsAdmin.Mission adminObject)
        {
            return new Nme2Ws.Mission(){Active = adminObject.Active, CenterLat = adminObject.CenterLat,
            CenterLon = adminObject.CenterLon, Id = adminObject.Id, MissionRange = adminObject.MissionRange,
            Name = adminObject.Name, Version = adminObject.Version};
        }
    }
}
