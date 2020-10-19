<?php

namespace App\Helpers;

class RepositoryFilter
{
    /**
     * @var string The field upon which this filter should be performed
     */
    private $field;
    /**
     * @var string The value to which the filter will compare
     */
    private $value;
    /**
     * @var string|null The comparison used to filter
     */
    private $comparison;

    /**
     * RepositoryFilter constructor.
     * @param string $field The field upon which the filter should be performed
     * @param string|array $value The value which should be used for filtering
     * @param string|null $comparison The type of comparison to use
     */
    public function __construct($field, $value, $comparison = null)
    {
        $this->field = $field;
        $this->value = $value;
        if (is_null($comparison)) {
            $comparison = (is_array($value)) ? 'in' : '=';
        }
        $this->comparison = $comparison;
    }

    /**
     * @return string
     */
    public function getField()
    {
        return $this->field;
    }

    /**
     * @param string $field
     */
    public function setField($field)
    {
        $this->field = $field;
    }

    /**
     * @return string
     */
    public function getComparison()
    {
        return $this->comparison;
    }

    /**
     * @param string $comparison
     */
    public function setComparison($comparison)
    {
        $this->comparison = $comparison;
    }

    /**
     * @return mixed
     */
    public function getValue()
    {
        return $this->value;
    }

    /**
     * @param mixed $value
     */
    public function setValue($value)
    {
        $this->value = $value;
    }
}
