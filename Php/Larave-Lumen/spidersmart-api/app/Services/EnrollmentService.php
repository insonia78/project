<?php

namespace App\Services;

use App\Contracts\BusinessModelService;

/**
 * Class EnrollmentService
 * @package App\Services
 */
class EnrollmentService extends BaseService implements BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
//        'type' => 'required|string'
    ];

    protected $createRelationships = [
        'user' => \App\Services\UserService::class,
        'center' => \App\Services\CenterService::class,
        'level' => \App\Services\LevelService::class
    ];
}
