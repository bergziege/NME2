<?php
/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

include 'Element_NavBar.php';

require_once '../Service/MissionService.php';

$tplContact = new tpl();
$tplContact->tpl("Template/Content_Contact.html", "{", "}");

$tplContact->out();

include 'Element_Closing.php'
?>
