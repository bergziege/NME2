<?php
/**
 * Description of MissionService
 *
 * @author bergziege
 */

require_once '../Settings/bootstrap.php';

class SimObjectService {

    function GetAllSimObjectsAsArray(){
        $simObjectArray = array();
        $simObjects = Doctrine_Core::getTable("SimObject")->findAll();
        foreach ($simObjects as $simObject){
            $simObjectArray[] = $simObject->toArray();
        }
        return $simObjectArray;
    }
}
?>
