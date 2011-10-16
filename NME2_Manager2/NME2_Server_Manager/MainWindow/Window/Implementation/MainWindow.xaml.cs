using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using NME2_Server_Manager.Converter;
using NME2_Server_Manager.Dto;
using NME2_Server_Manager.LoginWindow.Window.Implementation;
using NME2_Server_Manager.Nme2Ws;

namespace NME2_Server_Manager.MainWindow.Window.Implementation
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IMainWindow
    {

        private string _username;
        private string _pwd;
        private bool _isAuth;
        private bool _isguest;
        private bool _cancelLogin;

        public MainWindow()
        {
            InitializeComponent();

            //_adminWs.Credentials = new NetworkCredential("admin", "extra");

            _missionViewSource = ((System.Windows.Data.CollectionViewSource)(FindResource("missionViewSource")));
            _missionObjectViewSource = ((System.Windows.Data.CollectionViewSource)(FindResource("missionObjectViewSource")));
            _simObjectViewSource = ((System.Windows.Data.CollectionViewSource)(FindResource("simObjectViewSource")));

            while (!_isAuth && !_isguest && !_cancelLogin)
            {
                Login loginWindow = new Login();
                loginWindow.ShowDialog();
                _isguest = loginWindow.IsGuest;
                _cancelLogin = loginWindow.CancelLogin;
                if (_cancelLogin) Environment.Exit(0);
                if (!_isguest)
                {
                    _username = loginWindow.User;
                    _pwd = loginWindow.Pwd;
                    _isAuth = _adminWs.SecServiceCheckAuth(_username, Md5(_pwd)) == "1" ? true : false;
                }
            }

            if (_isguest)
            {
                // lock gui for guest
                btnAddMission.Visibility = Visibility.Collapsed;
                btnRemoveMission.Visibility = Visibility.Collapsed;
                btnAddMissionObject.Visibility = Visibility.Collapsed;
                btnRemoveMissionObject.Visibility = Visibility.Collapsed;
                btnSaveMission.Visibility = Visibility.Collapsed;
                cmbSimObjects.IsEnabled = false;
                missionObjectDataGrid.IsReadOnly = true;
                nameTextBox.IsEnabled = false;
                centerLatTextBox.IsEnabled = false;
                centerLonTextBox.IsEnabled = false;
                rangeTextBox.IsEnabled = false;
                activeTextBox.IsEnabled = false;
                objectActiveTextBox.IsEnabled = false;
                latTextBox.IsEnabled = false;
                lonTextBox.IsEnabled = false;
                headingTextBox.IsEnabled = false;
                altitudeTextBox.IsEnabled = false;
                onGroundTextBox.IsEnabled = false;
                pitchTextBox.IsEnabled = false;
                bankTextBox.IsEnabled = false;
                yawTextBox.IsEnabled = false;

            }
        }

        #region Implementation of IBaseWindow

        public System.Windows.Window GetAsWindow()
        {
            return this;
        }

        #endregion

        private readonly Nme2Ws.Nme2Ws _normWs = new Nme2Ws.Nme2Ws();
        private readonly Nme2WsAdmin.Nme2Ws _adminWs = new Nme2WsAdmin.Nme2Ws();

        private readonly System.Windows.Data.CollectionViewSource _missionViewSource;
        private readonly System.Windows.Data.CollectionViewSource _missionObjectViewSource;
        private readonly System.Windows.Data.CollectionViewSource _simObjectViewSource;

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _normWs.MissionServiceGetAllMissionsAsArrayCompleted += this.WsMissionServiceGetAllMissionsAsArrayCompleted;
            _normWs.MissionServiceGetAllMissionsAsArrayAsync();
            try
            {
                IList<SimObject> simObjects = _normWs.SimObjectServiceGetAllSimObjectsAsArray();
                IList<SimObjectDto> dtos = simObjects.Select(simObject => new SimObjectDto(simObject)).ToList();
                _simObjectViewSource.Source = dtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void WsMissionServiceGetAllMissionsAsArrayCompleted(object sender, MissionServiceGetAllMissionsAsArrayCompletedEventArgs e)
        {
            try
            {
                IList<Mission> tempList = this._normWs.MissionServiceGetAllMissionsAsArray();
                IList<MissionDto> dto = tempList.Select(mission => new MissionDto(mission)).ToList();
                this._missionViewSource.Source = dto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void WsMissionObjectServiceGetAllMissionObjectsForMissionsCompleted(object sender, MissionObjectServiceGetAllMissionObjectsForMissionsCompletedEventArgs e)
        {
            try
            {
                IList<MissionObject> objects = e.Result;
                IList<MissionObjectDto> dtos =
                    objects.Select(missionObject => new MissionObjectDto(missionObject)).ToList();
                _missionObjectViewSource.Source = dtos;
            }
            catch { }
        }

        private void BtnAddMissionObjectClick(object sender, RoutedEventArgs e)
        {
            IList<MissionObjectDto> dtos = (IList<MissionObjectDto>)_missionObjectViewSource.Source;
            if (dtos == null)
                return;
            dtos.Add(new MissionObjectDto(((MissionDto)lstMissions.SelectedItem).Mission));
            _missionObjectViewSource.Source = dtos;
            missionObjectDataGrid.Items.Refresh();

        }

        private void MissionObjectDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            missionObjectDataGrid.Items.Refresh();
        }

        private void BtnDeleteMissionObjectClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _adminWs.AdminMissionObjectServiceDeleteArrayMissionObject(
                    MissionObjectConverter.MissionObjectToAdmin(
                        ((MissionObjectDto)missionObjectDataGrid.SelectedItem).MissionObject), _username, Md5(_pwd));

                IList<MissionObjectDto> dtos = (IList<MissionObjectDto>)_missionObjectViewSource.Source;
                dtos.Remove((MissionObjectDto)missionObjectDataGrid.SelectedItem);
                _missionObjectViewSource.Source = dtos;
                missionObjectDataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Löschen fehlgeschlagen:\n" + ex.Message);
            }
        }

        private string Md5(string pwd)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(pwd));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();


        }

        private void BtnNewMissionClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MissionDto newDto = new MissionDto(new Mission() { Active = 0, Name = "Neue Mission", CenterLat = 0.0, CenterLon = 0.0 });

                newDto.Mission = MissionConverter.AdminToMission(_adminWs.AdminMissionServiceSaveArrayMission(MissionConverter.MissionToAdmin(newDto.Mission), _username, Md5(_pwd)));

                IList<MissionDto> dtos = (IList<MissionDto>)_missionViewSource.Source;
                dtos.Add(newDto);
                _missionViewSource.Source = dtos;
                lstMissions.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anlegen fehlgeschlagen:\n" + ex.Message);
            }
        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstMissions.Items.Count <= 0) return;

            if (((MissionDto)lstMissions.SelectedItem).Mission.Id == 0)
            {
                _missionObjectViewSource.Source = new List<MissionObjectDto>();
                return;
            }
            _normWs.MissionObjectServiceGetAllMissionObjectsForMissionsCompleted += this.WsMissionObjectServiceGetAllMissionObjectsForMissionsCompleted;
            _normWs.MissionObjectServiceGetAllMissionObjectsForMissionsAsync(new[] { ((MissionDto)lstMissions.SelectedItem).Mission });
        }

        private void btnShowMap_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Mission attachedMission = (Mission)button.Tag;
            CoordinateDto dto = new CoordinateDto(){Lat = attachedMission.CenterLat, Lon = attachedMission.CenterLon};
            CoordinateWindow.Window.Implementation.CoordinateWindow cWindow = new CoordinateWindow.Window.Implementation.CoordinateWindow{Coordinate = dto};
            cWindow.ReadOnly = true;
            cWindow.ShowDialog();
        }

        private void ButtonClick3(object sender, RoutedEventArgs e)
        {

            IList<MissionObjectDto> dtos = _missionObjectViewSource.Source as IList<MissionObjectDto>;
            if (dtos == null) return;
            foreach (MissionObjectDto dto in dtos)
            {
                _adminWs.AdminMissionObjectServiceSaveArrayMissionObject(MissionObjectConverter.MissionObjectToAdmin(dto.MissionObject), _username, Md5(_pwd));
            }
            Mission mission = ((MissionDto)lstMissions.SelectedItem).Mission;
            _adminWs.AdminMissionServiceSaveArrayMission(MissionConverter.MissionToAdmin(mission), _username, Md5(_pwd));

            ReloadMissions();
        }

        private void ReloadMissions()
        {
            _normWs.MissionServiceGetAllMissionsAsArrayCompleted += this.WsMissionServiceGetAllMissionsAsArrayCompleted;
            _normWs.MissionServiceGetAllMissionsAsArrayAsync();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Nme2WsAdmin.Nme2Ws adminWs = new Nme2WsAdmin.Nme2Ws();
            adminWs.AdminMissionServiceDeleteArrayMission(MissionConverter.MissionToAdmin(((MissionDto)lstMissions.SelectedItem).Mission), _username, Md5(_pwd));
            ReloadMissions();
        }

        private void btnRefreshAll_Click(object sender, RoutedEventArgs e)
        {
            ReloadMissions();
        }

        private void btnShowMapMission_Click(object sender, RoutedEventArgs e)
        {
            CoordinateDto dto = new CoordinateDto() { Lat = double.Parse(centerLatTextBox.Text.Replace('.',',')), Lon = double.Parse(centerLonTextBox.Text.Replace('.',',')) };
            CoordinateWindow.Window.Implementation.CoordinateWindow cWindow = new CoordinateWindow.Window.Implementation.CoordinateWindow { Coordinate = dto };
            if (_isguest) cWindow.ReadOnly = true;
            cWindow.ShowDialog();
            if (cWindow.ValueAccepted)
            {
                centerLatTextBox.BeginChange();
                centerLatTextBox.Text = cWindow.Coordinate.Lat.ToString();
                centerLatTextBox.EndChange();
                centerLonTextBox.BeginChange();
                centerLonTextBox.Text = cWindow.Coordinate.Lon.ToString();
                centerLonTextBox.EndChange();
            }
        }

        private void BtnShowMapObjectClick(object sender, RoutedEventArgs e)
        {
            CoordinateDto dto = new CoordinateDto() { Lat = double.Parse(latTextBox.Text.Replace('.', ',')), Lon = double.Parse(lonTextBox.Text.Replace('.', ',')) };
            CoordinateWindow.Window.Implementation.CoordinateWindow cWindow = new CoordinateWindow.Window.Implementation.CoordinateWindow { Coordinate = dto };
            if (_isguest) cWindow.ReadOnly = true;
            cWindow.ShowDialog();
            if (cWindow.ValueAccepted)
            {
                latTextBox.BeginChange();
                latTextBox.Text = cWindow.Coordinate.Lat.ToString().Replace(',','.');
                latTextBox.EndChange();
                lonTextBox.BeginChange();
                lonTextBox.Text = cWindow.Coordinate.Lon.ToString().Replace(',', '.'); ;
                lonTextBox.EndChange();
            }
        }
    }
}

