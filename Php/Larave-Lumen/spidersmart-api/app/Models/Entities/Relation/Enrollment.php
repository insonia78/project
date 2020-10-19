<?php

namespace App\Models\Entities\Relation;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Models\Entities\Primary\Assignment;
use App\Models\Entities\Primary\Book;
use App\Models\Entities\Primary\Center;
use App\Models\Entities\Primary\Level;
use App\Models\Entities\Primary\TuitionRate;
use App\Models\Entities\Primary\User;
use App\Traits\ModelEntity;
use App\Traits\ModelExpires;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;
use Gedmo\Mapping\Annotation as Gedmo;

/**
 * @ORM\Entity
 * @ORM\Table(name="enrollment")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class Enrollment implements EntityModel, ExpiresModel
{
    use ModelEntity;
    use ModelExpires;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\User", inversedBy="enrollments")
     * @ORM\JoinColumn(name="user_id", referencedColumnName="id")
     */
    protected $user;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\Center", inversedBy="enrollments")
     * @ORM\JoinColumn(name="center_id", referencedColumnName="id")
     */
    protected $center;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\Level", inversedBy="enrollments")
     * @ORM\JoinColumn(name="level_id", referencedColumnName="id")
     */
    protected $level;

    /**
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\TuitionRate", inversedBy="enrollments")
     * @ORM\JoinColumn(name="tuition_rate_id", referencedColumnName="id")
     */
    protected $tuitionRate;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Secondary\BookCheckout", mappedBy="enrollment")
     */
    protected $books;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Secondary\AssignmentSubmission", mappedBy="enrollment")
     */
    protected $assignments;

    public function __construct()
    {
        $this->books = new ArrayCollection();
        $this->assignments = new ArrayCollection();
    }

    /**
     * @return User
     */
    public function getUser(): ?User
    {
        return $this->user;
    }

    /**
     * @param User $user
     */
    public function setUser(User $user)
    {
        $this->user = $user;
    }

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
     * @return TuitionRate
     */
    public function getTuitionRate(): ?TuitionRate
    {
        return $this->tuitionRate;
    }

    /**
     * @param TuitionRate $tuitionRate
     */
    public function setTuitionRate(TuitionRate $tuitionRate)
    {
        $this->tuitionRate = $tuitionRate;
    }

    /**
     * @return Collection
     */
    public function getBooks(): ?Collection
    {
        return $this->books;
    }

    /**
     * @param Collection $books
     */
    public function setBook(Collection $books)
    {
        $this->books = $books;
    }

    /**
     * @param Book $book
     * @return Enrollment
     */
    public function addBook(Book $book): self
    {
        $this->books->add($book);
        // $book->addEnrollment($this);
        return $this;
    }

    /**
     * @return Collection
     */
    public function getAssignments(): ?Collection
    {
        return $this->assignments;
    }

    /**
     * @param Collection $assignments
     */
    public function setAssignments(Collection $assignments)
    {
        $this->assignments = $assignments;
    }

    /**
     * @param Assignment $assignment
     * @return Enrollment
     */
    public function addAssignment(Assignment $assignment): self
    {
        $this->assignments->add($assignment);
        // $assignment->addEnrollment($this);
        return $this;
    }
}
