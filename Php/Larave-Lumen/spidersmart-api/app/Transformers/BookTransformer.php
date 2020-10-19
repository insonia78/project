<?php

namespace App\Transformers;

use App\Models\Entities\Primary\Book;
use League\Fractal\Resource\Collection;
use League\Fractal\Resource\Item;


class BookTransformer extends BaseTransformer
{
    /**
     * @var array The included relationships which are defined
     */
    protected $availableIncludes = [
        'assignment', 'authors', 'genres', 'publishers'
    ];

    /**
     * Transform the given entity into a data array
     *
     * @param Book $book The book to transform
     * @return array The transformed data
     */
    public function transform(Book $book)
    {         
        return $this->parseTransformer($book, [
            'id' => $book->getId(),
            'title' => $book->getTitle(),
            'description' => $book->getDescription(),
            'isbn' => $book->getIsbn(),
            'coverImage' => $book->getCoverImage(),
            'dateFrom' => $this->formatDate($book->getDateFrom()),
            'dateTo' => $this->formatDate($book->getDateTo()),
            'active' => $book->isActive()              
        ]);
    }
    /**
     * Defines what an assignment will look like when included in the transformation
     *
     * @param Book $book The book for which to include the assignment
     * @return \League\Fractal\Resource\Item
     */
    public function includeAssignment(Book $book): ?Item
    {
        $assignment = $book->getAssignment();
        return (!is_null($assignment)) ? $this->item($assignment, new AssignmentTransformer()) : null;
    }

    /**
     * Defines what authors will look like when included in the transformation
     *
     * @param Book $book The book for which to include authors
     * @return \League\Fractal\Resource\Collection
     */
    public function includeAuthors(Book $book): Collection
    {
        $authors = $book->getAuthors();
        return $this->collection($authors, new BookAuthorTransformer());
    }

    /**
     * Defines what genres will look like when included in the transformation
     *
     * @param Book $book The book for which to include genres
     * @return \League\Fractal\Resource\Collection
     */
    public function includeGenres(Book $book): Collection
    {
        $genres = $book->getGenres();
        return $this->collection($genres, new BookGenreTransformer());
    }

    /**
     * Defines what publishers will look like when included in the transformation
     *
     * @param Book $book The book for which to include publishers
     * @return \League\Fractal\Resource\Collection
     */
    public function includePublishers(Book $book): Collection
    {
        $publishers = $book->getPublishers();
        return $this->collection($publishers, new BookPublisherTransformer());
    }

    /**
     * Defines what level will look like when included in the transformation
     *
     * @param Book $book The book for which to include the level
     * @return \League\Fractal\Resource\Item
     */
    public function includeLevel(Book $book): ?Item
    {
        $level = $book->getLevel();
        return (!is_null($level)) ? $this->item($level, new LevelTransformer()) : null;
    }
}
