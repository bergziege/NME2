using NME2_Server_Manager.Nme2Ws;

namespace NME2_Server_Manager.Dto {
    class MissionDto {


        private Mission _mission;

        public MissionDto(Mission mission) {
            _mission = mission;
        }

        public string Active {
            get { return _mission.Active.ToString(); }
            set { _mission.Active = int.Parse(value); }
        }

        public Mission Mission {
            get { return this._mission; }
            set { this._mission = value; }
        }

        public string Name {
            get { return _mission.Name; }
            set { _mission.Name = value; }
        }

        public string Range {
            get { return _mission.MissionRange.ToString(); }
            set { _mission.MissionRange = int.Parse(value); }
        }
    }
}
