<?php
/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
*/

// Pull in the NuSOAP code
require_once('../NuSoap/nusoap.php');
//ini_set("soap.wsdl_cache_enabled", "0");

// Create the server instance
$server = new soap_server();

$server->configureWSDL("Nme2Ws");

// Single Mission
$server->wsdl->addComplexType(
        'Mission',
        'complexeType',
        'struct',
        'all',
        '',
        array(
        'Id' => array('name' => 'Id', 'type' => 'xsd:int'),
        'Name' => array('name' => 'Name', 'type' => 'xsd:string'),
        'Version' => array('name' => 'Version', 'type' => 'xsd:string'),
        'CenterLat' => array('name' => 'CenterLat', 'type' => 'xsd:double'),
        'CenterLon' => array('name' => 'CenterLon', 'type' => 'xsd:double'),
        'MissionRange' => array('name' => 'MissionRange', 'type' => 'xsd:int'),
        'Active' => array('name' => 'Active', 'type' => 'xsd:int')
        )
);

// Array von Missionen
$server->wsdl->addComplexType(
        'Missions',
        'complexType',
        'array',
        '',
        'SOAP-ENC:Array',
        array(),
        array(
        array('ref' => 'SOAP-ENC:arrayType',
                'wsdl:arrayType' => 'tns:Mission[]')
        ),
        'tns:Mission'
);

// Single SimObject
$server->wsdl->addComplexType(
        'SimObject',
        'complexeType',
        'struct',
        'all',
        '',
        array(
        'Id' => array('name' => 'Id', 'type' => 'xsd:int'),
        'Name' => array('name' => 'Name', 'type' => 'xsd:string'),
        'SimName' => array('name' => 'SimName', 'type' => 'xsd:string')
        )
);


// Array von Sim Objects
$server->wsdl->addComplexType(
        'SimObjects',
        'complexType',
        'array',
        '',
        'SOAP-ENC:Array',
        array(),
        array(
        array('ref' => 'SOAP-ENC:arrayType',
                'wsdl:arrayType' => 'tns:SimObject[]')
        ),
        'tns:SimObject'
);

//        
//        
// Single Mission Object
$server->wsdl->addComplexType(
        'MissionObject',
        'complexeType',
        'struct',
        'all',
        '',
        array(
        'Id' => array('name' => 'Id', 'type' => 'xsd:int'),
        'Mission_Id' => array('name' => 'Mission_Id', 'type' => 'xsd:int'),
        'Mission' => array('name' => 'Mission', 'type' => 'tns:Mission'),
        'SimObject_Id' => array('name' => 'SimObject_Id', 'type' => 'xsd:int'),
        'Simobject' => array('name' => 'SimObject', 'type' => 'tns:SimObject'),
        'Lat' => array('name' => 'Lat', 'type' => 'xsd:double'),
        'Lon' => array('name' => 'Lon', 'type' => 'xsd:double'),
        'Altitude' => array('name' => 'Altitude', 'type' => 'xsd:float'),
        'OnGround' => array('name' => 'OnGround', 'type' => 'xsd:int'),
        'Pitch' => array('name' => 'Pitch', 'type' => 'xsd:double'),
        'Yaw' => array('name' => 'Yaw', 'type' => 'xsd:double'),
        'Bank' => array('name' => 'Bank', 'type' => 'xsd:double'),
        'Heading' => array('name' => 'Heading', 'type' => 'xsd:int'),
        'Active' => array('name' => 'Active', 'type' => 'xsd:int')
        )
);

// Array von Mission Objects
$server->wsdl->addComplexType(
        'MissionObjects',
        'complexType',
        'array',
        '',
        'SOAP-ENC:Array',
        array(),
        array(
        array('ref' => 'SOAP-ENC:arrayType',
                'wsdl:arrayType' => 'tns:MissionObject[]')
        ),
        'tns:MissionObject'
);

// Single Mission Object
$server->wsdl->addComplexType(
        'CustomObject',
        'complexeType',
        'struct',
        'all',
        '',
        array(
        'Id' => array('name' => 'Id', 'type' => 'xsd:int'),
        'Version' => array('name' => 'Version', 'type' => 'xsd:string'),
        'DownloadPath' => array('name' => 'DownloadPath', 'type' => 'xsd:string'),
        'Description' => array('name' => 'Description', 'type' => 'xsd:string')
        )
);

// Array von Mission Objects
$server->wsdl->addComplexType(
        'CustomObjects',
        'complexType',
        'array',
        '',
        'SOAP-ENC:Array',
        array(),
        array(
        array('ref' => 'SOAP-ENC:arrayType',
                'wsdl:arrayType' => 'tns:CustomObject[]')
        ),
        'tns:CustomObject'
);
?>
