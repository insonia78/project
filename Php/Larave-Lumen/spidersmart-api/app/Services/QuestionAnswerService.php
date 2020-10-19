<?php

namespace App\Services;

use App\Contracts\BusinessModelService;

/**
 * Class QuestionAnswerService
 * @package App\Services
 */
class QuestionAnswerService extends BaseService implements BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $modelRelationName = 'Answer';

    /**
     * @inheritDoc
     */
    protected $rules = [
        'answer' => 'required|string',
        'correct' => 'required|boolean'
    ];
}
