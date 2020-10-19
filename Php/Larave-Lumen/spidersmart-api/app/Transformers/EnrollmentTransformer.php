<?php

namespace App\Transformers;

use App\Models\Entities\Relation\CenterEnrollment;
use App\Models\Entities\Relation\Enrollment;
use League\Fractal\Resource\Item;
use League\Fractal\Resource\Collection;

class EnrollmentTransformer extends BaseTransformer
{
    /**
     * @var array The included relationships which are defined
     */
    protected $availableIncludes = [
        'level', 'user', 'tuitionRate', 'center', 'books', 'assignments'
    ];

    /**
     * Transform the given entity into a data array
     *
     * @param Enrollment $enrollment The enrollment to transform
     * @return array The transformed data
     */
    public function transform(Enrollment $enrollment)
    {
        return $this->parseTransformer($enrollment, [
            'id' => $enrollment->getId(),
            'dateFrom' => $this->formatDate($enrollment->getDateFrom()),
            'dateTo' => $this->formatDate($enrollment->getDateTo())
        ]);
    }

    /**
     * Defines what level will look like when included in the transformation
     *
     * @param Enrollment $enrollment The enrollment for which to include level
     * @return \League\Fractal\Resource\Item
     */
    public function includeLevel(Enrollment $enrollment)
    {
        $level = $enrollment->getLevel();
        return (!is_null($level)) ? $this->item($level, new LevelTransformer()) : null;
    }

    /**
     * Defines what user will look like when included in the transformation
     *
     * @param Enrollment $enrollment The enrollment for which to include the user
     * @return \League\Fractal\Resource\Item
     */
    public function includeUser(Enrollment $enrollment): ?Item
    {
        $user = $enrollment->getUser();
        return $this->item($user, new UserTransformer());
    }

    /**
     * Defines what tuition rate will look like when included in the transformation
     *
     * @param Enrollment $enrollment The enrollment for which to include the tuition rate
     * @return \League\Fractal\Resource\Item
     */
    public function includeTuitionRate(Enrollment $enrollment): ?Item
    {
        $tuitionRate = $enrollment->getTuitionRate();
        return (!is_null($tuitionRate)) ? $this->item($tuitionRate, new TuitionRateTransformer()) : null;
    }

    /**
     * Defines what center will look like when included in the transformation
     *
     * @param Enrollment $enrollment The enrollment for which to include the center
     * @return \League\Fractal\Resource\Item
     */
    public function includeCenter(Enrollment $enrollment): ?Item
    {
        $center = $enrollment->getCenter();
        return (!is_null($center)) ? $this->item($center, new CenterTransformer()) : null;
    }

    /**
     * Defines what book will look like when included in the transformation
     *
     * @param Enrollment $enrollment The enrollment for which to include books
     * @return \League\Fractal\Resource\Collection
     */
    public function includeBooks(Enrollment $enrollment): Collection
    {
        $books = $enrollment->getBooks();
        return $this->collection($books, new BookCheckoutTransformer());
    }

    /**
     * Defines what assignment will look like when included in the transformation
     *
     * @param Enrollment $enrollment The enrollment for which to include assignments
     * @return \League\Fractal\Resource\Collection
     */
    public function includeAssignments(Enrollment $enrollment): Collection
    {
        $assignments = $enrollment->getAssignments();
        return $this->collection($assignments, new AssignmentSubmissionTransformer());
    }
}
