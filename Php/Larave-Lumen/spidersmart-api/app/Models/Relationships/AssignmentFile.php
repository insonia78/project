<?php

namespace App\Models\Relationships;

use App\Contracts\ExpiresModel;
use App\Models\Entities\Primary\Assignment;
use App\Traits\ModelExpires;
use Doctrine\ORM\Mapping as ORM;
use Gedmo\Mapping\Annotation as Gedmo;

/**
 * @ORM\Entity
 * @ORM\Table(name="assignment_file")
 * @Gedmo\SoftDeleteable(fieldName="dateTo", timeAware=false)
 */
class AssignmentFile implements ExpiresModel
{
    use ModelExpires;

    /**
     * @ORM\Id
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\Assignment", inversedBy="files")
     * @ORM\JoinColumn(name="assignment_id", referencedColumnName="id")
     */
    protected $assignment;

    /**
     * @ORM\Id
     * @ORM\ManyToOne(targetEntity="\App\Models\Entities\Primary\File", inversedBy="assignments")
     * @ORM\JoinColumn(name="file_id", referencedColumnName="id")
     */
    protected $file;

    /**
     * @ORM\Column(type="integer")
     */
    protected $quantity;

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
     * @return string
     */
    public function getFile(): ?string
    {
        return $this->file;
    }

    /**
     * @param string $file
     */
    public function setFile(string $file)
    {
        $this->file = $file;
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
