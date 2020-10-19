<?php

namespace App\Services;

use App\Contracts\BusinessModelService;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Secondary\Question;
use App\Transformers\QuestionTransformer;
use Symfony;

/**
 * Class QuestionService
 * @package App\Services
 */
class QuestionService extends BaseService implements BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        'type' => 'required|string',
        'question' => 'required|string',
        //'answer' => 'required|string',
    ];

    /**
     * @inheritDoc
     */
    protected $createRelationships = [
//        'categories' => \App\Services\QuestionCategoryService::class,
        'answers' => \App\Services\QuestionAnswerService::class
    ];

    /**
     * @inheritDoc
     */
    protected $listTransformations = [
        'answers', 'categories'
    ];

    /**
     * @inheritDoc
     */
    protected $retrieveTransformations = [
        'answers', 'categories'
    ];

    /**
     * Retrieve a user from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws \App\Exceptions\ServiceEntityNotFoundException If no identifier was provided to validate
     * @return array The data returned for the entity
     */
    public function get(array $inputs = [])
    {
        // show "deleted" information to show full history of question
        if (isset($inputs['showDeleted']) && $inputs['showDeleted'] == 'true') {
            $this->entityManager->getFilters()->disable('soft-deleteable');
        }

        // support lookup by id or label
        if (!isset($inputs['id'])) {
            throw new ServiceEntityNotFoundException('No identifier was provided to find the entity.');
        }

        // $this->validateIdentifier($identifier);
        return $this->loadRepositoryItem(
            Question::class,
            new RepositoryIdentifier($inputs['id']),
            new QuestionTransformer()
        );
    }

    /**
     * Retrieve all questions
     *
     * @return array An array of returned entities
     */
    public function getAll()
    {
        return $this->loadRepositoryCollection(
            Question::class,
            new QuestionTransformer()
        );
    }

    /**
     * Create a new question
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     */
    public function create(array $inputs)
    {
        return $this->insert(
            $inputs,
            new Question(),
            new QuestionTransformer()
        );
    }

    /**
     * Updates a question with given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     */
    public function update(array $inputs)
    {
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Question::class, new RepositoryIdentifier($inputs['id'])),
            new QuestionTransformer()
        );
    }

    /**
     * Deletes a given question
     *
     * @param array $inputs The data provided for the request
     * @return void
     */
    public function delete(array $inputs)
    {
        $this->expire(
            $this->getEntityFromRepository(Question::class, new RepositoryIdentifier($inputs['id']))
        );
    }
}
