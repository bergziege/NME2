using NME2.Domain;

namespace NME2.Service
{
    ///<summary>
    /// Interface for Settings Service.
    /// Allows to save or load settings and define used settings.
    ///</summary>
    public interface ISettingsService
    {
        ///<summary>
        /// Load settings from settings file
        ///</summary>
        void LoadSettings();

        ///<summary>
        /// Save settings to setting file
        ///</summary>
        void SaveSettings();

        ///<summary>
        /// Currently used settings file
        ///</summary>
        string UsedSettingsFile { get; set; }

        /// <summary>
        /// Current Settings or null
        /// </summary>
        UserSettings CurrentSettings { get; set; }

    }
}