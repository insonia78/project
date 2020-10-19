<?php

namespace App\Models\Entities\Primary;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Contracts\VersionedModel;
use App\Traits\ModelEntity;
use App\Traits\ModelExpires;
use App\Traits\ModelVersioning;
use Doctrine\ORM\Mapping as ORM;
use Gedmo\Mapping\Annotation as Gedmo;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use App\Models\Entities\Primary\Assignment;

/**
 * @ORM\Entity
 * @ORM\Table(name="file")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class File implements EntityModel, ExpiresModel, VersionedModel
{
    use ModelEntity;
    use ModelExpires;
    use ModelVersioning;

    /**
     * @ORM\Column(type="string")
     */
    protected $name;

    /**
     * @ORM\Column(type="string")
     */
    protected $description;

    /**
     * @ORM\Column(type="string")
     */
    protected $mimetype;

    /**
     * @ORM\Column(type="string")
     */
    protected $path;

    /**
     * @ORM\Column(type="boolean")
     */
    protected $isActive = true;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Relationships\AssignmentFile", mappedBy="file", cascade={"persist"}, fetch="EAGER")
     */
    protected $assignments;


    public function __construct()
    {
        $this->assignments = new ArrayCollection();
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
    public function getMimetype(): ?string
    {
        return $this->mimetype;
    }

    /**
     * @param string $mimetype
     */
    public function setMimetype(string $mimetype)
    {
        $this->mimetype = $mimetype;
    }

    /**
     * @return string
     */
    public function getPath(): ?string
    {
        return $this->path;
    }

    /**
     * @param string $path
     */
    public function setPath(string $path)
    {
        $this->path = $path;
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
     * @return File
     *
    public function addFile(Assignment $assignment): self
    {
        $this->assignments->add($assignment);
        $assignment->setFile($this);
        return $this;
    }

    /**
     * @param Assignment $assignment
     * @return File
     *
    public function removeFile(Assignment $assignment): self
    {
        if ($this->assignments->contains($assignment)) {
            $this->assignments->removeElement($assignment);

            // TODO:  PERHAPS THIS SHOULD DELETE THE QUESTION INSTEAD OF JUST UNASSIGNING IT
            // CHECK IF THE FK RELATIONSHIP IN THE DATABASE WILL DO THIS FOR US
            if ($assignment->getFile() === $this) {
                $assignment->setFile(null);
            }
        }
        return $this;
    }
     * */
}
