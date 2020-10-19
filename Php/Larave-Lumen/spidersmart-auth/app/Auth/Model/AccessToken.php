<?php
namespace App\Auth\Model;

use Laravel\Passport\Bridge\AccessToken as PassportAccessToken;
use Lcobucci\JWT\Builder;
use Lcobucci\JWT\Signer\Key;
use Lcobucci\JWT\Signer\Rsa\Sha256;
use League\OAuth2\Server\CryptKey;
use Illuminate\Support\Facades\DB;

class AccessToken extends PassportAccessToken {
    
        
    private $privateKey;

	/**
	 * Generate a string representation from the access token
	 */
	public function __toString() {
		return (string) $this->convertToJWT( $this->privateKey );
	}
    public function getPrm()
    {
        try
        {
            
            $response = DB::select('SELECT p.title from permission as p where id = ( SELECT r.permission_id from role_permission AS r   
                                   where role_id = (SELECT u.role_id from user_role AS u WHERE u.user_id='.$this->getUserIdentifier().'))');
             return $response[0];                          
             
        }catch(\Exception $e)
        { 
           return  response("Internal server Error", 500);
        }        
    } 
	/**
	 * Set the private key used to encrypt this access token.
	 */
	public function setPrivateKey( CryptKey $privateKey ) {
		$this->privateKey = $privateKey;
	}

	public function convertToJWT( CryptKey $privateKey ) {

        return (new Builder())
            ->setAudience($this->getClient()->getIdentifier())
            ->setId($this->getIdentifier(), true)
            ->setIssuedAt(time())
            ->setNotBefore(time())
            ->setExpiration($this->getExpiryDateTime()->getTimestamp())
            ->setSubject($this->getUserIdentifier())
            ->set('prm',$this->getPrm()) 
            ->set('scopes', $this->getScopes())           
            ->sign(new Sha256(), new Key($privateKey->getKeyPath(), $privateKey->getPassPhrase()))
            ->getToken();en( new Sha256(), new Key( $privateKey->getKeyPath(), $privateKey->getPassPhrase() ) );
	}    
}