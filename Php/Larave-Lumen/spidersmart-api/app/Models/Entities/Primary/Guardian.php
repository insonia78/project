<?php

namespace App\Models\Entities\Primary;

use App\Contracts\EntityModel;
use App\Contracts\ExpiresModel;
use App\Contracts\VersionedModel;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity
 * @ORM\Table(name="guardian")
 */
class Guardian extends User implements EntityModel, ExpiresModel, VersionedModel
{
}
