<?php
/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
*/

/**
 * Description of AdminMissionService
 *
 * @author bergziege
 */
require_once '../Service/MissionObjectService.php';
require_once 'sec.php';
class AdminMissionObjectService extends MissionObjectService {
    function SaveArrayMissionObject($missionObject, $user, $pwd) {
        $secinfo = new SecInfo();
        if ($user != $secinfo->sec_user || $pwd != $secinfo->sec_pwd) return null;
        $existing = Doctrine_Core::getTable('MissionObject')->findOneBy('Id', $missionObject['Id']);
        if ($existing == null) $existing = new MissionObject();
        $existing->fromArray($missionObject);
        $existing->save();
        return $existing->toArray();
    }

    function DeleteArrayMissionObject($missionObject, $user, $pwd) {
        $secinfo = new SecInfo();
        if ($user != $secinfo->sec_user || $pwd != $secinfo->sec_pwd) return null;
        $existing = Doctrine_Core::getTable('MissionObject')->findOneBy('Id', $missionObject['Id']);
        if ($existing)
            $existing->delete();
    }
}
?>
