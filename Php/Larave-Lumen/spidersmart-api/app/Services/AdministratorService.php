<?php

namespace App\Services;

use App\Annotations\Access;
use App\Models\Entities\Primary\Administrator;
use App\Transformers\UserTransformer;

/**
 * Class AdministratorService
 * @package App\Services
 */
class AdministratorService extends UserService
{
    /**
     * Retrieve all administrator
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="administrator-view")
     */
    public function getAll(array $inputs = [])
    {
        return $this->loadRepositoryCollection(
            Administrator::class,
            new UserTransformer(),
            ['addresses', /*'roles', 'roles.permissions',*/ 'contacts'],
            $this->prepareFiltersFromInputs($inputs)
        );
    }
}
