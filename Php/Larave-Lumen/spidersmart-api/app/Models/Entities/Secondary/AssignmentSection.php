<?php

namespace App\Models\Entities\Secondary;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Models\Entities\Primary\Assignment;
use App\Traits\ModelEntity;
use App\Traits\ModelExpires;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;
use Gedmo\Mapping\Annotation as Gedmo;

/**
 * @ORM\Entity
 * @ORM\Table(name="assignment_section")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class AssignmentSection implements EntityModel, ExpiresModel
{
    use ModelEntity;
    use ModelExpires;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\Assignment", inversedBy="assignment_section")
     * @ORM\JoinColumn(name="assignment_id", referencedColumnName="id")
     */
    protected $assignment;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Secondary\Question", mappedBy="section")
     */
    protected $questions;

    /**
     * @ORM\Column(type="string")
     */
    protected $title;

    /**
     * @ORM\Column(type="string")
     */
    protected $instructions;

    /**
     * @ORM\Column(type="boolean")
     */
    protected $isActive = true;

    public function __construct()
    {
        $this->questions = new ArrayCollection();
    }

    /**
     * @return Assignment
     */
    public function getAssignment(): ?Assignment
    {
        return $this->assignment;
    }

    /**
     * @param Assignment $assignment
     */
    public function setAssignment(Assignment $assignment)
    {
        $this->assignment = $assignment;
    }

    /**
     * @return string
     */
    public function getTitle(): ?string
    {
        return $this->title;
    }

    /**
     * @param string $title
     */
    public function setTitle(string $title)
    {
        $this->title = $title;
    }

    /**
     * @return string
     */
    public function getInstructions(): ?string
    {
        return $this->instructions;
    }

    /**
     * @param string $instructions
     */
    public function setInstructions(string $instructions)
    {
        $this->instructions = $instructions;
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
    public function getQuestions(): ?Collection
    {
        return $this->questions;
    }

    /**
     * @param Question $question
     * @return AssignmentSection
     */
    public function addQuestion(Question $question): self
    {
        $this->questions->add($question);
        $question->setSection($this);
        $question->setAssignment($this->assignment);
        return $this;
    }

    /**
     * @param Question $question
     * @return AssignmentSection
     */
    public function removeQuestion(Question $question): self
    {
        if ($this->questions->contains($question)) {
            $this->questions->removeElement($question);
            if ($question->getSection() === $this) {
                $question->setSection(null);
            }
        }
        return $this;
    }
}
