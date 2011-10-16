<?php
// bootstrap.php

/**
 * Bootstrap Doctrine.php, register autoloader specify
 * configuration attributes and load models.
 */
 
require_once(dirname(__FILE__) . '/../Service/Doctrine.php');
spl_autoload_register(array('Doctrine', 'autoload'));
$manager = Doctrine_Manager::getInstance();

$dsn = 'mysql:dbname=nme2;host=192.168.2.5';
//$dsn = 'mysql:dbname=berndnet2000;host=localhost';
$user = 'nme2';
$password = 'Iox5Do3VVQaXya27ENHA';
//$user = 'root';
//$password = 'extra';

$conn = Doctrine_Manager::connection('mysql://username:password@192.168.2.5/nme2');
//$conn = Doctrine_Manager::connection('mysql://username:password@localhost/berndnet2000');
$conn->setOption('username', $user);
$conn->setOption('password', $password);
// The first time the connection is needed, it is instantiated
// This query triggers the connection to be created
$conn->execute('SHOW TABLES');

Doctrine_Core::loadModels('../Domain/Generated');
Doctrine_Core::loadModels('../Domain');
?>
