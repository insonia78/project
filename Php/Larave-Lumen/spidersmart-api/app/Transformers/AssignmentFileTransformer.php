<?php

namespace App\Transformers;

use App\Models\Relationships\AssignmentFile;
use Doctrine\Common\Collections\Collection;
use League\Fractal\Resource\Item;

class AssignmentFileTransformer extends BaseTransformer
{
    /**
     * @var array The included relationships which are available
     */
    protected $availableIncludes = [
        'assignment', 'file'
    ];

    /**
     * Transform the given entity into a data array
     * @param AssignmentFile $assignmentFile
     * @return array The transformed data
     */
    public function transform(AssignmentFile $assignmentFile)
    {
        return $this->parseTransformer($assignmentFile, [
            'quantity' => $assignmentFile->getQuantity(),
            'dateFrom' => $this->formatDate($assignmentFile->getDateFrom()),
            'dateTo' => $this->formatDate($assignmentFile->getDateTo())
        ]);
    }

    /**
     * Defines what assignment will look like when included in the transformation
     * @param AssignmentFile $assignmentFile
     * @return \League\Fractal\Resource\Item
     */
    public function includeAssignment(AssignmentFile $assignmentFile): Item
    {
        $assignment = $assignmentFile->getAssignment();
        return $this->item($assignment, new AssignmentTransformer());
    }

    /**
     * Defines what file will look like when included in the transformation
     *
     * @param AssignmentFile $assignmentFile The assignment file for which to include the file
     * @return \League\Fractal\Resource\Item
     */
    public function includeFile(AssignmentFile $assignmentFile): Item
    {
        $file = $assignmentFile->getFile();
        return $this->item($file, new FileTransformer());
    }
}
