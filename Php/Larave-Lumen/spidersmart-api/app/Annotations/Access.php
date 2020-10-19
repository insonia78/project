<?php

namespace App\Annotations;

use Doctrine\Common\Annotations\Annotation;
use Dingo\Api\Http\Request;
use Dingo\Api\Http\Response;
use Symfony\Component\HttpKernel\Exception\AccessDeniedHttpException;

/**
 * Class Access
 * @package App\Annotations
 *
 * @Annotation
 * @Target("METHOD")
 */
class Access
{
    /**
     * @Required
     * @var string|null The permission level required for the associated method
     */
    private $permission;

    /**
     * Initialize annotation actions.
     *
     * @param array $values The annotation arguments
     */
    public function __construct(array $values)
    {
        //$request = Request::capture();
        $this->permission = $values['permission'] ?: null;

        // TODO: Perform validation check here and if fails, throw header - as of now this will throw a 403 if no permission is defined for the action
/*        if (!$request || is_null($this->permission)) {
            throw new AccessDeniedHttpException('Access Forbidden');
        }*/
    }
}
