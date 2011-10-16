<?php

$tpl = new tpl('tpl/impressum.tpl', '{', '}');

//$tpl->set('LinkList', $LinkList);

if(!$tpl->checkError())
	$tpl->out();
	
?>