<?php
// Functions
function fQueryMysql($query) {
	require("settings.php");
	$link = mysql_pconnect($db_server,$db_user,$db_pass);
	mysql_select_db($db_name,$link);
	$result = mysql_query($query,$link);
	return $result;
}
?>