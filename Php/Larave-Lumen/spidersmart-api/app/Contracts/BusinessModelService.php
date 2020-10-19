<?php

namespace App\Contracts;

/**
 * Interface BusinessModelService
 * @package App\Contracts
 */
interface BusinessModelService
{
    /**
     * Retrieve validation rules related to input
     * @return array The rule data
     */
    public function getRules();

    /**
     * Retrieve a map of messages related to validation rules
     * @return array The returned map of messages
     */
    public function getMessages();

    /**
     * Return the name of the data model which is referenced by the service
     * @return string The name of the data model
     */
    public function getModel();

    /**
     * Returns the name of the model as it is referred by relations rather than the formal model name
     * @return string The name of the model for relations
     */
    public function getModelRelationName();

    /**
     * Return the name of the data model which is referenced by the service
     * @return string The name of the data model
     */
    public function getCreateRelationships();
}
