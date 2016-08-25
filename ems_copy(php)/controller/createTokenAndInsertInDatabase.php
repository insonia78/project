<?php

/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

$createToken = new createToken();
$db = performQueryToDataBase();

$createToken.setRandomToken(4);

$token = $createToken->getRandomTokenFetch();

$db->insertTokenToDataBase($token);