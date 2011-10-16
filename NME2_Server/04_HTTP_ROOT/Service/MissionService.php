<?php
/**
 * Description of MissionService
 *
 * @author bergziege
 */

require_once '../Settings/bootstrap.php';
require_once '../Helper/CoordinateHelper.php';

class MissionService {
    function GetMissionsWithin($lat, $lon) {

        // TODO: Einschränkung der Abfrage auf in der Nähe liegende Missionen
        $missions = Doctrine_Core::getTable("Mission")->findAll();
        $missionArray = array();
        foreach ($missions as $mission) {
            if (GetDistance($mission['CenterLat'], $mission['CenterLon'], $lat, $lon) <= $mission['MissionRange'] && $mission['Active'] == 1)
                $missionArray[] = $mission->toArray();
        }
        //print_r($missionArray);
        return $missionArray;
    }

    function GetAllMissions() {
        $missions = Doctrine_Core::getTable('Mission')->findAll();
        return $missions;
    }

    function GetAllMissionsAsArray() {
        $missionArray = array();
        $missions = Doctrine_Core::getTable('Mission')->findAll();
        foreach ($missions as $mission){
            $missionArray[] = $mission->toArray();
        }
        return $missionArray;
    }
}
?>
