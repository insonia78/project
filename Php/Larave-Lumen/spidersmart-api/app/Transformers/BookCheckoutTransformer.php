<?php

namespace App\Transformers;

use App\Models\Entities\Secondary\BookCheckout;
use League\Fractal\Resource\Item;

class BookCheckoutTransformer extends BaseTransformer
{
    /**
     * @var array The included relationships which are available
     */
    protected $availableIncludes = [
        'book', 'enrollment'
    ];

    /**
     * Transform the given entity into a data array
     * @param BookCheckout $enrollmentBook
     * @return array The transformed data
     */
    public function transform(BookCheckout $enrollmentBook): array
    {
        return $this->parseTransformer($enrollmentBook, [
            'dateFrom' => $this->formatDate($enrollmentBook->getDateFrom()),
            'dateTo' => $this->formatDate($enrollmentBook->getDateTo())
        ]);
    }

    /**
     * Defines what enrollment will look like when included in the transformation
     * @param BookCheckout $enrollmentBook
     * @return Item
     */
    public function includeEnrollment(BookCheckout $enrollmentBook): Item
    {
        $enrollment = $enrollmentBook->getEnrollment();
        return $this->item($enrollment, new EnrollmentTransformer());
    }

    /**
     * Defines what book will look like when included in the transformation
     * @param BookCheckout $enrollmentBook
     * @return Item
     */
    public function includeBook(BookCheckout $enrollmentBook): Item
    {
        $book = $enrollmentBook->getBook();
        return $this->item($book, new BookTransformer());
    }
}
