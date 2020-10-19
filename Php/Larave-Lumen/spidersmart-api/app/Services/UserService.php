<?php

namespace App\Services;

use App\Annotations\Access;
use App\Contracts\BusinessModelService;
use App\Contracts\CrudService;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Primary\User;
use App\Transformers\UserTransformer;

/**
 * Class UserService
 * @package App\Services
 */
class UserService extends BaseService implements CrudService, BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        //'type' => 'required|in:user,administrator,director,teacher,student,guardian',
        'prefix' => 'alpha|nullable',
        'firstName' => 'alpha|required',
        'middleName' => 'alpha|nullable',
        'lastName' => 'alpha|required',
        'suffix' => 'alpha|nullable'
    ];

    /**
     * @inheritDoc
     */
    protected $createRelationships = [
        'addresses' => \App\Services\UserAddressService::class,
        'contacts' => \App\Services\UserContactService::class,
        'enrollments' => \App\Services\EnrollmentService::class
    ];

    /**
     * @inheritDoc
     */
    protected $filterCriteria = [
        'center' => 'criteriaCenter'
    ];

    /**
     * @inheritDoc
     */
    protected $listTransformations = [
        'addresses', 'contacts'
    ];

    /**
     * @inheritDoc
     */
    protected $retrieveTransformations = [
        'addresses', 'enrollments', 'enrollments.center', 'enrollments.level', 'enrollments.level.subject', 'contacts'
    ];

    /**
     * Retrieve a user from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws \App\Exceptions\ServiceEntityNotFoundException If no identifier was provided to validate
     * @return array The data returned for the entity
     *
     * @Access(permission="user-view")
     */
    public function get(array $inputs = [])
    {
        // show "deleted" information to show full history of center
        if (isset($inputs['showDeleted']) && $inputs['showDeleted'] == 'true') {
            $this->entityManager->getFilters()->disable('soft-deleteable');
        }

        // support lookup by id or label
        if (!isset($inputs['id'])) {
            throw new ServiceEntityNotFoundException('No identifier was provided to find the entity.');
        }

        // $this->validateIdentifier($identifier);
        return $this->loadRepositoryItem(
            User::class,
            new RepositoryIdentifier($inputs['id']),
            new UserTransformer()
        );
    }

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
            User::class,
            new UserTransformer(),
            $this->prepareFiltersFromInputs($inputs)
        );
    }

    /**
     * Create a new user
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     *
     * @Access(permission="user-create")
     */
    public function create(array $inputs)
    {
        return $this->insert(
            $inputs,
            new User(),
            new UserTransformer()
        );
    }

    /**
     * Updates a user with given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     *
     * @Access(permission="user-update")
     */
    public function update(array $inputs)
    {
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(User::class, new RepositoryIdentifier($inputs['id'])),
            new UserTransformer()
        );
    }

    /**
     * Deletes a given user
     *
     * @param array $inputs The data provided for the request
     *
     * @return void
     * @Access(permission="user-delete")
     */
    public function delete(array $inputs)
    {
        $this->expire(
            $this->getEntityFromRepository(User::class, new RepositoryIdentifier($inputs['id']))
        );
    }

    /**
     * Adds a user contact to a given user
     *
     * @param array $inputs The data provided for the request
     *
     * @return void
     *
     * @Access(permission="user-update")
     */
//    public function addContact(array $inputs)
//    {
//    }
}
