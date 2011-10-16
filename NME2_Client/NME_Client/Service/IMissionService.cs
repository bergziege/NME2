using System;
using System.Collections.Generic;
using NME2.Domain.Dto;

namespace NME2.Service
{
    public interface IMissionService
    {
        event EventHandler RequestTimerStop;
        event EventHandler RequestTimerStart;

        void FuncCheckMissions(double lat, double lon);
        IList<MissionDto> GetMissionsForDisplay();

        string ServerUrl { set; }
    }
}