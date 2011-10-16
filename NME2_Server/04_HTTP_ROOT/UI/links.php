<?php

$tpl = new tpl('tpl/links.tpl', '{', '}');

//$tpl->set('LinkList', $LinkList);

if(!$tpl->checkError())
	$tpl->out();
	
?>