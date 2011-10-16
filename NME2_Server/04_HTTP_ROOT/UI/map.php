<?php

include_once 'header.php';

$tplContentLeft = new tpl();
$tplContentRight = new tpl();
$tplContentLeft->tpl("Templates/map.html", "{", "}");
$tplContentRight->tpl("Templates/mapContent.html", "{", "}");


// query user
$xmlfile_name = "markers.xml";
$xmlfile_handle = fopen($xmlfile_name, 'w') or die("can't open file");
fwrite($xmlfile_handle, "<markers>\n");

$userlist = fQueryMysql("SELECT * FROM positions");
$num = mysql_numrows ($userlist);
$num=$num-1;
for ($i=0; $i<=$num; $i++){
	$rowuser = mysql_fetch_array($userlist);
	$username = $rowuser[USERNAME];
	$latitude = $rowuser[LAT];
	$longitude = $rowuser[LON];
	fwrite($xmlfile_handle, "\t<marker lat='$latitude' lng='$longitude' html='$latitude | $longitude | $username'  label='$username' icon='Skin/usercentericon.png' iconshadow='Skin/usercentericon.png' />'\n");
}

$missions = fQueryMysql("SELECT * FROM missions");
$num = mysql_numrows ($missions);
$num=$num-1;
for ($i=0; $i<=$num; $i++){
	$rowmission = mysql_fetch_array($missions);
	$name = $rowmission[NAME];
	$latitude = $rowmission[LAT];
	$longitude = $rowmission[LON];
	$range = $rowmission[RANGE];
	fwrite($xmlfile_handle, "\t<marker lat='$latitude' lng='$longitude' html='$latitude | $longitude | $name | $range'  label='$name'  icon='Skin/missioncentericon.png' iconshadow='Skin/missioncentericon.png' />'\n");
	fwrite($xmlfile_handle,"<line colour='#FF0000' width='4' html=''>");
	fwrite($xmlfile_handle, CreateKMLCircle($latitude, $longitude, $range));
	fwrite($xmlfile_handle,"</line>");
}

function CreateKMLCircle($lat, $lon, $range){
	$returnstring = "";
	
	$pi = 3.141592654;
	$firstlat = "";
	$firstlon = "";
	for ($winkel = 0;$winkel < 360; $winkel = $winkel + 5){
		$H1 = deg2rad($lat);;
		$H2 = deg2rad($lon);
		$H4 = ($pi/ (180 * 60)) * ($range / 1.852);
            
                $H3 = deg2rad($winkel);
            
                $H6 = asin(sin($H1) * cos($H4) + cos($H1) * sin($H4) * cos($H3));
                $H7 = -1 * (atan2((sin($H3) * sin($H4) * cos($H1)), (cos($H4) - sin($H1) * sin($H6))));
		//$H8 = ($H2 - $H7 + $pi) - Math.truncate(($H2 - $H7 + $pi) / 2 / $pi) - $pi;
                $H8 = ($H2 - $H7 + $pi) - floor(($H2 - $H7 + $pi) / 2 / $pi) - $pi;

                $DestLat = rad2deg($H6);
                $DestLon = rad2deg($H8);
		if ($winkel == 0){
		$firstlat = $DestLat;
		$firstlon = $DestLon;
		}
		$returnstring = "$returnstring<point lat='$DestLat' lng='$DestLon' />\n";
	}
	$returnstring = "$returnstring<point lat='$firstlat' lng='$firstlon' />\n";
	return $returnstring;
}

fwrite($xmlfile_handle, "</markers>\n");
fclose($xmlfile_handle);


$tpl->set("ContentLeft", $tplContentLeft->outAsString());
$tpl->set("ContentRight", $tplContentRight->outAsString());

include_once 'footer.php';

?>