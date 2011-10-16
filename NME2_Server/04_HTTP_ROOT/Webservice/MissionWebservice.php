<?php
/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

require_once '../Service/MissionService.php';
require_once '../Service/MissionObjectService.php';
require_once '../Service/SimObjectService.php';
require_once '../Service/CustomObjectService.php';

include_once 'WebserviceBase.php';


// Register the method to expose
$server->register('MissionService.GetMissionsWithin',                // method name
    array('lat' => 'xsd:double', 'lon' => 'xsd:double'),        // input parameters
    array('return' => 'tns:Missions'),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#getmission',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Gibt alle relevanten Missionen zurück, in denen sich der Spieler befindet.'            // documentation
);

// Register the method to expose
$server->register('MissionObjectService.GetMissionObjectsForMissions',                // method name
    array('missions' => 'tns:Missions'),        // input parameters
    array('return' => 'tns:MissionObjects'),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#getmissionobjects',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Gibt alle Missions Objekte zu einer Mission zurück.'            // documentation
);

// Register the method to expose
$server->register('MissionObjectService.GetAllMissionObjectsForMissions',                // method name
    array('missions' => 'tns:Missions'),        // input parameters
    array('return' => 'tns:MissionObjects'),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#getallmissionobjects',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Gibt alle Missions Objekte zu einer Mission zurück.'            // documentation
);

$server->register('MissionService.GetAllMissionsAsArray',                // method name
    array(),        // input parameters
    array('return' => 'tns:Missions'),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#getallmissions',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Liefert alle auf dem Server verfügbaren Missionen.'            // documentation
);

$server->register('SimObjectService.GetAllSimObjectsAsArray',                // method name
    array(),        // input parameters
    array('return' => 'tns:SimObjects'),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#getallsimobjects',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Liefert alle auf dem Server verfügbaren SimObjects.'            // documentation
);

$server->register('CustomObjectService.GetAllCustomObjectsAsArray',                // method name
    array(),        // input parameters
    array('return' => 'tns:CustomObjects'),      // output parameters
    'urn:nme2',                      // namespace
    'urn:nme2#getallcustomobjects',                // soapaction
    'rpc',                                // style
    'encoded',                            // use
    'Liefert alle auf dem Server verfügbaren Benutzerobjekte.'            // documentation
);

// Use the request to (try to) invoke the service
$HTTP_RAW_POST_DATA = isset($HTTP_RAW_POST_DATA) ? $HTTP_RAW_POST_DATA : '';
$server->service($HTTP_RAW_POST_DATA);


?>
