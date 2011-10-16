<?php
require('../lib/nusoap.php');
require_once('AuthenticationService.php');
require_once('Watchdog.php');
require_once('HuruFaq.php');

ini_set("soap.wsdl_cache_enabled", "0");

$s = new soap_server();
$s->configureWSDL("WizardWebservices");

$s->register(   // method name:
                'AuthenticationService.CheckUser', 		 
                // parameter list:
                array('loginname'=>'xsd:string'), 
                // return value(s):
                array('result'=>'xsd:string'),
                // namespace:
				'de.wizard-va.webservices',
                // soapaction: (use default)
                false,
                // style: rpc or document
                'rpc',
                // use: encoded or literal
                'encoded',
                // description: documentation for the method
                'IN: User loginname; OUT: Salt or errorcode.');
				
$s->register(   // method name:
                'AuthenticationService.CheckPwd', 		 
                // parameter list:
                array('saltedMd5'=>'xsd:string', 'loginname'=>'xsd:string'), 
                // return value(s):
                array('result'=>'xsd:string'),
                // namespace:
				'de.wizard-va.webservices',
                // soapaction: (use default)
                false,
                // style: rpc or document
                'rpc',
                // use: encoded or literal
                'encoded',
                // description: documentation for the method
                'IN: Salted md5, User loginname; OUT: Session id or errorcode.');
				
$s->register(   // method name:
                'Watchdog.Bark', 		 
                // parameter list:
                array('sessionId'=>'xsd:string'), 
                // return value(s):
                array('result'=>'xsd:string'),
                // namespace:
				'de.wizard-va.webservices',
                // soapaction: (use default)
                false,
                // style: rpc or document
                'rpc',
                // use: encoded or literal
                'encoded',
                // description: documentation for the method
                'IN: SessionId; OUT: true or errorcode.');
$POST_DATA = isset($GLOBALS['HTTP_RAW_POST_DATA']) 
                ? $GLOBALS['HTTP_RAW_POST_DATA'] : '';

// pass our posted data (or nothing) to the soap service                    
$s->service($POST_DATA);
?>