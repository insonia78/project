<?php

namespace App\Models\Entities\Primary;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Contracts\VersionedModel;
use App\Models\Relationships\BookAuthor;
use App\Models\Relationships\BookGenre;
use App\Models\Relationships\BookPublisher;
use App\Traits\ModelEntity;
use App\Traits\ModelExpires;
use App\Traits\ModelVersioning;
use Doctrine\ORM\Mapping as ORM;
use Gedmo\Mapping\Annotation as Gedmo;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use App\Models\Entities\Primary\Author;
use App\Models\Entities\Primary\Genre;
use App\Models\Entities\Primary\Publisher;


/**
 * @ORM\Entity
 * @ORM\Table(name="book")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class Book implements EntityModel, ExpiresModel, VersionedModel
{
    use ModelEntity;
    use ModelExpires;
    use ModelVersioning;

    /**
     * @ORM\OneToOne(targetEntity="\App\Models\Entities\Primary\Level", mappedBy="book", fetch="EAGER")
     * @ORM\JoinColumn(name="level_id", referencedColumnName="id")
     */
    protected $level;

    /**
     * @ORM\Column(type="string")
     */
    protected $title;

    /**
     * @ORM\Column(type="string")
     */
    protected $description;

    /**
     * @ORM\Column(type="string")
     */
    protected $isbn;

    /**
     * @ORM\Column(type="string")
     */
    protected $coverImage;

    /**
     * @ORM\Column(type="boolean")
     */
    protected $isActive = true;

    /**
     * @ORM\OneToOne(targetEntity="\App\Models\Entities\Primary\Assignment", mappedBy="book")
     */
    protected $assignment;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Relationships\BookAuthor", mappedBy="book", cascade={"persist"}, fetch="EAGER")
     */
    protected $authors;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Relationships\BookGenre", mappedBy="book", cascade={"persist"}, fetch="EAGER")
     */
    protected $genres;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Relationships\BookPublisher", mappedBy="book", cascade={"persist"}, fetch="EAGER")
     */
    protected $publishers;

    public function __construct()
    {
        $this->authors = new ArrayCollection();
        $this->genres = new ArrayCollection();
        $this->publishers = new ArrayCollection();
    }

    /**
     * @return Level
     */
    public function getLevel(): ?Level
    {
        return $this->level;
    }

    /**
     * @param Level $level
     */
    public function setLevel(Level $level)
    {
        $this->level = $level;
    }

    /**
     * @return string
     */
    public function getTitle(): ?string
    {
        return $this->title;
    }

    /**
     * @param string $title
     */
    public function setTitle(string $title)
    {
        $this->title = $title;
    }

    /**
     * @return string
     */
    public function getDescription(): ?string
    {
        return $this->description;
    }

    /**
     * @param string $description
     */
    public function setDescription(string $description)
    {
        $this->description = $description;
    }

    /**
     * @return string
     */
    public function getIsbn(): ?string
    {
        return $this->isbn;
    }

    /**
     * @param string $isbn
     */
    public function setIsbn(string $isbn)
    {
        $this->isbn = $isbn;
    }

    /**
     * @return string
     */
    public function getCoverImage(): ?string
    {
        return $this->coverImage;
    }

    /**
     * @param string $coverImage
     */
    public function setCoverImage(string $coverImage)
    {
        $this->coverImage = $coverImage;
    }

    /**
     * @return bool
     */
    public function isActive(): ?bool
    {
        return $this->isActive;
    }

    /**
     * @param bool $isActive
     */
    public function setActive(bool $isActive)
    {
        $this->isActive = $isActive;
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
     * @return Collection
     */
    public function getAuthors(): ?Collection
    {
        return $this->authors;
    }

    /**
     * @param Collection $authors
     */
    public function setAuthors(Collection $authors)
    {
        $this->authors = $authors;
    }

    /**
     * @param Author $author
     * @return Book
     */
    public function addAuthor(Author $author): self
    {
        $bookAuthor = new BookAuthor();
        $bookAuthor->setAuthor($author);
        $bookAuthor->setBook($this);
        $this->authors->add($bookAuthor);
        return $this;
    }

    /**
     * @param Author $author
     * @return Book
     */
    public function removeAuthor(Author $author): self
    {
        if ($this->authors->contains($author)) {
            $this->authors->removeElement($author);
/*
            // TODO:  PERHAPS THIS SHOULD DELETE THE QUESTION INSTEAD OF JUST UNASSIGNING IT
            // CHECK IF THE FK RELATIONSHIP IN THE DATABASE WILL DO THIS FOR US
            if ($author->getBooks()->contains($this)) {
                $author->removeBook($this);
            }*/
        }
        return $this;
    }

    /**
     * @return Collection
     */
    public function getGenres(): ?Collection
    {
        return $this->genres;
    }

    /**
     * @param Collection $genres
     */
    public function setGenres(Collection $genres)
    {
        $this->genres = $genres;
    }

    /**
     * @param Genre $genre
     * @return Book
     */
    public function addGenre(Genre $genre): self
    {
        $bookGenre = new BookGenre();
        $bookGenre->setGenre($genre);
        $bookGenre->setBook($this);
        $this->genres->add($bookGenre);
        return $this;
    }

    /**
     * @param Genre $genre
     * @return Book
     */
    public function removeGenre(Genre $genre): self
    {
        if ($this->genres->contains($genre)) {
            $this->genres->removeElement($genre);
        }
        return $this;
    }

    /**
     * @return Collection
     */
    public function getPublishers(): ?Collection
    {
        return $this->publishers;
    }

    /**
     * @param Collection $publishers
     */
    public function setPublishers(Collection $publishers)
    {
        $this->publishers = $publishers;
    }

    /**
     * @param Publisher $publisher
     * @return Book
     */
    public function addPublisher(Publisher $publisher): self
    {
        $bookPublisher = new BookPublisher();
        $bookPublisher->setPublisher($publisher);
        $bookPublisher->setBook($this);
        $this->publishers->add($bookPublisher);
        return $this;
    }

    /**
     * @param Publisher $publisher
     * @return Book
     */
    public function removePublisher(Publisher $publisher): self
    {
        if ($this->publishers->contains($publisher)) {
            $this->publishers->removeElement($publisher);
        }
        return $this;
    }   
}
