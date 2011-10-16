<?php
/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

include 'Element_NavBar.php';

require_once '../Service/MissionService.php';

$tplDownload = new tpl();
$tplDownload->tpl("Template/Content_Download.html", "{", "}");

$tplDownload->out();

include 'Element_Closing.php'
?>
