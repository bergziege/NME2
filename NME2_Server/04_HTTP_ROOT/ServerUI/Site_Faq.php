<?php
/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

include 'Element_NavBar.php';

require_once '../Service/MissionService.php';

$tplFaq = new tpl();
$tplFaq->tpl("Template/Content_Faq.html", "{", "}");

$tplFaq->out();

include 'Element_Closing.php'
?>
