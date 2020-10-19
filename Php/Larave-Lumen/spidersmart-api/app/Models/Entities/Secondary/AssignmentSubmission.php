<?php

namespace App\Models\Entities\Secondary;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Models\Entities\Primary\Assignment;
use App\Models\Entities\Relation\Enrollment;
use App\Traits\ModelEntity;
use App\Traits\ModelExpires;
use Doctrine\Common\Collections\Collection;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\ORM\Mapping as ORM;
use Gedmo\Mapping\Annotation as Gedmo;

/**
 * @ORM\Entity
 * @ORM\Table(name="assignment_submission")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class AssignmentSubmission implements EntityModel, ExpiresModel
{
    use ModelEntity;
    use ModelExpires;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Relation\Enrollment", inversedBy="assignments")
     * @ORM\JoinColumn(name="enrollment_id", referencedColumnName="id")
     */
    protected $enrollment;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\Assignment")
     * @ORM\JoinColumn(name="assignment_id", referencedColumnName="id")
     */
    protected $assignment;

    /**
     * @ORM\Column(type="enum")
     */
    protected $status;

    /**
     * @ORM\Column(type="string")
     */
    protected $comments;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Secondary\AssignmentSubmissionAnswer", mappedBy="submission")
     */
    protected $answers;

    public function __construct()
    {
        $this->answers = new ArrayCollection();
    }

    /**
     * @return Enrollment
     */
    public function getEnrollment(): ?Enrollment
    {
        return $this->enrollment;
    }

    /**
     * @param Enrollment $enrollment
     */
    public function setEnrollment(Enrollment $enrollment)
    {
        $this->enrollment = $enrollment;
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
    public function getStatus(): ?string
    {
        return $this->status;
    }

    /**
     * @param string $status
     */
    public function setStatus(string $status)
    {
        $this->status = $status;
    }

    /**
     * @return string
     */
    public function getComments(): ?string
    {
        return $this->comments;
    }

    /**
     * @param string $comments
     */
    public function setComments(string $comments)
    {
        $this->comments = $comments;
    }

    /**
     * @return Collection
     */
    public function getAnswers(): ?Collection
    {
        return $this->answers;
    }

    /**
     * @param Collection $answers
     */
    public function setAnswers(Collection $answers)
    {
        $this->answers = $answers;
    }

    /**
     * @param AssignmentSubmissionAnswer $answer
     * @return AssignmentSubmission
     */
    public function addAnswer(AssignmentSubmissionAnswer $answer): self
    {
        $this->answers->add($answer);
        $answer->setSubmission($this);
        return $this;
    }

    /**
     * @param AssignmentSubmissionAnswer $answer
     * @return AssignmentSubmission
     */
    public function removeAnswer(AssignmentSubmissionAnswer $answer): self
    {
        if ($this->answers->contains($answer)) {
            $this->answers->removeElement($answer);

            // TODO:  PERHAPS THIS SHOULD DELETE THE QUESTION INSTEAD OF JUST UNASSIGNING IT
            // CHECK IF THE FK RELATIONSHIP IN THE DATABASE WILL DO THIS FOR US
            if ($answer->getSubmission() === $this) {
                $answer->setSubmission(null);
            }
        }
        return $this;
    }
}
