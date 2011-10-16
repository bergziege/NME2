using System;
using NME2.Nme2Ws;

namespace NME2.Domain
{
    [Serializable]
    public class LocalCustomObject
    {
        private int _id;
        private string _version;
        private string _downloadPath;
        private string _description;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public string DownloadPath
        {
            get { return _downloadPath; }
            set { _downloadPath = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public LocalCustomObject(){}

        public LocalCustomObject(CustomObject customObject)
        {
            _id = customObject.Id;
            _version = customObject.Version;
            _downloadPath = customObject.DownloadPath;
            _description = customObject.Description;
        }
    }
}
