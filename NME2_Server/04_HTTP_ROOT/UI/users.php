<?php

include_once 'header.php';

$contentLeft ="";
$contentRight="<p>Übersicht über zur Zeit am System angemeldete Benutzer</p>";

$CUser = "";
$result = fQueryMysql("select distinct USERNAME from positions order by USERNAME ASC limit 10;");
$num = mysql_numrows ($result);
$num=$num-1;
for ($i=0; $i<=$num; $i++) {
    $row = mysql_fetch_array($result);
    $CUser = "$CUser $row[USERNAME]<br>";
}

$contentLeft = $contentLeft . "<p>User</p>" . $CUser;


$tpl->set("ContentLeft",$contentLeft);
$tpl->set("ContentRight", $contentRight);

include_once 'footer.php';

?>