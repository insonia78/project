<?php

namespace App\Transformers;

use App\Models\Relationships\CenterBook;

class CenterBookTransformer extends BaseTransformer
{
    /**
     * Transform the given entity into a data array
     * @param CenterBook $centerBook
     * @return array The transformed data
     */
    public function transform(CenterBook $centerBook)
    {
        $book = $this->getCurrentScope()->getManager()->createData($this->item($centerBook->getBook(), new BookTransformer()))->toArray();
        return $this->parseTransformer($centerBook, array_merge(
            $book,
            [
                'quantity' => $centerBook->getQuantity(),
                'relatedFrom' => $this->formatDate($centerBook->getDateFrom()),
                'relatedTo' => $this->formatDate($centerBook->getDateTo())
            ]
        ));
    }
}
