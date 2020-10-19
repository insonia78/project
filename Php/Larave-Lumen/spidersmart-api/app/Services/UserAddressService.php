<?php

namespace App\Services;

use App\Contracts\BusinessModelService;

/**
 * Class AddressService
 * @package App\Services
 */
class UserAddressService extends BaseService implements BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        'title' => 'required|string',
        'streetAddress' => 'required',
        'city' => 'required|alpha',
        'state' => 'required|alpha',
        'postalCode' => 'required|alpha_num',
        'country' => 'required|size:2'
    ];
}
