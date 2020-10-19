<?php

namespace App\Services;

use App\Contracts\BusinessModelService;

class UserContactService extends BaseService implements BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $modelRelationName = 'Contact';

    /**
     * @inheritDoc
     */
    protected $rules = [
        'title' => 'required|string',
        'type' => 'required|string',
        'value' => 'required|string'
    ];
}
