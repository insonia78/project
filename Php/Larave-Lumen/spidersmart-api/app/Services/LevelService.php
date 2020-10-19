<?php

namespace App\Services;

use App\Annotations\Access;
use App\Contracts\BusinessModelService;
use App\Contracts\CrudService;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Primary\Level;
use App\Transformers\LevelTransformer;
use Symfony;

/**
 * Class LevelService
 * @package App\Services
 */
class LevelService extends BaseService implements BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        'name' => 'required|string',
        'description' => 'string',
        'active' => 'int'
    ];

    /**
     * @inheritDoc
     */
    protected $createRelationships = [
        'subjects' => \App\Services\SubjectService::class,
        'books' => \App\Services\BookService::class
    ];

    /**
     * @inheritDoc
     */
    protected $listTransformations = [
        'subject', 'books'
    ];

    /**
     * @inheritDoc
     */
    protected $retrieveTransformations = [
        'subject', 'books'
    ];

    /**
     * Retrieve a level from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws \App\Exceptions\ServiceEntityNotFoundException If no identifier was provided to validate
     * @return array The data returned for the entity
     *
     * @Access(permission="level-view")
     */
    public function get(array $inputs = [])
    {
        // show "deleted" information to show full history of level
        if (isset($inputs['showDeleted']) && $inputs['showDeleted'] == 'true') {
            $this->entityManager->getFilters()->disable('soft-deleteable');
        }

        // support lookup by id
        if (!isset($inputs['id'])) {
            throw new ServiceEntityNotFoundException('No identifier was provided to find the entity.');
        }
        $identifier = (isset($inputs['id'])) ? new RepositoryIdentifier($inputs['id']) : new RepositoryIdentifier($inputs['name'], 'name', FILTER_SANITIZE_STRING);

        return $this->loadRepositoryItem(
            Level::class,
            $identifier,
            new LevelTransformer(),
            ['subject', 'books']
        );
    }

    /**
     * Retrieve all levels
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="level-view")
     */
    public function getAll(array $inputs = [])
    {
        return $this->loadRepositoryCollection(
            Level::class,
            new LevelTransformer(),
            ['subject'],
            $this->prepareFiltersFromInputs($inputs)
        );
    }

    /**
     * Create a new level
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     *
     * @Access(permission="level-create")
     */
    public function create(array $inputs)
    {
        return $this->insert(
            $inputs,
            new Level(),
            new LevelTransformer()
        );
    }

    /**
     * Update a level with the given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     *
     * @Access(permission="level-update")
     */
    public function update(array $inputs)
    {
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Level::class, new RepositoryIdentifier($inputs['id'])),
            new LevelTransformer()
        );
    }

    /**
     * Deletes a given level
     *
     * @param array $inputs The data provided for the request
     * @return void
     *
     * @Access(permission="level-delete")
     */
    public function delete(array $inputs)
    {
        $this->expire(
            $this->getEntityFromRepository(Level::class, new RepositoryIdentifier($inputs['id']))
        );
    }
}
