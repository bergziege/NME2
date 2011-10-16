using System;
using System.Collections.Generic;
using NME2.Nme2Ws;

namespace NME2.Domain
{
    [Serializable]
    public class CustomObjectCatalog
    {
        private DateTime _lastUpdated;
        private List<LocalCustomObject> _customObjects;

        public DateTime LastUpdated
        {
            get { return _lastUpdated; }
            set { _lastUpdated = value; }
        }

        public List<LocalCustomObject> CustomObjects
        {
            get { return _customObjects; }
            set { _customObjects = value; }
        }

        public CustomObjectCatalog(){}

        public CustomObjectCatalog(IEnumerable<CustomObject> customObjectsFromWeb)
        {
            _customObjects = new List<LocalCustomObject>();
            _lastUpdated = DateTime.Now;
            foreach (CustomObject customObject in customObjectsFromWeb)
            {
                _customObjects.Add(new LocalCustomObject(customObject));
            }
        }
    }
}
