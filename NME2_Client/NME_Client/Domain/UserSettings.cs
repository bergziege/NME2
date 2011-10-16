using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NME2.Domain
{
    ///<summary>
    /// User settings
    ///</summary>
    [Serializable]
    public class UserSettings
    {

        private string _psServerPath = "";
        private string _psSimObjectsPath = "";
        private string _psUsername = "";
        private int _interval = 60;

        ///<summary>
        /// Path to NME2 Server
        ///</summary>
        public string ServerPath
        {
            get { return _psServerPath; }
            set { _psServerPath = value; }
        }

        ///<summary>
        /// Path to FSX Simobjects
        ///</summary>
        public string SimObjectsPath
        {
            get { return _psSimObjectsPath; }
            set { _psSimObjectsPath = value; }
        }

        ///<summary>
        /// NME2 username
        ///</summary>
        public string Username
        {
            get { return _psUsername; }
            set { _psUsername = value; }
        }

        ///<summary>
        /// Query interval
        ///</summary>
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }
    }
}
