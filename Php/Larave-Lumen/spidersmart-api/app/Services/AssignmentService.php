<?php

namespace App\Services;

use App\Annotations\Access;
use App\Contracts\BusinessModelService;
use App\Contracts\CrudService;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Primary\Assignment;
use App\Transformers\AssignmentTransformer;
use Symfony;

/**
 * Class AssignmentService
 * @package App\Services
 */
class AssignmentService extends BaseService implements CrudService, BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        'title' => 'required|string',
        'description' => 'required|string'
    ];

    /**
     * @inheritDoc
     */
    protected $createRelationships = [
//        'questions' => \App\Services\QuestionService::class,
        'sections' => \App\Services\AssignmentSectionService::class
    ];

    /**
     * Retrieve a assignment from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws \App\Exceptions\ServiceEntityNotFoundException If no identifier was provided to validate
     * @return array The data returned for the entity
     *
     * @Access(permission="assignment-view")
     */
    public function get(array $inputs = [])
    {
        // show "deleted" information to show full history of assignment
        if (isset($inputs['showDeleted']) && $inputs['showDeleted'] == 'true') {
            $this->entityManager->getFilters()->disable('soft-deleteable');
        }

        // support lookup by id
        if (!isset($inputs['id'])) {
            throw new ServiceEntityNotFoundException('No identifier was provided to find the entity.');
        }
        $identifier = (isset($inputs['id'])) ? new RepositoryIdentifier($inputs['id']) : new RepositoryIdentifier($inputs['title'], 'title', FILTER_SANITIZE_STRING);

        return $this->loadRepositoryItem(
            Assignment::class,
            $identifier,
            new AssignmentTransformer(),
            ['questions', 'sections', 'sections.questions', 'sections.questions.answers', 'level', 'level.subject', 'book']
        );
    }

    /**
     * Retrieve all assignments
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="assignment-view")
     */
    public function getAll(array $inputs = [])
    {
        return $this->loadRepositoryCollection(
            Assignment::class,
            new AssignmentTransformer(),
            [],
            $this->prepareFiltersFromInputs($inputs)
        );
    }

    /**
     * Create a new assignment
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     *
     * @Access(permission="assignment-create")
     */
    public function create(array $inputs)
    {
        return $this->insert(
            $inputs,
            new Assignment(),
            new AssignmentTransformer()
        );
    }

    /**
     * Update a assignment with the given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity
     *
     * @Access(permission="assignment-update")
     */
    public function update(array $inputs)
    {
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Assignment::class, new RepositoryIdentifier($inputs['id'])),
            new AssignmentTransformer()
        );
    }

    /**
     * Deletes a given assignment
     *
     * @param array $inputs The data provided for the request
     * @return void
     *
     * @Access(permission="assignment-delete")
     */
    public function delete(array $inputs)
    {
        $this->expire(
            $this->getEntityFromRepository(Assignment::class, new RepositoryIdentifier($inputs['id']))
        );
    }
}
