<?php

include_once 'header.php';

$contentLeft ="&nbsp;";
$contentRight="<p>Download des aktuellen NME Client. Seperater Download einer auf diesen Server zugeschnittenen Config</p>";

$tpl->set("ContentLeft",$contentLeft);
$tpl->set("ContentRight", $contentRight);

include_once 'footer.php';

?>