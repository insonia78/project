<?php

namespace App\Models\Relationships;

use App\Contracts\ExpiresModel;
use App\Models\Entities\Primary\Book;
use App\Models\Entities\Primary\Center;
use App\Traits\ModelExpires;
use Doctrine\ORM\Mapping as ORM;
use Gedmo\Mapping\Annotation as Gedmo;

/**
 * @ORM\Entity
 * @ORM\Table(name="center_book")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class CenterBook implements ExpiresModel
{
    use ModelExpires;

    /**
     * @ORM\Id
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\Center", inversedBy="books")
     * @ORM\JoinColumn(name="center_id", referencedColumnName="id")
     */
    protected $center;

    /**
     * @ORM\Id
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\Book", inversedBy="centers")
     * @ORM\JoinColumn(name="book_id", referencedColumnName="id")
     */
    protected $book;

    /**
     * @ORM\Column(type="integer")
     */
    protected $quantity;

    /**
     * @return Center
     */
    public function getCenter(): ?Center
    {
        return $this->center;
    }

    /**
     * @param Center $center
     */
    public function setCenter(Center $center)
    {
        $this->center = $center;
    }

    /**
     * @return Book
     */
    public function getBook(): ?Book
    {
        return $this->book;
    }

    /**
     * @param Book $book
     */
    public function setBook(Book $book)
    {
        $this->book = $book;
    }

    /**
     * @return int
     */
    public function getQuantity(): ?int
    {
        return $this->quantity;
    }

    /**
     * @param int $quantity
     */
    public function setQuantity(int $quantity)
    {
        $this->quantity = $quantity;
    }
}
