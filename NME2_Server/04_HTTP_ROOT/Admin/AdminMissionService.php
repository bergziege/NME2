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
require_once '../Service/MissionService.php';
require_once 'sec.php';
class AdminMissionService extends MissionService {

    function SaveArrayMission($mission, $user, $pwd) {
        $secinfo = new SecInfo();
        if ($user != $secinfo->sec_user || $pwd != $secinfo->sec_pwd) return null;
        $existing = Doctrine_Core::getTable('Mission')->findOneBy('Id', $mission['Id']);
        if ($existing == null) $existing = new Mission();
        $existing->fromArray($mission);
        $existing['Version'] = date('YmdHis');
        $existing->save();
        return $existing->toArray();
    }

    function DeleteArrayMission($mission, $user, $pwd) {
        $secinfo = new SecInfo();
        if ($user != $secinfo->sec_user || $pwd != $secinfo->sec_pwd) return null;
        $existing = Doctrine_Core::getTable('Mission')->findOneBy('Id', $mission['Id']);
        $existingMissionObjects = Doctrine_Core::getTable('MissionObject')->findBy('Mission_Id', $mission['Id']);
        foreach($existingMissionObjects as $missionObject){
            $missionObject->delete();
        }
        $existing->delete();
    }
}
?>
