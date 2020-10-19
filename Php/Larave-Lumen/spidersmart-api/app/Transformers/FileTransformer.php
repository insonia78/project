<?php

namespace App\Transformers;

use App\Models\Entities\Primary\File;

class FileTransformer extends BaseTransformer
{
    /**
     * @var array The included relationships which are defined
     */
    protected $availableIncludes = [
        'assignments'
    ];

    /**
     * Transform the given entity into a data array
     *
     * @param file $file The file to transform
     * @return array The transformed data
     */
    public function transform(File $file)
    {
        return $this->parseTransformer($file, [
            'id' => $file->getId(),
            'name' => $file->getName(),
            'mimetype' => $file->getMimetype()(),
            'description' => $file->getDescription()(),
            'path' => $file->getPath()(),
            'dateFrom' => $this->formatDate($file->getDateFrom()),
            'dateTo' => $this->formatDate($file->getDateTo()),
            'active' => $file->isActive()
        ]);
    }

    /**
     * Defines what assignments will look like when included in the transformation
     *
     * @param File $file The file for which to include assignments
     * @return \League\Fractal\Resource\Collection
     */
    //    public function includeAssignments(File $file): Collection
    //    {
    //        $assignments = $file->getAssignment();
    //        return $this->collection($assignments, new AssignmentFileTransformer());
    //    }
}
