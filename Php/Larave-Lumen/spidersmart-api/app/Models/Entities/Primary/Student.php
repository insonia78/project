<?php

namespace App\Models\Entities\Primary;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Contracts\VersionedModel;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity
 * @ORM\Table(name="student")
 */
class Student extends User implements EntityModel, ExpiresModel, VersionedModel
{
    /**
     * @ORM\Column(type="datetime", name="dob")
     */
    protected $dateOfBirth;

    /**
     * @ORM\Column(type="string")
     */
    protected $gender;

    /**
     * @ORM\Column(type="string")
     */
    protected $school;

    /**
     * @return \DateTime
     */
    public function getDateOfBirth(): ?\DateTime
    {
        return $this->dateOfBirth;
    }

    /**
     * @param \DateTime $dateOfBirth
     */
    public function setDateOfBirth(\DateTime $dateOfBirth)
    {
        $this->dateOfBirth = $dateOfBirth;
    }

    /**
     * @return string
     */
    public function getGender(): ?string
    {
        return $this->gender;
    }

    /**
     * @param string $gender
     */
    public function setGender(string $gender)
    {
        $this->gender = $gender;
    }

    /**
     * @return string
     */
    public function getSchool(): ?string
    {
        return $this->school;
    }

    /**
     * @param string $school
     */
    public function setSchool(string $school)
    {
        $this->school = $school;
    }
}
