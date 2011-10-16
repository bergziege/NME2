<?php
/**
 * Description of MissionService
 *
 * @author bergziege
 */

require_once '../Settings/bootstrap.php';

class MissionObjectService {
    public function GetMissionObjectsForMissions($missions) {
        $missionObjectsQuery = Doctrine_Query::create()->from("Missionobject mo");
        $missionObjectsQuery->leftJoin("mo.Mission m");
        $missionObjectsQuery->leftJoin("mo.Simobject s");
        foreach ($missions as $mission) {
            $missionObjectsQuery->orWhere("Mission_Id = ?", $mission['Id']);
        }
        $missionObjects = $missionObjectsQuery->execute();
        $result = array();
        foreach ($missionObjects as $missionObject) {
            if ($missionObject['Active'] == 1)
                $result[] = $missionObject->toArray(true);
        }
        //print_r($result);
        return $result;
    }

    function GetAllMissionObjectsForMissions($missions) {
        $missionObjectsQuery = Doctrine_Query::create()->from("Missionobject mo");
        $missionObjectsQuery->leftJoin("mo.Mission m");
        $missionObjectsQuery->leftJoin("mo.Simobject s");
        foreach ($missions as $mission) {
            $missionObjectsQuery->orWhere("Mission_Id = ?", $mission['Id']);
        }
        $missionObjects = $missionObjectsQuery->execute();
        $result = array();
        foreach ($missionObjects as $missionObject) {
            $result[] = $missionObject->toArray(true);
        }
        //print_r($result);
        return $result;
    }

    function GetMissionsObjectsForMissionNonArray($mission) {
        $missionObjectsQuery = Doctrine_Query::create()->from("Missionobject mo");
        $missionObjectsQuery->leftJoin("mo.Mission m");
        $missionObjectsQuery->leftJoin("mo.Simobject s");
        foreach ($missions as $mission) {
            $missionObjectsQuery->orWhere("Mission_Id = ?", $mission['Id']);
        }
        $missionObjects = $missionObjectsQuery->execute();
        $result = array();
        foreach ($missionObjects as $missionObject) {
            if ($missionObject['Active'] == 1)
                $result[] = $missionObject;
        }
        //print_r($result);
        return $result;
    }
}
?>
