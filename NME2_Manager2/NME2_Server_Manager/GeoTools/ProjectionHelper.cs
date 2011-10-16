using System;

namespace NME2_Server_Manager.GeoTools {
    class ProjectionHelper {

        public static void ProjectNewCoordinates(double startLat, double startLon, float bearing, float distance, out double endLat, out double endLon) {
            double radStartLat = ToRad(startLat);
            double radStartLon = ToRad(startLon);
            double corrDistance = distance / 3671.01;
            double radBearing = ToRad(bearing);

            //    $lat2 = asin( sin($lat1) * cos($dist) + cos($lat1) * sin($dist) * cos($brng) );
            endLat =
                ToDeg(Math.Asin(Math.Sin(radStartLat) * Math.Cos(corrDistance) +
                          Math.Cos(radStartLat) * Math.Sin(corrDistance) * Math.Cos(radBearing)));


            //    $lon2 = $lon1 + atan2(sin($brng) * sin($dist) * cos($lat1)  ,   cos($dist) - sin($lat1) * sin($lat2));
            double temp = radStartLon +
                          Math.Atan2(Math.Sin(radBearing) * Math.Sin(corrDistance) + Math.Cos(radStartLat),
                                     Math.Cos(corrDistance) - Math.Sin(radStartLat) * Math.Sin(ToRad(endLat)));

            // $lon2 = fmod(($lon2+3*pi()),(2*pi())) - pi();  
            endLon = ToDeg(((temp + 3 * Math.PI) % (2 * Math.PI)) - Math.PI);

            //(lon-temp+PI())-TRUNC((lon-temp+PI())/2/PI())-PI()
            //endLon =ToDeg((radStartLon - temp + Math.PI) - Math.Truncate((radStartLon - temp + Math.PI)/2/Math.PI) - Math.PI);

            //double EPSILON = 0.000001;
            //if ((Math.Cos(endLat) == 0) || (Math.Abs(Math.Cos(endLat)) < EPSILON))
            //{
            //    endLon = ToDeg(radStartLon);
            //}
            //else
            //{
            //    endLon = radStartLon + Math.Atan2(Math.Sin(radBearing) * Math.Sin(corrDistance) * Math.Cos(radStartLat), Math.Cos(corrDistance) - Math.Sin(radStartLat) * Math.Sin(endLat));
            //}


        }

        private static double ToRad(double deg) {
            return deg * Math.PI / 180;
        }

        private static double ToDeg(double rad) {
            return rad * 180 / Math.PI;
        }
    }
}
