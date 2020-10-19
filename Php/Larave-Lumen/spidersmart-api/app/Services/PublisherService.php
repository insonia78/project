<?php

namespace App\Services;

use App\Annotations\Access;
use App\Contracts\BusinessModelService;
use App\Contracts\CrudService;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Primary\Publisher;
use App\Transformers\PublisherTransformer;
use Symfony;

/**
 * Class PublisherService
 * @package App\Services
 */
class PublisherService extends BaseService implements CrudService, BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        'name' => 'required|string',
        'active' => 'boolean'
    ];

    /**
     * Retrieve an publisher from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws \App\Exceptions\ServiceEntityNotFoundException If no identifier was provided to validate
     * @return array The data returned for the entity
     *
     * @Access(permission="publisher-view")
     */
    public function get(array $inputs = [])
    {
        // show "deleted" information to show full history of publisher
        if (isset($inputs['showDeleted']) && $inputs['showDeleted'] == 'true') {
            $this->entityManager->getFilters()->disable('soft-deleteable');
        }

        // support lookup by id or label
        if (!isset($inputs['id'])) {
            throw new ServiceEntityNotFoundException('No identifier was provided to find the entity.');
        }

        return $this->loadRepositoryItem(
            Publisher::class,
            new RepositoryIdentifier($inputs['id']),
            new PublisherTransformer(),
            ['books']
        );
    }

    /**
     * Retrieve all publishers
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="publisher-view")
     */
    public function getAll(array $inputs = [])
    {
        return $this->loadRepositoryCollection(
            Publisher::class,
            new PublisherTransformer(),
            [],
            $this->prepareFiltersFromInputs($inputs)
        );
    }

    /**
     * Create a new publisher
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     *
     * @Access(permission="publisher-create")
     */
    public function create(array $inputs)
    {
        return $this->insert($inputs, new Publisher(), new PublisherTransformer());
    }

    /**
     * Update an publisher with the given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     *
     * @Access(permission="publisher-update")
     */
    public function update(array $inputs)
    {
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Publisher::class, new RepositoryIdentifier($inputs['id'])),
            new PublisherTransformer()
        );
    }

    /**
     * Deletes a given publisher
     *
     * @param array $inputs The data provided for the request
     * @return void
     *
     * @Access(permission="publisher-delete")
     */
    public function delete(array $inputs)
    {
        $this->expire(
            $this->getEntityFromRepository(Publisher::class, new RepositoryIdentifier($inputs['id']))
        );
    }
}
