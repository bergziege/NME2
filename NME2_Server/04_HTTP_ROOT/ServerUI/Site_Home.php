<?php
/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
*/

include 'Element_NavBar.php';

require_once '../Service/MissionService.php';
require_once '../Service/MissionObjectService.php';

$tplHome = new tpl();
$tplHome->tpl("Template/Content_Home.html", "{", "}");

// Get missions and fill mission table
$missionService = new MissionService();
$missions = $missionService->GetAllMissions();

$missionObjectService = new MissionObjectService();

$rowlist = "";
foreach ($missions as $mission) {

    $tplMissionRow = new tpl();
    $tplMissionRow->tpl("Template/Mission_Table_Row.html", "{", "}");
    $tplMissionRow->set("MissionName", $mission['Name']);
    $tplMissionRow->set("MissionRange", $mission['MissionRange']);
    $tplMissionRow->set("Lat", substr($mission['CenterLat'], 0, 9));
    $tplMissionRow->set("Lon", substr($mission['CenterLon'], 0, 9));

    $count = count($missionObjectService->GetAllMissionObjectsForMissions($mission));
    $tplMissionRow->set("ObjectCount", $count);
    $rowlist = $rowlist . $tplMissionRow->outAsString();
}
$tplHome->set("MissionTableRows", $rowlist);


$tplHome->out();

include 'Element_Closing.php'
        ?>
