<?php

require("../functions.php");

$op = $_POST["op"];
if (empty($op)){
	$op = $_REQUEST["op"];
}

$param = $_POST["param"];
if (empty($param)){
	$param = $_REQUEST["param"];
}

switch ($op){
	case 1:
		// Get filelist from library
		// REQUIRE: -
		// RETURN: Filelist
		$filelist = "";
		$result = fQueryMysql("select ID, FILENAME from library where FILENAME!='' order by ID asc;");
		$num = mysql_numrows ($result);
		$num=$num-1;
		for ($i=0; $i<=$num; $i++){
			$row = mysql_fetch_array($result);
			$filename = $row[FILENAME];
			$filename = substr($filename, 0, -4);
			$filelist = $filelist . ";$filename";
		}
		echo $filelist;
	break;
	case 2:
		// Get misions
		// REQUIRE: -
		// RETURN: Missions
		$Query =  "select * from missions order by ID asc";
		$result = fQueryMysql($Query);
		$num = mysql_numrows ($result);
		$num=$num-1;
		for ($i=0; $i<=$num; $i++){
			$row = mysql_fetch_array($result);
			
			$IDList = $IDList ."/$row[ID]*$row[NAME]*$row[VERSION]*$row[LIBOBJECTID]*$row[LAT]*$row[LON]*$row[RANGE]*$row[ACTIVE]";
		}
		echo $IDList;
	break;
	case 3:
		// Get mission version
		// REQUIRE: Mission ID
		// RETURN: Mission version
		$Query =  "select ID, VERSION from missions where ID='$param' limit 1";
		$result = fQueryMysql($Query);
		$row = mysql_fetch_array($result);
		$ObjectVERSION = $row[VERSION];
		echo $ObjectVERSION;
	break;
	case 4:
	$MissionDetails = "";
		// Get mission information
		// REQUIRE: Mission ID
		// RETURN: Mission information - ID, Version, Object ID, Object Version
		$Query =  "select * from missions where ID='$param' limit 1";
		$result = fQueryMysql($Query);
		$num = mysql_numrows ($result);
		$num=$num-1;
		for ($i=0; $i<=$num; $i++){
			$row = mysql_fetch_array($result);
			$ID = $row[ID];
			$NAME = $row[NAME];
			$VERSION = $row[VERSION];
			$LIBOBJECTID = $row[LIBOBJECTID];
			$LAT = $row[LAT];
			$LON = $row[LON];
			$RANGE = $row[RANGE];
			$MissionDetails = "$ID*$NAME*$VERSION*$LIBOBJECTID*$LAT*$LON*$RANGE";
		}
		echo $MissionDetails;
	break;
	case 5:
		// Get object name
		// REQUIRE: Object ID
		// RETURN: Object name
		$Query =  "select NAME,ID from library where ID='$param' limit 1";
		$result = fQueryMysql($Query);
		$row = mysql_fetch_array($result);
		$ObjectNAME = $row[NAME];
		echo $ObjectNAME;
	break;
	case 6:
		// Get mission name
		// REQUIRE: Object ID
		// RETURN: Object name
		$Query =  "select NAME,ID from missions where ID='$param' limit 1";
		$result = fQueryMysql($Query);
		$row = mysql_fetch_array($result);
		$ObjectNAME = $row[NAME];
		echo $ObjectNAME;
	break;
	case 7:
		// Set mission status
		// REQUIRE: Mission ID / State
		// RETURN : -
		$paramexplode = explode("/", $param);
		$Query =  "UPDATE missions SET ACTIVE='$paramexplode[1]' WHERE ID='$paramexplode[0]' limit 1";
		$result = fQueryMysql($Query);
	break;
	case 8:
		// Get library file
		// REQUIRE: -
		// RETURN: filepath & size
		$query  = "SELECT fname, lname FROM students";
		$result = fQueryMysql("SELECT * FROM Library");
		
		$tsv  = array();
		$html = array();
		while($row = mysql_fetch_array($result, MYSQL_NUM))
		{
		   $tsv[]  = implode("\t", $row);
		   $html[] = "<tr><td>" .implode("</td><td>", $row) .              "</td></tr>";
		}
		
		$tsv = implode("\r\n", $tsv);
		$html = "<table>" . implode("\r\n", $html) . "</table>";
		
		$fileName = 'mysql-to-excel.xls';
		header("Content-type: application/vnd.ms-excel");
		header("Content-Disposition: attachment; filename=$fileName");
		
		echo $tsv;
	break;
	case 9:
		// Get library
		// REQUIRE: -
		// RETURN: lib
		$filelist = "";
		$result = fQueryMysql("select * from library order by ID asc;");
		$num = mysql_numrows ($result);
		$num=$num-1;
		for ($i=0; $i<=$num; $i++){
			$row = mysql_fetch_array($result);
			$filename = $row[FILENAME];
			$id = $row[ID];
			$version = $row[VERSION];
			$name = $row[NAME];
			$filelist = $filelist . "#$id;$name;$version;$filename";
		}
		echo $filelist;
	break;
	case 10:
		// Update mission
		// REQUIRE: missionstring
		// RETURN: -
		//echo $param;
		$param = str_replace("Q", "#", $param);
		$param = explode("*", $param);
		$ID = (string)$param[0];
		$NAME = (string)$param[1];
		$VERSION = (string)$param[2];
		$LIBOBJECTID = (string)$param[3];
		$LAT = (string)$param[4];
		$LON = (string)$param[5];
		$RANGE = (string)$param[6];
		//echo $LAT;
		$query = "UPDATE missions SET NAME='$NAME', VERSION='$VERSION', LIBOBJECTID='$LIBOBJECTID', LAT='$LAT', LON='$LON', `RANGE`='$RANGE' WHERE ID='$ID'";
		fQueryMysql($query);
	break;
	case 11:
		// Get Max ID or calculate empty ID
		// REQUIRE : -
		// RETURN : new ID
		
		// get max id from db
		$Query =  "select max(ID) from missions limit 1";
		$result = fQueryMysql($Query);
		$row = mysql_fetch_array($result);
		$maxID= $row[0];
		// if max id > 999999 -> call clean db to recalc ids
		if ($maxID > "999999"){
			// -------------------------------------------------------------- TODO : recalc IDs
		}
		// else get max + 1
		else {
			$maxID = $maxID + 1;
		}
		echo $maxID;
	break;
	case 12:
		// Insert new missio
		// REQUIRE: ID, VERSION, Name, Lat, Lon, Range
		// RETURN: -
		$param = explode("*", $param);
		$ID = $param[0];
		$VERSION = $param[1];
		$NAME = $param[2];
		$LAT = $param[3];
		$LON = $param[4];
		$RANGE = $param[5];
		
		$query = "INSERT INTO missions (ID, VERSION, NAME, LAT, LON, `RANGE`, ACTIVE) VALUES ('$ID','$VERSION', '$NAME', '$LAT', '$LON', '$RANGE', '0');";
		fQueryMysql($query);
		echo $query;
	break;
	case 13:
		// Delete mission
		// REQUIRE : ID
		// RETURN : -
		$query = "DELETE FROM missions WHERE ID='$param';";
		fQueryMysql($query);
	break;
	case 14:
		// Insert complete mission
		// REQUIRE: complete mission string
		// RETURN: -
		$param = explode("*", $param);
		$ID = $param[0];
		$VERSION = $param[1];
		$NAME = $param[2];
		$LIBOBJECTID = $param[3];
		$LAT = $param[4];
		$LON = $param[5];
		$RANGE = $param[6];
		
		$query = "INSERT INTO missions (ID, VERSION, NAME, LIBOBJECTID, LAT, LON, `RANGE`, ACTIVE) VALUES ('$ID','$VERSION', '$NAME','$LIBOBJECTID', '$LAT', '$LON', '$RANGE', '0');";
		fQueryMysql($query);
		echo $query;
	break;
}
?>