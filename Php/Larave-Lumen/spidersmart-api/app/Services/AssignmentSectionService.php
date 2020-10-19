<?php

namespace App\Services;

use App\Contracts\BusinessModelService;

/**
 * Class AssignmentSectionService
 * @package App\Services
 */
class AssignmentSectionService extends BaseService implements BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $modelRelationName = 'Section';

    /**
     * @inheritDoc
     */
    protected $rules = [
        'title' => 'required|string',
        'instructions' => 'string|nullable'
    ];

    /**
     * @inheritDoc
     */
    protected $createRelationships = [
        'questions' => \App\Services\QuestionService::class
    ];
}
