<?php

namespace App\Services;

use App\Annotations\Access;
use App\Contracts\BusinessModelService;
use App\Contracts\CrudService;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Primary\Center;
use App\Transformers\CenterTransformer;
use Symfony;

/**
 * Class CenterService
 * @package App\Services
 */
class CenterService extends BaseService implements CrudService, BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        'label' => 'required|alpha_dash',
        'name' => 'required|string',
        'type' => 'required|in:local,online',
        'streetAddress' => 'required',
        'city' => 'required|alpha',
        'state' => 'required|alpha',
        'postalCode' => 'required|alpha_num',
        'country' => 'required|size:2',
        'phone' => 'required|alpha_num|max:15',
        'email' => 'required|email',
        'latitude' => 'numeric',
        'longitude' => 'numeric',
        'timezone' => 'timezone',
        'visible' => 'boolean',
        'useInventory' => 'boolean',
        'bookCheckoutLimit' => 'integer',
        'bookCheckoutPeriod' => 'in:day,weekly,bi_weekly,semi_monthly,monthly,bi_monthly,quarterly'
    ];

    /**
     * @inheritDoc
     */
    protected $createRelationships = [
        'hours' => \App\Services\CenterHourRangeService::class,
        'subjects' => \App\Services\SubjectService::class
    ];

    /**
     * Retrieve a center from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws \App\Exceptions\ServiceEntityNotFoundException If no identifier was provided to validate
     * @return array The data returned for the entity
     *
     * @Access(permission="center-view")
     */
    public function get(array $inputs = [])
    {
        // show "deleted" information to show full history of center
        if (isset($inputs['showDeleted']) && $inputs['showDeleted'] == 'true') {
            $this->entityManager->getFilters()->disable('soft-deleteable');
        }

        // support lookup by id or label
        if (!isset($inputs['id']) && !isset($inputs['label'])) {
            throw new ServiceEntityNotFoundException('No identifier was provided to find the entity.');
        }
        $identifier = (isset($inputs['id'])) ? new RepositoryIdentifier($inputs['id']) : new RepositoryIdentifier($inputs['label'], 'label', FILTER_SANITIZE_STRING);

        return $this->loadRepositoryItem(
            Center::class,
            $identifier,
            new CenterTransformer(),
            ['hours', 'books', 'students', 'subjects']
        );
    }

    /**
     * Retrieve all centers
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="center-view")
     */
    public function getAll(array $inputs = [])
    {
        return $this->loadRepositoryCollection(
            Center::class,
            new CenterTransformer(),
            [],
            $this->prepareFiltersFromInputs($inputs)
        );
    }

    /**
     * Create a new center
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     *
     * @Access(permission="center-create")
     */
    public function create(array $inputs)
    {
        return $this->insert($inputs, new Center(), new CenterTransformer());
    }

    /**
     * Update a center with the given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     *
     * @Access(permission="center-update")
     */
    public function update(array $inputs)
    {
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Center::class, new RepositoryIdentifier($inputs['id'])),
            new CenterTransformer()
        );
    }

    /**
     * Deletes a given center
     *
     * @param array $inputs The data provided for the request
     * @return void
     *
     * @Access(permission="center-delete")
     */
    public function delete(array $inputs)
    {
        $this->expire(
            $this->getEntityFromRepository(Center::class, new RepositoryIdentifier($inputs['id']))
        );
    }
}
