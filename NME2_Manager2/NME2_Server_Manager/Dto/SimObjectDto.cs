using NME2_Server_Manager.Nme2Ws;

namespace NME2_Server_Manager.Dto
{
    class SimObjectDto
    {
        private SimObject _simObject;

        public SimObjectDto(SimObject simObject)
        {
            _simObject = simObject;
        }

        public SimObject SimObject
        {
            get { return _simObject; }
        }

        public override string ToString()
        {
            return _simObject.Name + " - " + _simObject.SimName;
        }
    }
}
