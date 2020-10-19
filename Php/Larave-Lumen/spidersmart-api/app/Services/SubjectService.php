<?php

namespace App\Services;

use App\Contracts\BusinessModelService;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Primary\Subject;
use App\Transformers\SubjectTransformer;
use Symfony;

class SubjectService extends BaseService implements BusinessModelService
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
        'level' => \App\Services\LevelService::class,
       
    ];

     /**
     * Retrieve a subject from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws \App\Exceptions\ServiceEntityNotFoundException If no identifier was provided to validate
     * @return array The data returned for the entity
     */
    public function get(array $inputs = [])
    {
        // show "deleted" information to show full history of subject
        if (isset($inputs['showDeleted']) && $inputs['showDeleted'] == 'true') {
            $this->entityManager->getFilters()->disable('soft-deleteable');
        }

        // support lookup by id or label
        if (!isset($inputs['id'])) {
            throw new ServiceEntityNotFoundException('No identifier was provided to find the entity.');
        }

        // $this->validateIdentifier($identifier);
        return $this->loadRepositoryItem(
            Subject::class,
            new RepositoryIdentifier($inputs['id']),
            new SubjectTransformer()
        );
    }

     /**
     * Retrieve all subjects
     *
     * @return array An array of returned entities
     */
    public function getAll()
    {
        return $this->loadRepositoryCollection(
            Subject::class,
            new SubjectTransformer()
        );
    }


       /**
     * Create a new subject
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     */
    public function create(array $inputs)
    {
        return $this->insert(
            $inputs,
            new Subject(),
            new SubjectTransformer()
        );
    }

      /**
     * Updates a subject with given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     */
    public function update(array $inputs)
    {
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Subject::class, new RepositoryIdentifier($inputs['id'])),
            new SubjectTransformer()
        );
    }

     /**
     * Deletes a given subject
     *
     * @param array $inputs The data provided for the request
     * @return void
     */
    public function delete(array $inputs)
    {
        $this->expire(
            $this->getEntityFromRepository(Subject::class, new RepositoryIdentifier($inputs['id']))
        );
    }
}
