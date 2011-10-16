<?php
/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
require_once 'template_gen.php';

$tplNav = new tpl();
$tplNav->tpl("Template/Element_NavBar.html", "{", "}");

$linklist = "";

// Generate Link List
$tplLinkItem = new tpl();
$tplLinkItem->tpl("Template/Nav_Link.html", "{", "}");
$tplLinkItem->set("LinkTarget", "Site_Home.php");
$tplLinkItem->set("LinkName", "Overview");
$linklist = $linklist . $tplLinkItem->outAsString();

$tplLinkItem = new tpl();
$tplLinkItem->tpl("Template/Nav_Link.html", "{", "}");
$tplLinkItem->set("LinkTarget", "Site_Faq.php");
$tplLinkItem->set("LinkName", "FAQ");
$linklist = $linklist . $tplLinkItem->outAsString();

$tplLinkItem = new tpl();
$tplLinkItem->tpl("Template/Nav_Link.html", "{", "}");
$tplLinkItem->set("LinkTarget", "Site_Download.php");
$tplLinkItem->set("LinkName", "Download");
$linklist = $linklist . $tplLinkItem->outAsString();

$tplLinkItem = new tpl();
$tplLinkItem->tpl("Template/Nav_Link.html", "{", "}");
$tplLinkItem->set("LinkTarget", "Site_Contact.php");
$tplLinkItem->set("LinkName", "Contact");
$linklist = $linklist . $tplLinkItem->outAsString();

$tplNav->set("Linklist", $linklist);

$tplNav->out();
?>
