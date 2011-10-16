using System;
using System.Collections.Generic;
using System.Timers;
using NME2.BasicInterfaces;
using NME2.Dao;
using NME2.Domain;
using NME2.Factory;
using NME2.Properties;
using NME2.Service;
using NME2.Service.Implementation;
using NME2.UI.MainScreen.View;

namespace NME2.UI.MainScreen.Controller.Implementation
{
    ///<summary>
    /// MainView Controller.
    ///</summary>
    public class MainViewController : IMainViewController
    {

        #region Private Variablen

        private Timer _timer;

        private readonly IMainView _attachedView;
        private readonly SynchonisationService _myObjectmanager = new SynchonisationService();

        private IList<LogMessage> _logs = new List<LogMessage>();

        private ISimConnectService _simconnectService;
        private IMissionService _missionService;
        private ISettingsService _settingsService;

        private readonly SynchonisationService _synchonisationService = new SynchonisationService();

        #endregion

        #region Öffentliche Methoden

        ///<summary>
        /// Ctor.
        ///</summary>
        ///<param name="attachedView"></param>
        public MainViewController(IMainView attachedView)
        {

            _settingsService = new SettingsService();
            _settingsService.LoadSettings();

            _attachedView = attachedView;

            _timer = new Timer { Enabled = true, Interval = _settingsService.CurrentSettings.Interval * 1000 };

            _timer.Elapsed += TimerElapsed;

            _attachedView.RequestAboutDialog += AttachedViewRequestAboutDialog;
            _attachedView.RequestSync += AttachedViewRequestSync;
            _attachedView.RequestFsxConnect += AttachedViewRequestFsxConnect;
            _attachedView.RequestFscDisconnect += AttachedViewRequestFscDisconnect;
            _attachedView.RequestToggleFsxConnectionState += AttachedViewRequestToggleFsxConnectionState;
            _attachedView.NewMessageArrived += AttachedViewNewMessageArrived;
            _attachedView.TabChanged += AttachedViewTabChanged;

            _attachedView.RequestSettingsLoad += AttachedViewRequestSettingsLoad;
            _attachedView.RequestSettingsReset += AttachedViewRequestSettingsReset;
            _attachedView.RequestSettingsSave += AttachedViewRequestSettingsSave;

            //// set object manager
            //_synchonisationService.SServerPath = _settingsService.CurrentSettings.ServerPath;
            //_synchonisationService.SSimObjectPath = _settingsService.CurrentSettings.SimObjectsPath;

            // set operator
            Staticfuncs.Serverpath = _settingsService.CurrentSettings.ServerPath;

            InitView();
        }

        void AttachedViewTabChanged(object sender, EventArgs e)
        {
            if (_missionService == null) return;
            if (_attachedView.SelectedTabPage == 1)
            {
                _attachedView.Missions = _missionService.GetMissionsForDisplay();
            }
        }

        #endregion

        #region Ereignisbehandlung

        void AttachedViewRequestSettingsSave(object sender, EventArgs e)
        {
            _settingsService.UsedSettingsFile = _attachedView.ServerFilePath;
            _settingsService.CurrentSettings = GetSettingsFromView();
            _settingsService.SaveSettings();
            if (_missionService != null)
            {
                _missionService.ServerUrl = _settingsService.CurrentSettings.ServerPath;
            }
            _timer.Interval = _settingsService.CurrentSettings.Interval * 1000;

            Settings.Default.CustomSimObjectPath = _settingsService.CurrentSettings.SimObjectsPath;
            Settings.Default.Save();
        }

        void AttachedViewRequestSettingsReset(object sender, EventArgs e)
        {
            InitView();
        }

        void AttachedViewRequestSettingsLoad(object sender, EventArgs e)
        {
            _settingsService.UsedSettingsFile = _attachedView.ServerFilePath;
            _settingsService.LoadSettings();
            InitView();
        }

        void AttachedViewNewMessageArrived(object sender, EventArgs e)
        {
            if (_simconnectService == null) return;
            _simconnectService.ListenToMessage();
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_simconnectService == null) return;
            _simconnectService.RequestDataFromFs();

            if (_missionService == null) return;
            _attachedView.Missions = _missionService.GetMissionsForDisplay();
        }

        void MissionServiceRequestTimerStop(object sender, EventArgs e)
        {
            _timer.Stop();
        }

        void MissionServiceRequestTimerStart(object sender, EventArgs e)
        {
            _timer.Start();
        }

        void SimconnectServiceSimconnectDisconnected(object sender, EventArgs e)
        {
            AddLogMessage(Resources.MainView_SimConnectStatus_Disconnected);
        }

        void SimconnectServiceSimconnectConnected(object sender, EventArgs e)
        {
            AddLogMessage(Resources.MainView_SimConnectStatus_Connected);
        }

        void SimconnectServiceRequestCheckMIssions(double lat, double lon)
        {
            _missionService.FuncCheckMissions(lat, lon);
        }

        void AttachedViewRequestToggleFsxConnectionState(object sender, System.EventArgs e)
        {
            try
            {
                if (_simconnectService == null || _simconnectService.ConnectionStatus == ConnectionStatus.Disconnected) { AttachedViewRequestFsxConnect(this, EventArgs.Empty); }
                else
                {
                    _simconnectService.ToggleConnection();
                }
            }
            catch (Exception ex)
            {
                AddLogMessage(ex.Message);
            }

            if (_simconnectService == null || _simconnectService.ConnectionStatus == ConnectionStatus.Disconnected)
            {
                _timer.Stop();
            }
            if (_simconnectService != null)
                _attachedView.FsxConnectionStatus = new ConnectionStatusUi(_simconnectService.ConnectionStatus);
        }

        void AttachedViewRequestFscDisconnect(object sender, System.EventArgs e)
        {
            try
            {
                _simconnectService.Disconnect();
            }
            catch (Exception ex)
            {
                AddLogMessage(ex.Message);
            }
        }

        void AttachedViewRequestFsxConnect(object sender, System.EventArgs e)
        {
            _simconnectService = new SimConnectService(_attachedView.Handle, _attachedView.SimConnect);
            _missionService = new MissionService(_simconnectService, _settingsService);

            _simconnectService.RequestCheckMIssions += SimconnectServiceRequestCheckMIssions;
            _simconnectService.SimconnectConnected += SimconnectServiceSimconnectConnected;
            _simconnectService.SimconnectDisconnected += SimconnectServiceSimconnectDisconnected;

            _missionService.RequestTimerStart += MissionServiceRequestTimerStart;
            _missionService.RequestTimerStop += MissionServiceRequestTimerStop;

            try
            {
                _simconnectService.Connect();
                _timer.Enabled = true;
                _timer.Start();
                if (_simconnectService.ConnectionStatus == ConnectionStatus.Connected)
                {
                    _attachedView.Minimize();
                }
            }
            catch (Exception ex)
            {
                AddLogMessage(ex.Message);
            }
        }

        void AttachedViewRequestSync(object sender, System.EventArgs e)
        {
            // Sync files
            AddLogMessage(Resources.MainView_LOG_Start_Filesync);

            SynchonisationService syncServ = new SynchonisationService();
            SynchonisationService.StartSync();

            
            AddLogMessage(Resources.MainView_LOG_Filesync_Finished);
        }

        void AttachedViewRequestAboutDialog(object sender, System.EventArgs e)
        {
            ViewFactory.GetAboutView().GetAttachedView().GetAsForm().ShowDialog(_attachedView.GetAsForm());
        }

        #endregion

        #region Private Methoden

        private UserSettings GetSettingsFromView()
        {
            return new UserSettings
                                   {
                                       Interval = _attachedView.RefreshInterval,
                                       ServerPath = _attachedView.ServerUrl,
                                       SimObjectsPath = _attachedView.FsxSimObjectsPath,
                                       Username = _attachedView.Username
                                   };
        }

        private void InitView()
        {
            _attachedView.ServerFilePath = Properties.Settings.Default.LastUsedServerFile;
            if (_settingsService.CurrentSettings == null) return;
            _attachedView.Username = _settingsService.CurrentSettings.Username;
            _attachedView.ServerUrl = _settingsService.CurrentSettings.ServerPath;
            _attachedView.FsxSimObjectsPath = _settingsService.CurrentSettings.SimObjectsPath;
            _attachedView.RefreshInterval = _settingsService.CurrentSettings.Interval;
        }

        private void AddLogMessage(string message)
        {
            _logs.Add(new LogMessage { DateTime = System.DateTime.Now, Message = message });
            _attachedView.LogMessages = _logs;
        }

        #endregion

        #region IBaseViewControlle Implementation

        public IBaseView GetAttachedView()
        {
            return _attachedView;
        }

        #endregion
    }
}