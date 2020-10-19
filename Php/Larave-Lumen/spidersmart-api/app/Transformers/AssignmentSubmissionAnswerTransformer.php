<?php

namespace App\Transformers;

use App\Models\Entities\Secondary\AssignmentSubmissionAnswer;

class AssignmentSubmissionAnswerTransformer extends BaseTransformer
{
    /**
     * @var array The included relationships which are available
     */
    protected $availableIncludes = [
        'enrollmentAssignment', 'question', 'answer'
    ];

    /**
     * Transform the given entity into a data array
     * @param AssignmentSubmissionAnswer $answer
     * @return array The transformed data
     */
    public function transform(AssignmentSubmissionAnswer $answer)
    {
        return $this->parseTransformer($answer, [
            'comments' => $answer->getComments(),
            'dateFrom' => $this->formatDate($answer->getDateFrom()),
            'dateTo' => $this->formatDate($answer->getDateTo())
        ]);
    }

    /**
     * Defines what enrollment assignment will look like when included in the transformation
     * @param AssignmentSubmissionAnswer $answer
     * @return \League\Fractal\Resource\Item
     */
    public function includeSubmission(AssignmentSubmissionAnswer $answer)
    {
        $submission = $answer->getSubmission();
        return $this->item($submission, new AssignmentSubmissionTransformer());
    }

    /**
     * Defines what question answer will look like when included in the transformation
     * @param AssignmentSubmissionAnswer $answer
     * @return \League\Fractal\Resource\Item
     */
    public function includeAnswer(AssignmentSubmissionAnswer $answer)
    {
        $questionAnswer = $answer->getAnswer();
        return $this->item($questionAnswer, new QuestionAnswerTransformer());
    }

    /**
     * Defines what enrollment will look like when included in the transformation
     * @param AssignmentSubmissionAnswer $answer
     * @return \League\Fractal\Resource\Item
     */
    public function includeQuestion(AssignmentSubmissionAnswer $answer)
    {
        $question = $answer->getQuestion();
        return $this->item($question, new QuestionTransformer());
    }
}
