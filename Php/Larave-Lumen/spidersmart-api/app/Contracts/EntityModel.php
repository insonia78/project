<?php

namespace App\Contracts;

/**
 * Interface EntityModel
 * @package App\Contracts
 */
interface EntityModel extends IdentifiableModel
{
    /**
     * Set unique identifier
     *
     * @param int $id The identifier
     * @return void
     */
    public function setId(int $id);
}
