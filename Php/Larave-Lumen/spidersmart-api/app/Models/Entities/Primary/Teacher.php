<?php

namespace App\Models\Entities\Primary;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Contracts\VersionedModel;
use Doctrine\ORM\Mapping as ORM;
use App\Models\Entities\Primary\Student;
use App\Models\Relationships\TeacherStudent;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;

/**
 * @ORM\Entity
 * @ORM\Table(name="teacher")
 */
class Teacher extends User implements EntityModel, ExpiresModel, VersionedModel
{
    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Relationships\TeacherStudent", mappedBy="teacher")
     */
    protected $students;
    
    public function __construct()
    {
        parent::__construct();
        $this->students = new ArrayCollection();
    }

    /**
     * @return Collection
     */
    public function getStudents(): ?Collection
    {
        return $this->students;
    }

    /**
     * @param Collection $students
     */
    public function setStudents(Collection $students)
    {
        $this->students = $students;
    }
    
    /**
     * @param Student $student
     * @return Teacher
     */
    public function addStudent(Student $student): self
    {
        $teacherStudent = new TeacherStudent();
        $teacherStudent->setStudent($student);
        $teacherStudent->setTeacher($this);
        $this->students->add($teacherStudent);
        return $this;
    }
}
