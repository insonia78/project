<?php

namespace App\Services;

use App\Annotations\Access;
use App\Helpers\RepositoryFilter;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Primary\Student;
use App\Transformers\StudentTransformer;
use App\Transformers\UserTransformer;
use App\Exceptions\ServiceEntityNotFoundException;

/**
 * Class StudentService
 * @package App\Services
 */
class StudentService extends UserService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        'prefix' => 'alpha|nullable',
        'firstName' => 'alpha|required',
        'middleName' => 'alpha|nullable',
        'lastName' => 'alpha|required',
        'suffix' => 'alpha|nullable',
        'gender' => 'string',
        'school' => 'string',
        'dateOfBirth' => 'date',
        'grade' => 'numeric',
    ];

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
            Student::class,
            new RepositoryIdentifier($inputs['id']),
            new StudentTransformer()
        );
    }

    /**
     * Retrieve all students
     *
     * @param array $inputs The data provided for the request
     * @return array An array of returned entities
     *
     * @Access(permission="student-view")
     */
    public function getAll(array $inputs = [])
    {
        
        return $this->loadRepositoryCollection(
            Student::class,
            new StudentTransformer(),
            ['addresses', 'enrollments', 'enrollments.center', 'contacts'],
            $this->prepareFiltersFromInputs($inputs)
        );
    }

    /**
     * Updates a student with given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     *
     * @Access(permission="student-update")
     */
    public function update(array $inputs)
    {
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Student::class, new RepositoryIdentifier($inputs['id'])),
            new StudentTransformer()
        );
    }

    /**
     * Create a new student
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     *
     * @Access(permission="student-create")
     */
    public function create(array $inputs)
    {
        return $this->insert(
            $inputs,
            new Student(),
            new StudentTransformer()
        );
    }
}
