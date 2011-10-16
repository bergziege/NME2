using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GMap.NET;
using NME2_Server_Manager.Dto;
using NME2_Server_Manager.GeoTools;

namespace NME2_Server_Manager.CoordinateWindow.Window.Implementation {
    /// <summary>
    /// Interaktionslogik für CoordinateWindow.xaml
    /// </summary>
    public partial class CoordinateWindow : System.Windows.Window {
        private CollectionViewSource _coordinateSource;
        private CoordinateDto _coordinate;
        private bool _mapUpdatesTxt;
        private bool _txtUpdatesMaps;
        private bool _isLoading;
        private bool _valueAccepted;
        private bool _readonly;

        public CoordinateDto Coordinate {
            get
            {
                _coordinate.Lat = double.Parse(txtLat.Text.Replace('.', ','));
                _coordinate.Lon = double.Parse(txtLon.Text.Replace('.', ','));
                return _coordinate;
            }
            set
            {
                _isLoading = true;
                _coordinate = value;
                IList<CoordinateDto> fake = new List<CoordinateDto> {this._coordinate};
                _coordinateSource.Source = fake;
                _isLoading = false;
                _txtUpdatesMaps = true;
                SetMapPosition(txtLat.Text, txtLon.Text);
                _txtUpdatesMaps = false;

                double newLat;
                double newLon;

                // testweise
                //ProjectionHelper.ProjectNewCoordinates(_coordinate.Lat, _coordinate.Lon, 360, 0, out newLat, out newLon);
            }
        }

        public bool ValueAccepted
        {
            get { return _valueAccepted; }
        }

        public bool ReadOnly
        {
            set { _readonly = value;
                LockWindow();
            }
        }

        private void LockWindow()
        {
            btnAccept.Visibility = Visibility.Collapsed;
        }

        public CoordinateWindow() {
            InitializeComponent();
            _coordinateSource = ((System.Windows.Data.CollectionViewSource)(FindResource("coordinateSource")));

            map.MapType = MapType.GoogleSatellite;
            map.MaxZoom = 20;
            map.MinZoom = 0;
            map.Zoom = 5;
            SetMapPosition("51", "13");
            map.OnCurrentPositionChanged += map_OnCurrentPositionChanged;
        }

        private void SetMapPosition(string lat, string lon)
        {
            lat = lat.Replace(',', '.');
            lon = lon.Replace(',', '.');
            if (!string.IsNullOrEmpty(lat) && !string.IsNullOrEmpty(lon))
            {
                map.Position = new PointLatLng(double.Parse(lat, System.Globalization.CultureInfo.InvariantCulture),
                                               double.Parse(lon, System.Globalization.CultureInfo.InvariantCulture));
            }
        }

        void map_OnCurrentPositionChanged(PointLatLng point)
        {
            if (!_txtUpdatesMaps && !_isLoading)
            {
                _mapUpdatesTxt = true;
                txtLat.Text = point.Lat.ToString().Replace(',','.');
                txtLon.Text = point.Lng.ToString().Replace(',', '.');
                _mapUpdatesTxt = false;
            }
        }

        private void TxtLatTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_mapUpdatesTxt && !_isLoading)
            {
                _txtUpdatesMaps = true;
                SetMapPosition(txtLat.Text, txtLon.Text);
                _txtUpdatesMaps = false;
            }
        }

        private void TxtLonTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_mapUpdatesTxt && !_isLoading)
            {
                _txtUpdatesMaps = true;
                SetMapPosition(txtLat.Text, txtLon.Text);
                _txtUpdatesMaps = false;
            }
        }

        private void btnAccept_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _valueAccepted = true;
            Close();
        }

        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            map.Zoom = Convert.ToInt32(e.NewValue);
        }
    }
}
