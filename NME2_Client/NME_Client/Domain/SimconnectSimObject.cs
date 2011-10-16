using NME2.Nme2Ws;

namespace NME2.Domain
{
    class SimconnectSimObject
    {
        private uint _objectId;
        private int _requestId;
        private MissionObject _object;

        public uint ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

        public int RequestId
        {
            get { return _requestId; }
            set { _requestId = value; }
        }

        public MissionObject MissionObject
        {
            get { return _object; }
            set { _object = value; }
        }
    }
}
