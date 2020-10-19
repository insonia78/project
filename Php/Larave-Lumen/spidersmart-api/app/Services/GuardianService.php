<?php

namespace App\Services;

use App\Annotations\Access;
use App\Models\Entities\Primary\Guardian;
use App\Transformers\UserTransformer;

/**
 * Class GuardianService
 * @package App\Services
 */
class GuardianService extends UserService
{
    /**
     * Retrieve all guardians
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="guardian-view")
     */
    public function getAll(array $inputs = [])
    {
        return $this->loadRepositoryCollection(
            Guardian::class,
            new UserTransformer(),
            ['addresses', /*'roles', 'roles.permissions',*/ 'contacts'],
            $this->prepareFiltersFromInputs($inputs)
        );
    }
}
