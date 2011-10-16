<?php

require_once 'AdminMissionService.php';
require_once 'AdminMissionObjectService.php';
require_once 'SecService.php';


include_once '../Webservice/WebserviceBase.php';

// Register the method to expose
$server->register('SecService.CheckAuth',                // method name
    array('user'=>'xsd:string', 'pwd' => 'xsd:string'),        // input parameters
    array('return' => 'xsd:integer'),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#checkauth',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Prüft Authorisierung.'            // documentation
);

// Register the method to expose
$server->register('AdminMissionService.SaveArrayMission',                // method name
    array('mission' => 'tns:Mission', 'user'=>'xsd:string', 'pwd' => 'xsd:string'),        // input parameters
    array('return' => 'tns:Mission'),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#savearraymission',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Speichert eine Mission.'            // documentation
);

// Register the method to expose
$server->register('AdminMissionService.DeleteArrayMission',                // method name
    array('mission' => 'tns:Mission', 'user'=>'xsd:string', 'pwd' => 'xsd:string'),        // input parameters
    array(),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#deletearraymission',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Löscht eine Mission.'            // documentation
);

// Register the method to expose
$server->register('AdminMissionObjectService.SaveArrayMissionObject',                // method name
    array('missionObject' => 'tns:MissionObject', 'user'=>'xsd:string', 'pwd' => 'xsd:string'),        // input parameters
    array('return' => 'tns:Mission'),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#savearraymissionobject',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Speichert ein Mission Object.'            // documentation
);

// Register the method to expose
$server->register('AdminMissionObjectService.DeleteArrayMissionObject',                // method name
    array('missionObject' => 'tns:MissionObject', 'user'=>'xsd:string', 'pwd' => 'xsd:string'),        // input parameters
    array(),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#deletearraymissionobject',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Löscht ein Mission Object.'            // documentation
);

// Use the request to (try to) invoke the service
$HTTP_RAW_POST_DATA = isset($HTTP_RAW_POST_DATA) ? $HTTP_RAW_POST_DATA : '';
$server->service($HTTP_RAW_POST_DATA);
?>
