<?php

include_once 'header.php';

$contentLeft ="<p>Server Übersicht</p><p>Zur Auswahl stehen:<br>Diese Übersicht<br>Eine Übersicht über zur Zeit am System angemeldeter Benutzer<br>Kartendarstellung der Benutzer und Missionen<br>Hilfeseite<br>Downloads</p>";
$contentRight="";

$CUser = "";
$result = fQueryMysql("select distinct USERNAME from positions order by USERNAME ASC limit 10;");
$num = mysql_numrows ($result);
$num=$num-1;
for ($i=0; $i<=$num; $i++) {
    $row = mysql_fetch_array($result);
    $CUser = "$CUser $row[USERNAME]<br>";
}

$contentRight = $contentRight . "<p>User</p>" . $CUser;

$CMissions = "";
$result = fQueryMysql("select * from missions order by VERSION DESC limit 10;");
$num = mysql_numrows ($result);
$num=$num-1;
for ($i=0; $i<=$num; $i++) {
    $row = mysql_fetch_array($result);
    $CMissions = "$CMissions $cMissions $row[NAME]<br>";
}

$contentRight = $contentRight . "<p>Missions</p>" . $CMissions;

$tpl->set("ContentLeft",$contentLeft);
$tpl->set("ContentRight", $contentRight);

include_once 'footer.php';

?>