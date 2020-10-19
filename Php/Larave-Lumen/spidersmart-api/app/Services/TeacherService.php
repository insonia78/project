<?php

namespace App\Services;

use App\Annotations\Access;
use App\Models\Entities\Primary\Teacher;
use App\Helpers\RepositoryIdentifier;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Transformers\TeacherTransformer;

/**
 * Class TeacherService
 * @package App\Services
 */
class TeacherService extends UserService
{
    /**
     * Retrieve all teachers
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="teacher-view")
     */
    public function getAll(array $inputs = [])
    {
        return $this->loadRepositoryCollection(
            Teacher::class,
            new TeacherTransformer(),
            ['addresses', 'contacts','students'],
            $this->prepareFiltersFromInputs($inputs)
        );
    }

    /**
     * Retrieve a student from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws ServiceEntityNotFoundException If no identifier was provided to validate
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
            Teacher::class,
            new RepositoryIdentifier($inputs['id']),
            new TeacherTransformer(),
            ['addresses', 'contacts', 'students']
        );
    }
    /**
     * Updates a teacher with given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     *
     * @Access(permission="teacher-update")
     */
    public function update(array $inputs)
    {
        
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Teacher::class, new RepositoryIdentifier($inputs['id'])),
            new TeacherTransformer()
        );
    }

    /**
     * Create a new teacher
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     *
     * @Access(permission="teacher-create")
     */
    public function create(array $inputs)
    {
        
        return $this->insert(
            $inputs,
            new Teacher(),
            new TeacherTransformer()
        );
    }
}
