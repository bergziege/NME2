<?php
/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of SecService
 *
 * @author bergziege
 */
require_once 'sec.php';

class SecService {
    //put your code here
    function CheckAuth($user, $pwd){
        $secinfo = new SecInfo();
        if ($user != $secinfo->sec_user || $pwd != $secinfo->sec_pwd)return 0;
        else return 1;
    }
}
?>
