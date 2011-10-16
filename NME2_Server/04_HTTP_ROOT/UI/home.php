<?php

$tpl = new tpl('tpl/home.tpl', '{', '}');

$date = getdate();

if ($date[mon] == 1) {$date[mon] = "01";}
else if ($date[mon] == 2) {$date[mon] = "02";}
else if ($date[mon] == 3) {$date[mon] = "03";}
else if ($date[mon] == 4) {$date[mon] = "04";}
else if ($date[mon] == 5) {$date[mon] = "05";}
else if ($date[mon] == 6) {$date[mon] = "06";}
else if ($date[mon] == 7) {$date[mon] = "07";}
else if ($date[mon] == 8) {$date[mon] = "08";}
else if ($date[mon] == 9) {$date[mon] = "09";}
else {$date[mon] = $date[mon];}

if ($date[mday] == 1) {$date[mday] = "01";}
else if ($date[mday] == 2) {$date[mday] = "02";}
else if ($date[mday] == 3) {$date[mday] = "03";}
else if ($date[mday] == 4) {$date[mday] = "04";}
else if ($date[mday] == 5) {$date[mday] = "05";}
else if ($date[mday] == 6) {$date[mday] = "06";}
else if ($date[mday] == 7) {$date[mday] = "07";}
else if ($date[mday] == 8) {$date[mday] = "08";}
else if ($date[mday] == 9) {$date[mday] = "09";}
else {$date[mday] = $date[mday];}

$CUser = "";
$result = fQueryMysql("select distinct USERNAME from positions order by USERNAME ASC limit 10;");
$num = mysql_numrows ($result);
$num=$num-1;
for ($i=0; $i<=$num; $i++){
	$row = mysql_fetch_array($result);
	$CUser = "$CUser $row[USERNAME]<br>";
}

$CMissions = "";
$result = fQueryMysql("select * from missions order by VERSION DESC limit 10;");
$num = mysql_numrows ($result);
$num=$num-1;
for ($i=0; $i<=$num; $i++){
	$row = mysql_fetch_array($result);
	$CMissions = "$CMissions $cMissions $row[NAME]<br>";
}

$CLibrary = "";
$result = fQueryMysql("select * from library order by VERSION DESC limit 10;");
$num = mysql_numrows ($result);
$num=$num-1;
for ($i=0; $i<=$num; $i++){
	$row = mysql_fetch_array($result);
	$CLibrary = "$CLibrary $row[NAME]<br>";
}

$tpl->set('CUser', $CUser);
$tpl->set('CMissions', $CMissions);
$tpl->set('CLibrary', $CLibrary);

if(!$tpl->checkError())
	$tpl->out();
	
?>