<?php

namespace App\Services;

use App\Annotations\Access;
use App\Contracts\BusinessModelService;
use App\Contracts\CrudService;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Primary\Genre;
use App\Transformers\GenreTransformer;
use Symfony;

/**
 * Class GenreService
 * @package App\Services
 */
class GenreService extends BaseService implements CrudService, BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        'name' => 'required|string',
        'active' => 'boolean'
    ];

    /**
     * Retrieve an genre from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws \App\Exceptions\ServiceEntityNotFoundException If no identifier was provided to validate
     * @return array The data returned for the entity
     *
     * @Access(permission="genre-view")
     */
    public function get(array $inputs = [])
    {
        // show "deleted" information to show full history of genre
        if (isset($inputs['showDeleted']) && $inputs['showDeleted'] == 'true') {
            $this->entityManager->getFilters()->disable('soft-deleteable');
        }

        // support lookup by id or label
        if (!isset($inputs['id'])) {
            throw new ServiceEntityNotFoundException('No identifier was provided to find the entity.');
        }

        return $this->loadRepositoryItem(
            Genre::class,
            new RepositoryIdentifier($inputs['id']),
            new GenreTransformer(),
            ['books']
        );
    }

    /**
     * Retrieve all genres
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="genre-view")
     */
    public function getAll(array $inputs = [])
    {
        return $this->loadRepositoryCollection(
            Genre::class,
            new GenreTransformer(),
            [],
            $this->prepareFiltersFromInputs($inputs)
        );
    }

    /**
     * Create a new genre
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     *
     * @Access(permission="genre-create")
     */
    public function create(array $inputs)
    {
        return $this->insert($inputs, new Genre(), new GenreTransformer());
    }

    /**
     * Update an genre with the given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     *
     * @Access(permission="genre-update")
     */
    public function update(array $inputs)
    {
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Genre::class, new RepositoryIdentifier($inputs['id'])),
            new GenreTransformer()
        );
    }

    /**
     * Deletes a given genre
     *
     * @param array $inputs The data provided for the request
     * @return void
     *
     * @Access(permission="genre-delete")
     */
    public function delete(array $inputs)
    {
        $this->expire(
            $this->getEntityFromRepository(Genre::class, new RepositoryIdentifier($inputs['id']))
        );
    }
}
