<?php

namespace App\Services;

use App\Annotations\Access;
use App\Models\Entities\Primary\Director;
use App\Transformers\UserTransformer;

/**
 * Class DirectorService
 * @package App\Services
 */
class DirectorService extends UserService
{
    /**
     * Retrieve all users
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="user-view")
     */
    public function getAll(array $inputs = [])
    {
        return $this->loadRepositoryCollection(
            Director::class,
            new UserTransformer(),
            ['addresses', /*'roles', 'roles.permissions',*/ 'contacts'],
            $this->prepareFiltersFromInputs($inputs)
        );
    }
}
