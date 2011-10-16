<?php
/**
 * Description of MissionService
 *
 * @author bergziege
 */

require_once '../Settings/bootstrap.php';

class CustomObjectService {
    function GetAllCustomObjectsAsArray() {
        $customObjectArray = array();
        $customObjects = Doctrine_Core::getTable('CustomObject')->findAll();
        foreach ($customObjects as $customObject){
            $customObjectArray[] = $customObject->toArray();
        }
        return $customObjectArray;
    }
}
?>
