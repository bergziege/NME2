using Com.QueoMedia.Updater.Utilities;
using NME2.Domain;

namespace NME2.Service.Implementation
{
    class SettingsService:ISettingsService
    {
        private UserSettings _settings;

        public SettingsService(){}

        #region Implementation of ISettingsService

        ///<summary>
        /// Load settings from settings file
        ///</summary>
        public void LoadSettings()
        {
            if (UsedSettingsFile == string.Empty)
            {
                // wenn noch keine datei angelegt wurde, diese hier initial erzeugen.
                _settings = new UserSettings {Interval = 60, ServerPath = "", SimObjectsPath = "", Username = ""};
                UsedSettingsFile = "init.xml";
                SaveSettings();
            }
            _settings = DeSerializer.Deserializer<UserSettings>(UsedSettingsFile);
        }

        ///<summary>
        /// Save settings to setting file
        ///</summary>
        public void SaveSettings()
        {
            DeSerializer.Serialize(_settings, UsedSettingsFile);
            Properties.Settings.Default.Save();
        }

        ///<summary>
        /// Currently used settings file
        ///</summary>
        public string UsedSettingsFile
        {
            get { return Properties.Settings.Default.LastUsedServerFile; }
            set { Properties.Settings.Default.LastUsedServerFile = value; }
        }

        /// <summary>
        /// Current Settings or null
        /// </summary>
        public UserSettings CurrentSettings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        #endregion
    }
}
