<?php

namespace App\Traits;

/**
 * Trait ModelExpires
 * Adds expiration traits for models
 * @package App\Traits
 */
trait ModelExpires
{
    /**
     * @ORM\Column(type="datetime")
     */
    protected $dateFrom;

    /**
     * @ORM\Column(type="datetime")
     */
    protected $dateTo;

    /**
     * @return \DateTime
     */
    public function getDateFrom(): ?\DateTime
    {
        return $this->dateFrom;
    }

    /**
     * @param \DateTime $dateFrom
     */
    public function setDateFrom(?\DateTime $dateFrom)
    {
        if (!is_null($dateFrom)) {
            $this->dateFrom = $dateFrom;
        }
    }

    /**
     * @return \DateTime
     */
    public function getDateTo(): ?\DateTime
    {
        return $this->dateTo;
    }

    /**
     * @param \DateTime $dateTo
     */
    public function setDateTo(?\DateTime $dateTo)
    {
        if (!is_null($dateTo)) {
            $this->dateTo = $dateTo;
        }
    }
}
