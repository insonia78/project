<?php

namespace App\Transformers;

use App\Models\Relationships\CenterSubject;
use League\Fractal\Resource\Item;

class CenterSubjectTransformer extends BaseTransformer
{
    /**
     * Transform the given entity into a data array
     * @param CenterSubject $centerSubject
     * @return array The transformed data
     */
    public function transform(CenterSubject $centerSubject)
    {
        $subject = $this->getCurrentScope()->getManager()->createData($this->item($centerSubject->getSubject(), new SubjectTransformer()))->toArray();
        return $this->parseTransformer($centerSubject, array_merge(
            $subject,
            [
                'relatedFrom' => $this->formatDate($centerSubject->getDateFrom()),
                'relatedTo' => $this->formatDate($centerSubject->getDateTo())
            ]
        ));
    }
}
