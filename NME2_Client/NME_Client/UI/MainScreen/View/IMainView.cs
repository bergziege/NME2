using System;
using System.Collections.Generic;
using Microsoft.FlightSimulator.SimConnect;
using NME2.BasicInterfaces;
using NME2.Domain;
using NME2.Domain.Dto;

namespace NME2.UI.MainScreen.View
{
    /// <summary>
    /// Schnittstelle für die Hauptansicht NME2 Client
    /// </summary>
    public interface IMainView: IBaseView
    {
        /// <summary>
        /// Fordert den "Über" Dialog
        /// </summary>
        event EventHandler RequestAboutDialog;

        /// <summary>
        /// INformaiert über den Wechsel eines Tab
        /// </summary>
        event EventHandler TabChanged;

        /// <summary>
        /// Fordert das Umschalten des Simconnect Status
        /// </summary>
        event EventHandler RequestToggleFsxConnectionState;

        /// <summary>
        /// Fordert das Synchonisieren der Simobjects
        /// </summary>
        event EventHandler RequestSync;
        
        /// <summary>
        /// Fordert das Rücksetzen der Einstellungen
        /// </summary>
        event EventHandler RequestSettingsReset;

        /// <summary>
        /// Fordert das Abspeichern der Einstellungen
        /// </summary>
        event EventHandler RequestSettingsSave;

        /// <summary>
        /// Fordert das laden der einstellungen.
        /// </summary>
        event EventHandler RequestSettingsLoad;

        /// <summary>
        /// Fordert das Herstellen einer Verbindung
        /// </summary>
        event EventHandler RequestFsxConnect;

        /// <summary>
        /// Fordert das Unterbrechen einer Verbindung
        /// </summary>
        event EventHandler RequestFscDisconnect;

        /// <summary>
        /// Informiert über das Eintreffen einer neuen Nachricht.
        /// </summary>
        event EventHandler NewMessageArrived;

        /// <summary>
        /// Status der Simconnect Verbindung als Text
        /// </summary>
        ConnectionStatusUi FsxConnectionStatus { set; }

        /// <summary>
        /// Pfad zur aktuellen server settings datei
        /// </summary>
        string ServerFilePath { get; set; }

        /// <summary>
        /// URL des NME2 Servers
        /// </summary>
        string ServerUrl { get; set; }

        /// <summary>
        /// Benutzername
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Pfad zu den FSX Simobjects
        /// </summary>
        string FsxSimObjectsPath { get; set; }

        /// <summary>
        /// Reload Interval der Missionen
        /// </summary>
        int RefreshInterval { get; set; }

        /// <summary>
        /// Index der aktuell gewählten Tab Seite
        /// </summary>
        int SelectedTabPage { get; }

        /// <summary>
        /// Liste mit Log Nachrichten
        /// </summary>
        IList<LogMessage> LogMessages { get; set; }

        /// <summary>
        /// Liste mit Missionen
        /// </summary>
        IList<MissionDto> Missions { get; set; }

        /// <summary>
        /// Stellt das Fenster Handle bereit.
        /// </summary>
        IntPtr Handle { get; }

        SimConnect SimConnect{ get; set; }

        void Minimize();
    }
}