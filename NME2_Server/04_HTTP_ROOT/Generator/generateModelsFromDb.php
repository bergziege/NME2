<?php
require_once '../Settings/bootstrap.php';
Doctrine_Core::generateModelsFromDb('../Domain', array('doctrine'), array('generateTableClasses' => true));
?>
