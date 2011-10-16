<?php
/* Übernommen von :  www.designnation.com */
class tpl
{
	var $_delStart;
	var $_delEnd;
	var $_content = '';
	var $_error = '';
	
	 function tpl($file = '', $delStart = '{', $delEnd = '}')
	{
		$this->_delStart = $delStart;
		$this->_delEnd = $delEnd;
		
		if(!$file) {
			$this->_error.= '<br />No template file has been assigned. Please assign a templatefile to use this function.';
		}
		else {
			if(!is_readable($file)) {
				$this->_error.= '<br />The assigned file could not be read. Please ensure the correct rights are set on the server.';
			}
			else {
				$tmp = fopen($file, 'r');
				while(!feof($tmp)) {
					$this->_content.= fgets($tmp, 4096);
				}
				fclose($tmp);
			}
		}
	}
	
	function set($char='', $value='')
	{
		if(!$char) {
			$this->_error.= '<br />There is one ocasion where a value for no given placeholder exists.';
		}
		else {
			$this->_content = str_replace($this->_delStart.$char.$this->_delEnd, $value, $this->_content);
		}
	}
	
	function out()
	{
		echo($this->_content);
	}

        function outAsString(){
            return $this->_content;
        }
	
	function checkError()
	{
		return (bool)$this->_error;
	}
	
	function printError ()
	{
		if($this->checkError()) {
			$str = "<p>\n";
			$str.= " ERROR: <br />\n";
			$str.= ' '.$this->_error."\n";
			$str.= "</p>\n";
			echo($str);
		}
		else {
		$str = "<p>\n";
		$str.= " SUCCESS: The file has successfulle been replaced with all templates.\n";
		$str.= "</p>\n";
		echo($str);
		}
	}
}
?>