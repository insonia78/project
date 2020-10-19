<?php

namespace App\Services;

use App\Annotations\Access;
use App\Contracts\BusinessModelService;
use App\Contracts\CrudService;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Primary\Author;
use App\Transformers\AuthorTransformer;
use Symfony;

/**
 * Class AuthorService
 * @package App\Services
 */
class AuthorService extends BaseService implements CrudService, BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        'name' => 'required|string',
        'active' => 'boolean'
    ];

    /**
     * Retrieve an author from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws \App\Exceptions\ServiceEntityNotFoundException If no identifier was provided to validate
     * @return array The data returned for the entity
     *
     * @Access(permission="author-view")
     */
    public function get(array $inputs = [])
    {
        // show "deleted" information to show full history of author
        if (isset($inputs['showDeleted']) && $inputs['showDeleted'] == 'true') {
            $this->entityManager->getFilters()->disable('soft-deleteable');
        }

        // ensure there is an id
        if (!isset($inputs['id'])) {
            throw new ServiceEntityNotFoundException('No identifier was provided to find the entity.');
        }

        return $this->loadRepositoryItem(
            Author::class,
            new RepositoryIdentifier($inputs['id']),
            new AuthorTransformer(),
            ['books']
        );
    }

    /**
     * Retrieve all authors
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="author-view")
     */
    public function getAll(array $inputs = [])
    {
        return $this->loadRepositoryCollection(
            Author::class,
            new AuthorTransformer(),
            [],
            $this->prepareFiltersFromInputs($inputs)
        );
    }

    /**
     * Create a new author
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     *
     * @Access(permission="author-create")
     */
    public function create(array $inputs)
    {
        return $this->insert($inputs, new Author(), new AuthorTransformer());
    }

    /**
     * Update an author with the given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     *
     * @Access(permission="author-update")
     */
    public function update(array $inputs)
    {
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Author::class, new RepositoryIdentifier($inputs['id'])),
            new AuthorTransformer()
        );
    }

    /**
     * Deletes a given author
     *
     * @param array $inputs The data provided for the request
     * @return void
     *
     * @Access(permission="author-delete")
     */
    public function delete(array $inputs)
    {
        $this->expire(
            $this->getEntityFromRepository(Author::class, new RepositoryIdentifier($inputs['id']))
        );
    }
}
