<?php

namespace App\Models\Entities\Primary;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Contracts\VersionedModel;
use App\Models\Entities\Secondary\CenterHourRange;
use App\Models\Relationships\CenterSubject;
use App\Traits\ModelEntity;
use App\Traits\ModelExpires;
use App\Traits\ModelVersioning;
use Doctrine\ORM\Mapping as ORM;
use Gedmo\Mapping\Annotation as Gedmo;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use App\Models\Entities\Primary\Book;
use App\Models\Entities\Relation\Enrollment;

/**
 * @ORM\Entity
 * @ORM\Table(name="center")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class Center implements EntityModel, ExpiresModel, VersionedModel
{
    use ModelEntity;
    use ModelExpires;
    use ModelVersioning;

    /**
     * @ORM\Column(type="string")
     */
    protected $label;

    /**
     * @ORM\Column(type="string")
     */
    protected $name;

    /**
     * @ORM\Column(type="string")
     */
    protected $type;

    /**
     * @ORM\Column(type="string")
     */
    protected $streetAddress;

    /**
     * @ORM\Column(type="string")
     */
    protected $city;

    /**
     * @ORM\Column(type="string")
     */
    protected $state;

    /**
     * @ORM\Column(type="string")
     */
    protected $postalCode;

    /**
     * @ORM\Column(type="string")
     */
    protected $country;

    /**
     * @ORM\Column(type="string")
     */
    protected $phone;

    /**
     * @ORM\Column(type="string")
     */
    protected $email;

    /**
     * @ORM\Column(type="float")
     */
    protected $latitude;

    /**
     * @ORM\Column(type="float")
     */
    protected $longitude;

    /**
     * @ORM\Column(type="string")
     */
    protected $timezone;

    /**
     * @ORM\Column(type="boolean")
     */
    protected $isVisible = true;

    /**
     * @ORM\Column(type="boolean")
     */
    protected $useInventory = true;

    /**
     * @ORM\Column(type="smallint")
     */
    protected $bookCheckoutLimit = 1;

    /**
     * @ORM\Column(type="string")
     */
    protected $bookCheckoutFrequency = 'weekly';

    /**
     * @ORM\Column(type="boolean")
     */
    protected $isActive = true;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Relationships\CenterSubject", mappedBy="center", cascade={"persist"}, fetch="EAGER")
     */
    protected $subjects;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Secondary\CenterHourRange", mappedBy="center")
     */
    protected $hours;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Relationships\CenterBook", mappedBy="center")
     */
    protected $books;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Relation\Enrollment", mappedBy="center")
     */
    protected $enrollments;

    public function __construct()
    {
        $this->hours = new ArrayCollection();
        $this->books = new ArrayCollection();
        $this->subjects = new ArrayCollection();
        $this->enrollments = new ArrayCollection();
    }

    /**
     * @return string
     */
    public function getLabel(): ?string
    {
        return $this->label;
    }

    /**
     * @param string $label
     */
    public function setLabel(string $label)
    {
        $this->label = $label;
    }

    /**
     * @return string
     */
    public function getName(): ?string
    {
        return $this->name;
    }

    /**
     * @param string $name
     */
    public function setName(string $name)
    {
        $this->name = $name;
    }

    /**
     * @return string
     */
    public function getType(): ?string
    {
        return $this->type;
    }

    /**
     * @param string $type
     */
    public function setType(string $type)
    {
        $this->type = $type;
    }

    /**
     * @return string
     */
    public function getStreetAddress(): ?string
    {
        return $this->streetAddress;
    }

    /**
     * @param string $streetAddress
     */
    public function setStreetAddress(string $streetAddress)
    {
        $this->streetAddress = $streetAddress;
    }

    /**
     * @return string
     */
    public function getCity(): ?string
    {
        return $this->city;
    }

    /**
     * @param string $city
     */
    public function setCity(string $city)
    {
        $this->city = $city;
    }

    /**
     * @return string
     */
    public function getState(): ?string
    {
        return $this->state;
    }

    /**
     * @param string $state
     */
    public function setState(string $state)
    {
        $this->state = $state;
    }

    /**
     * @return string
     */
    public function getPostalCode(): ?string
    {
        return $this->postalCode;
    }

    /**
     * @param string $postalCode
     */
    public function setPostalCode(string $postalCode)
    {
        $this->postalCode = $postalCode;
    }

    /**
     * @return string
     */
    public function getCountry(): ?string
    {
        return $this->country;
    }

    /**
     * @param string $country
     */
    public function setCountry(string $country)
    {
        $this->country = $country;
    }

    /**
     * @return string
     */
    public function getPhone(): ?string
    {
        return $this->phone;
    }

    /**
     * @param string $phone
     */
    public function setPhone(string $phone)
    {
        $this->phone = $phone;
    }

    /**
     * @return string
     */
    public function getEmail(): ?string
    {
        return $this->email;
    }

    /**
     * @param string $email
     */
    public function setEmail(string $email)
    {
        $this->email = $email;
    }

    /**
     * @return float
     */
    public function getLatitude(): ?float
    {
        return $this->latitude;
    }

    /**
     * @param float $latitude
     */
    public function setLatitude(float $latitude): void
    {
        $this->latitude = $latitude;
    }

    /**
     * @return float
     */
    public function getLongitude(): ?float
    {
        return $this->longitude;
    }

    /**
     * @param float $longitude
     */
    public function setLongitude(float $longitude): void
    {
        $this->longitude = $longitude;
    }

    /**
     * @return string
     */
    public function getTimezone(): ?string
    {
        return $this->timezone;
    }

    /**
     * @param string $timezone
     */
    public function setTimezone(string $timezone): void
    {
        $this->timezone = $timezone;
    }

    /**
     * @return bool
     */
    public function isVisible(): bool
    {
        return $this->isVisible;
    }

    /**
     * @param bool $isVisible
     */
    public function setVisible(bool $isVisible): void
    {
        $this->isVisible = $isVisible;
    }

    /**
     * @return bool
     */
    public function useInventory(): bool
    {
        return $this->useInventory;
    }

    /**
     * @param bool $useInventory
     */
    public function setUseInventory(bool $useInventory): void
    {
        $this->useInventory = $useInventory;
    }

    /**
     * @return int
     */
    public function getBookCheckoutLimit(): int
    {
        return $this->bookCheckoutLimit;
    }

    /**
     * @param int $bookCheckoutLimit
     */
    public function setBookCheckoutLimit(int $bookCheckoutLimit): void
    {
        $this->bookCheckoutLimit = $bookCheckoutLimit;
    }

    /**
     * @return string
     */
    public function getBookCheckoutFrequency(): string
    {
        return $this->bookCheckoutFrequency;
    }

    /**
     * @param string $bookCheckoutFrequency
     */
    public function setBookCheckoutFrequency(string $bookCheckoutFrequency): void
    {
        $this->bookCheckoutFrequency = $bookCheckoutFrequency;
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
     * @return Collection
     */
    public function getSubjects(): ?Collection
    {
        return $this->subjects;
    }

    /**
     * @param Collection $subjects
     */
    public function setSubjects(Collection $subjects)
    {
        $this->subjects = $subjects;
    }

    /**
     * @param Subject $subject
     * @return Center
     */
    public function addSubject(Subject $subject): self
    {
        $centerSubject = new CenterSubject();
        $centerSubject->setSubject($subject);
        $centerSubject->setCenter($this);
        $this->subjects->add($centerSubject);
        return $this;
    }

    /**
     * @param Subject $subject
     * @return Center
     */
    public function removeSubject(Subject $subject): self
    {
        if ($this->subjects->contains($subject)) {
            $this->subjects->removeElement($subject);

            // TODO:  PERHAPS THIS SHOULD DELETE THE QUESTION INSTEAD OF JUST UNASSIGNING IT
            // CHECK IF THE FK RELATIONSHIP IN THE DATABASE WILL DO THIS FOR US
            if ($subject->getCenters()->contains($this)) {
                $subject->removeCenter($this);
            }
        }
        return $this;
    }

    /**
     * @return Collection
     */
    public function getHours(): Collection
    {
        return $this->hours;
    }

    /**
     * @param Collection $hours
     */
    public function setHours(Collection $hours)
    {
        $this->hours = $hours;
    }

    /**
     * @param CenterHourRange $hourRange
     * @return Center
     */
    public function addCenterHourRange(CenterHourRange $hourRange): self
    {
        $this->hours->add($hourRange);
        $hourRange->setCenter($this);
        return $this;
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
    public function setBooks(Collection $books)
    {
        $this->books = $books;
    }

    /**
     * @ param Book $book
     * @ return Center
     *
    public function addBook(Book $book): self
    {
    $this->books->add($book);
    // $book->setCenter($this);
    return $this;
    }

    /**
     * @ param Book $book
     * @ return Center
     *
    public function removeBook(Book $book): self
    {
    if ($this->books->contains($book)) {
    $this->books->removeElement($book);

    // TODO:  PERHAPS THIS SHOULD DELETE THE QUESTION INSTEAD OF JUST UNASSIGNING IT
    // CHECK IF THE FK RELATIONSHIP IN THE DATABASE WILL DO THIS FOR US
    if ($book->getCenters() === $this) {
    //   $book->setCenter(null);
    }
    }
    return $this;
    }

    /**
     * @return Collection
     */
    public function getEnrollments(): ?Collection
    {
        return $this->enrollments;
    }

    /**
     * @param Collection $enrollments
     */
    public function setEnrollments(Collection $enrollments)
    {
        $this->enrollments = $enrollments;
    }

    /**
     * @param Enrollment $enrollment
     * @return Center
     */
    public function addEnrollment(Enrollment $enrollment): self
    {
        $this->enrollments->add($enrollment);
        $enrollment->setCenter($this);
        return $this;
    }

    /**
     * @param Enrollment $enrollment
     * @return Center
     */
    public function removeEnrollment(Enrollment $enrollment): self
    {
        if ($this->enrollments->contains($enrollment)) {
            $this->enrollments->removeElement($enrollment);

            // TODO:  PERHAPS THIS SHOULD DELETE THE QUESTION INSTEAD OF JUST UNASSIGNING IT
            // CHECK IF THE FK RELATIONSHIP IN THE DATABASE WILL DO THIS FOR US
            if ($enrollment->getCenter() === $this) {
                $enrollment->setCenter(null);
            }
        }
        return $this;
    }
}
