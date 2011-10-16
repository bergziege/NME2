namespace NME2_Server_Manager.Dto {
    public class CoordinateDto {
        private double _lat;
        private double _lon;

        public double Lat {
            get { return this._lat; }
            set { this._lat = value; }
        }

        public double Lon {
            get { return this._lon; }
            set { this._lon = value; }
        }
    }
}
