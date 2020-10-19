<?php

namespace App\Models\Entities\Primary;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Contracts\VersionedModel;
use App\Traits\ModelEntity;
use App\Traits\ModelExpires;
use App\Traits\ModelVersioning;
use Doctrine\ORM\Mapping as ORM;
use Gedmo\Mapping\Annotation as Gedmo;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use App\Models\Entities\Relation\Enrollment;
use App\Models\Entities\Primary\Subject;

/**
 * @ORM\Entity
 * @ORM\Table(name="level")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class Level implements EntityModel, ExpiresModel, VersionedModel
{
    use ModelEntity;
    use ModelExpires;
    use ModelVersioning;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\Subject", inversedBy="levels")
     * @ORM\JoinColumn(name="subject_id", referencedColumnName="id")
     */
    protected $subject;

    /**
     * @ORM\Column(type="string")
     */
    protected $name;

    /**
     * @ORM\Column(type="boolean")
     */
    protected $isActive = true;

    /**
     * @ORM\Column(type="string")
     */
    protected $description;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Relation\Enrollment", mappedBy="level")
     */
    protected $enrollments;

    public function __construct()
    {
        $this->enrollments = new ArrayCollection();
    }

    /**
     * @return Subject
     */
    public function getSubject(): ?Subject
    {
        return $this->subject;
    }

    /**
     * @param Subject $subject
     */
    public function setSubject(Subject $subject)
    {
        $this->subject = $subject;
    }

    /**
     * @return string
     */
    public function getName(): ?string
    {
        return $this->name;
    }

    /**
     * @param string $name
     */
    public function setName(string $name)
    {
        $this->name = $name;
    }

    /**
     * @return string
     */
    public function getDescription(): ?string
    {
        return $this->description;
    }

    /**
     * @param string $description
     */
    public function setDescription(string $description)
    {
        $this->description = $description;
    }

    /**
     * @return bool
     */
    public function isActive(): ?bool
    {
        return $this->isActive;
    }

    /**
     * @param bool $isActive
     */
    public function setActive(bool $isActive)
    {
        $this->isActive = $isActive;
    }

    /**
     * @return Collection
     */
    public function getEnrollments(): Collection
    {
        return $this->enrollments;
    }

    /**
     * @param Collection $enrollments
     */
    public function setEnrollments(Collection $enrollments)
    {
        $this->enrollments = $enrollments;
    }

    /**
     * @param Enrollment $enrollment
     * @return Level
     */
    public function addEnrollment(Enrollment $enrollment): self
    {
        $this->enrollments->add($enrollment);
        $enrollment->setLevel($this);
        return $this;
    }

    /**
     * @param Enrollment $enrollment
     * @return Level
     */
    public function removeEnrollment(Enrollment $enrollment): self
    {
        if ($this->enrollments->contains($enrollment)) {
            $this->enrollments->removeElement($enrollment);

            // TODO:  PERHAPS THIS SHOULD DELETE THE QUESTION INSTEAD OF JUST UNASSIGNING IT
            // CHECK IF THE FK RELATIONSHIP IN THE DATABASE WILL DO THIS FOR US
            if ($enrollment->getLevel() === $this) {
                $enrollment->setLevel(null);
            }
        }
        return $this;
    }
}
