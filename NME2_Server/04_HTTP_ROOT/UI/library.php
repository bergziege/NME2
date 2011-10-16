<?php

$tpl = new tpl('tpl/library.tpl', '{', '}');

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

$CMissions = "";
$switch = 0;
$result = fQueryMysql("select * from library order by NAME ASC;");
$num = mysql_numrows ($result);
$num=$num-1;
for ($i=0; $i<=$num; $i++){
	$row = mysql_fetch_array($result);
	if ($switch == 0){
	$library = "$library<tr style='background-color:#aaaaaa'><td>$row[ID]</td><td style='border-left: 1px solid black'>$row[NAME]</td><td style='border-left: 1px solid black'>$row[VERSION]</td>";
	$switch = 1;
	}
	else{
	$library = "$library<tr style='background-color:#dddddd'><td>$row[ID]</td><td style='border-left: 1px solid black'>$row[NAME]</td><td style='border-left: 1px solid black'>$row[VERSION]</td>";
	$switch = 0;
	}
}

$tpl->set('library', $library);

if(!$tpl->checkError())
	$tpl->out();
	
?>