<?php


/**file createToken.php
 * 
 * the class creates and retruns a random token 
 * 
 *
 * @author thomas
 */
class createToken {

    //put your code here
    private  $tokenFetch;
    private  $tokenAjax;

    public function setRandomTokenFetch($length) {
        $validCharacters = "abcdefghijmnpqrstuxyvw23456789";
        $validCharNumber = strlen($validCharacters);
        $result = "";

        for ($i = 0; $i < $length; $i++) {
            $index = mt_rand(0, $validCharNumber - 1);
            $result .= $validCharacters[$index];
        }

        
    }

    public function setRandomTokenAjax($length) {
        $validCharacters = "abcdefghijmnpqrstuxyvw23456789";
        $validCharNumber = strlen($validCharacters);
        $result = "";

        for ($i = 0; $i < $length; $i++) {
            $index = mt_rand(0, $validCharNumber - 1);
            $result .= $validCharacters[$index];
        }

        
    }

    public function getRandomTokenFetch() {


        return $tokenFetch;
    }

    public static function getRandomTokenAjax() {


        return $tokenAjax;
    }

}
