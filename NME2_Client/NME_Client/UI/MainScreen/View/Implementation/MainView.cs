using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.FlightSimulator.SimConnect;
using NME2.Domain;
using NME2.Domain.Dto;
using NME2.Properties;

namespace NME2.UI.MainScreen.View.Implementation
{
    ///<summary>
    /// Main GUI
    ///</summary>
    public partial class MainView : Form, IMainView
    {
        

        // User-defined win32 event
        const int WM_USER_SIMCONNECT = 0x0402;

        ///<summary>
        /// Ctor.
        ///</summary>
        public MainView()
        {
            InitializeComponent();

            // TODO: uncomment to force sync before fs connect
            btnConnect.Enabled = false;

            Settings.Default.Reload();
            txtFSXPath.Text = Settings.Default.CustomSimObjectPath;
            Text = Resources.MainView_NME2_Disconnected;
        }


        private void BtnSyncClick(object sender, EventArgs e)
        {
            if (RequestSync != null)
            {
                RequestSync(this, EventArgs.Empty);
            }
            btnConnect.Enabled = true;
        }

        private void BtnConnectClick(object sender, EventArgs e)
        {
            if (RequestToggleFsxConnectionState != null)
            {
                RequestToggleFsxConnectionState(this, EventArgs.Empty);
            }
        }

        private void BtnMinClick(object sender, EventArgs e)
        {
            // Minimize window
            WindowState = FormWindowState.Minimized;
        }


        private void Form1FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RequestFscDisconnect != null)
            {
                RequestFscDisconnect(this, EventArgs.Empty);
            }
        }


        /*
        * Abfangen von Simconnect nachrichten
        */
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                if (NewMessageArrived != null)
                {
                    NewMessageArrived(this, EventArgs.Empty);
                }

                //if (_mySimconnect != null)
                //{
                //    _mySimconnect.ReceiveMessage();
                //}
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }
        

        private void BtnHelpClick(object sender, EventArgs e)
        {
            if (RequestAboutDialog != null)
            {
                RequestAboutDialog(this, EventArgs.Empty);
            }
        }

        private void BtnSelectFolderClick(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = txtFSXPath.Text;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            txtFSXPath.Text = folderBrowserDialog.SelectedPath;
            Settings.Default.CustomSimObjectPath = txtFSXPath.Text;
            Settings.Default.Save();
        }

        public Form GetAsForm()
        {
            return this;
        }

        public event EventHandler RequestAboutDialog;
        public event EventHandler TabChanged;
        public event EventHandler RequestToggleFsxConnectionState;
        public event EventHandler RequestSync;
        public event EventHandler RequestSettingsReset;
        public event EventHandler RequestSettingsSave;
        public event EventHandler RequestSettingsLoad;
        public event EventHandler RequestFsxConnect;
        public event EventHandler RequestFscDisconnect;
        public event EventHandler NewMessageArrived;

        /// <summary>
        /// Status der Simconnect Verbindung als Text
        /// </summary>
        public ConnectionStatusUi FsxConnectionStatus
        {
            set
            {
                btnConnect.Text = value.AvailableOperation;
                btnIndicator.Text = value.ToString();
                btnIndicator.BackColor = value.ConnectionStatusColor;
            }
        }

        /// <summary>
        /// Pfad zur aktuellen server settings datei
        /// </summary>
        public string ServerFilePath
        {
            get { return txtFile.Text; }
            set { txtFile.Text = value; }
        }

        /// <summary>
        /// URL des NME2 Servers
        /// </summary>
        public string ServerUrl
        {
            get { return txtServer.Text; }
            set { txtServer.Text = value; }
        }

        /// <summary>
        /// Benutzername
        /// </summary>
        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        /// <summary>
        /// Pfad zu den FSX Simobjects
        /// </summary>
        public string FsxSimObjectsPath
        {
            get { return txtFSXPath.Text; }
            set { txtFSXPath.Text = value; }
        }

        /// <summary>
        /// Reload Interval der Missionen
        /// </summary>
        public int RefreshInterval
        {
            get { return (int) nudInterval.Value; }
            set { nudInterval.Value = value; }
        }

        /// <summary>
        /// Index der aktuell gewählten Tab Seite
        /// </summary>
        public int SelectedTabPage
        {
            get { return tabControl1.SelectedIndex; }
        }

        /// <summary>
        /// Liste mit Log Nachrichten
        /// </summary>
        public IList<LogMessage> LogMessages
        {
            get { return bsLogs.DataSource as IList<LogMessage>; }
            set { bsLogs.DataSource = value; bsLogs.ResetBindings(false); }
        }

        /// <summary>
        /// Liste mit Missionen
        /// </summary>
        public IList<MissionDto> Missions
        {
            get { return bsMissions.DataSource as IList<MissionDto>; }
            set { bsMissions.DataSource = value; bsMissions.ResetBindings(false); }
        }

        public SimConnect SimConnect
        {
            get { return new SimConnect("NME2", this.Handle, WM_USER_SIMCONNECT, null, 0); }
            set { throw new NotImplementedException(); }
        }

        public void Minimize()
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnSelectFileClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;
                if (RequestSettingsLoad != null)
                {
                    RequestSettingsLoad(this, EventArgs.Empty);
                }
            }
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            if (RequestSettingsSave != null)
            {
                RequestSettingsSave(this, EventArgs.Empty);
            }
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            if (RequestSettingsReset != null)
            {
                RequestSettingsReset(this, EventArgs.Empty);
            }
        }

        private void TabControl1SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabChanged != null)
            {
                TabChanged(this, EventArgs.Empty);
            }
        }
    }
}
