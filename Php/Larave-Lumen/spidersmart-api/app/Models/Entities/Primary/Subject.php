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
use App\Models\Entities\Primary\Center;
use App\Models\Entities\Primary\Level;

/**
 * @ORM\Entity
 * @ORM\Table(name="subject")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class Subject implements EntityModel, ExpiresModel, VersionedModel
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
     * @ORM\Column(type="boolean")
     */
    protected $isActive = true;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Relationships\CenterSubject", mappedBy="subject")
     */
    protected $centers;

    /**
     * @ORM\OneToMany(targetEntity="\App\Models\Entities\Primary\Level", mappedBy="subject")
     */
    protected $levels;

    public function __construct()
    {
        $this->centers = new ArrayCollection();
        $this->levels = new ArrayCollection();
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
    public function getCenters(): ?Collection
    {
        return $this->centers;
    }

    /**
     * @param Collection $centers
     */
    public function setCenters(Collection $centers)
    {
        $this->centers = $centers;
    }

    /**
     * @param Center $center
     * @return Subject
     */
    public function addCenter(Center $center): self
    {
        $this->centers->add($center);
        $center->addSubject($this);
        return $this;
    }

    /**
     * @param Center $center
     * @return Subject
     */
    public function removeCenter(Center $center): self
    {
        if ($this->centers->contains($center)) {
            $this->centers->removeElement($center);

            // TODO:  PERHAPS THIS SHOULD DELETE THE QUESTION INSTEAD OF JUST UNASSIGNING IT
            // CHECK IF THE FK RELATIONSHIP IN THE DATABASE WILL DO THIS FOR US
            if ($center->getSubjects()->contains($this)) {
                $center->removeSubject($this);
            }
        }
        return $this;
    }


    /**
     * @return Collection
     */
    public function getLevels(): ?Collection
    {
        return $this->levels;
    }

    /**
     * @param Collection $levels
     */
    public function setLevels(Collection $levels)
    {
        $this->levels = $levels;
    }

    /**
     * @param Level $level
     * @return Subject
     */
    public function addLevel(Level $level): self
    {
        $this->levels->add($level);
        $level->setSubject($this);
        return $this;
    }

    /**
     * @param Level $level
     * @return Subject
     */
    public function removeLevel(Level $level): self
    {
        if ($this->levels->contains($level)) {
            $this->levels->removeElement($level);

            // TODO:  PERHAPS THIS SHOULD DELETE THE QUESTION INSTEAD OF JUST UNASSIGNING IT
            // CHECK IF THE FK RELATIONSHIP IN THE DATABASE WILL DO THIS FOR US
            if ($level->getSubject() === $this) {
                $level->setSubject(null);
            }
        }
        return $this;
    }
}
