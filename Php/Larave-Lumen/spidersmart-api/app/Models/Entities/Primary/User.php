<?php

namespace App\Models\Entities\Primary;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Contracts\VersionedModel;
use App\Traits\ModelEntity;
use App\Traits\ModelExpires;
use App\Traits\ModelVersioning;
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;
use Doctrine\Common\Collections\ArrayCollection;
use Gedmo\Mapping\Annotation as Gedmo;
use App\Models\Entities\Relation\Enrollment;
use App\Models\Entities\Secondary\UserAddress;
use App\Models\Entities\Secondary\UserContact;

/**
 * @ORM\Entity
 * @ORM\Table(name="user")
 * @ORM\InheritanceType("JOINED")
 * @ORM\DiscriminatorColumn(name="type", type="string")
 * @ORM\DiscriminatorMap({
 *     "user" = "\App\Models\Entities\Primary\User",
 *     "administrator" = "\App\Models\Entities\Primary\Administrator",
 *     "director" = "\App\Models\Entities\Primary\Director",
 *     "teacher" = "\App\Models\Entities\Primary\Teacher",
 *     "guardian" = "\App\Models\Entities\Primary\Guardian",
 *     "student" = "\App\Models\Entities\Primary\Student"
 * })
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class User implements EntityModel, ExpiresModel, VersionedModel
{
    use ModelEntity;
    use ModelExpires;
    use ModelVersioning;
   
    /**
     * @ORM\Column(type="string")
     */
    protected $prefix;

    /**
     * @ORM\Column(type="string")
     */
    protected $firstName;

    /**
     * @ORM\Column(type="string")
     */
    protected $middleName;

    /**
     * @ORM\Column(type="string")
     */
    protected $lastName;

    /**
     * @ORM\Column(type="string")
     */
    protected $suffix;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Secondary\UserAddress", mappedBy="user")
     */
    protected $addresses;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Secondary\UserContact", mappedBy="user")
     */
    protected $contacts;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Relation\Enrollment", mappedBy="user")
     */
    protected $enrollments;

    /**
     * User constructor.
     */
    public function __construct()
    {
        $this->addresses = new ArrayCollection();
        $this->contacts = new ArrayCollection();
        $this->enrollments = new ArrayCollection();
    }

    /**
     * @return string
     */
    public function getPrefix(): ?string
    {
        return $this->prefix;
    }

    /**
     * @param string $prefix
     */
    public function setPrefix(string $prefix)
    {
        $this->prefix = $prefix;
    }

    /**
     * @return string
     */
    public function getFirstName(): ?string
    {
        return $this->firstName;
    }

    /**
     * @param string $firstName
     */
    public function setFirstName(string $firstName)
    {
        $this->firstName = $firstName;
    }

    /**
     * @return string
     */
    public function getMiddleName(): ?string
    {
        return $this->middleName;
    }

    /**
     * @param string $middleName
     */
    public function setMiddleName(string $middleName)
    {
        $this->middleName = $middleName;
    }

    /**
     * @return string
     */
    public function getLastName(): ?string
    {
        return $this->lastName;
    }

    /**
     * @param string $lastName
     */
    public function setLastName(string $lastName)
    {
        $this->lastName = $lastName;
    }

    /**
     * @return string
     */
    public function getSuffix(): ?string
    {
        return $this->suffix;
    }

    /**
     * @param string $suffix
     */
    public function setSuffix(string $suffix)
    {
        $this->suffix = $suffix;
    }

    /**
     * @return Collection
     */
    public function getAddresses(): Collection
    {
        return $this->addresses;
    }

    /**
     * @param Collection $addresses
     */
    public function setAddresses(Collection $addresses)
    {
        $this->addresses = $addresses;
    }

    /**
     * @param UserAddress $address
     * @return User
     */
    public function addUserAddress(UserAddress $address): self
    {
        $this->addresses->add($address);
        $address->setUser($this);
        return $this;
    }

    /**
     * @return Collection
     */
    public function getContacts(): Collection
    {
        return $this->contacts;
    }

    /**
     * @param Collection $contacts
     */
    public function setContacts(Collection $contacts)
    {
        $this->contacts = $contacts;
    }

    /**
     * @param UserContact $contact
     * @return User
     */
    public function addContact(UserContact $contact): self
    {
        $this->contacts->add($contact);
        $contact->setUser($this);
        return $this;
    }

    /**
     * @return Collection
     */
    public function getEnrollments(): Collection
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
     * @return User
     */
    public function addEnrollment(Enrollment $enrollment): self
    {
        $this->enrollments->add($enrollment);
        $enrollment->setUser($this);
        return $this;
    }

    /**
     * Criteria to filter based on given center id
     * @param string|string[] $centerId
     * @return bool
     */
    public function criteriaCenter($centerId)
    {
        $centerId = (is_array($centerId)) ? $centerId : [$centerId];
        return $this->getEnrollments()->filter(
            function ($enrollment) use ($centerId) {
                return (!is_null($enrollment->getCenter()) && in_array($enrollment->getCenter()->getId(), $centerId));
            }
        )->count() > 0;
    }
}
