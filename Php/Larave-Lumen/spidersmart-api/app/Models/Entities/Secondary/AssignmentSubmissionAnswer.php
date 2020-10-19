<?php

namespace App\Models\Entities\Secondary;

use App\Contracts\ExpiresModel;
use App\Traits\ModelExpires;
use Doctrine\ORM\Mapping as ORM;
use Gedmo\Mapping\Annotation as Gedmo;

/**
 * @ORM\Entity
 * @ORM\Table(name="assignment_submission_answer")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class AssignmentSubmissionAnswer implements ExpiresModel
{
    use ModelExpires;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Secondary\AssignmentSubmission", inversedBy="answers")
     * @ORM\JoinColumn(name="assignment_submission_id", referencedColumnName="id")
     */
    protected $submission;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\Question")
     * @ORM\JoinColumn(name="question_id", referencedColumnName="id")
     */
    protected $question;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\QuestionAnswer")
     * @ORM\JoinColumn(name="question_answer_id", referencedColumnName="id")
     */
    protected $answer;

    /**
     * @ORM\Column(type="string")
     */
    protected $comments;

    /**
     * @return AssignmentSubmission
     */
    public function getSubmission(): ?AssignmentSubmission
    {
        return $this->submission;
    }

    /**
     * @param AssignmentSubmission $submission
     */
    public function setSubmission(AssignmentSubmission $submission)
    {
        $this->submission = $submission;
    }

    /**
     * @return Question
     */
    public function getQuestion(): ?Question
    {
        return $this->question;
    }

    /**
     * @param Question $question
     */
    public function setQuestion(Question $question)
    {
        $this->question = $question;
    }

    /**
     * @return QuestionAnswer $answer
     */
    public function getAnswer(): ?QuestionAnswer
    {
        return $this->answer;
    }

    /**
     * @param QuestionAnswer $answer
     */
    public function setAnswer(QuestionAnswer $answer)
    {
        $this->answer = $answer;
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
}
