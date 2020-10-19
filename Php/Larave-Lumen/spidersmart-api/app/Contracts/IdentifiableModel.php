<?php

namespace App\Contracts;

/**
 * Interface IdentifiableModel
 * @package App\Contracts
 */
interface IdentifiableModel
{
    /**
     * Retrieve unique identifier
     * @return int The id
     */
    public function getId(): ?int;
}
