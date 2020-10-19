<?php

namespace App\Transformers;

use App\Models\Entities\Primary\User;
use App\Models\Entities\Primary\Student;

class StudentTransformer extends UserTransformer
{
    /**
     * Transform the given entity into a data array
     *
     * @param Student $student The student to transform
     * @todo PHP 7.x will not allow the parameter to be defined as Student despite it extending User
     *       PHP 8.x supports union types however, so we after its release and upgrade, we can change this back to Student
     *       and change the parameter in UserTransformer::transform() to User|Student|...
     * @return array The transformed data
     */
    public function transform(Student $student)
    {
        
        $outputMap = array_merge($this->getOutputMap($student), [
            'dateOfBirth' => $this->formatDate($student->getDateOfBirth()),
            'gender' => $student->getGender(),
            'school' => $student->getSchool()
        ]);
        return $this->parseTransformer($student, $outputMap);
    }
}
