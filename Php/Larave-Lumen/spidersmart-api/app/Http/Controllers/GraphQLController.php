<?php

namespace App\Http\Controllers;

use App\Exceptions\ServiceCreateFailureException;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Exceptions\ServiceExpireFailureException;
use App\Exceptions\ServiceUpdateFailureException;
use App\Exceptions\ServiceValidationFailureException;
use Illuminate\Support\MessageBag;
use Dingo\Api\Http\Response;
use ReflectionObject;

/**
 * Class GraphQLController
 * @package App\Http\Controllers
 */
class GraphQLController extends BaseController
{
    /**
     * @var int Determines how many nested layers in return field query are supported
     */
    private const RETURN_FIELD_DEPTH = 5;
    /**
     * @var string|null The name of the field in the schema which is being invoked
     */
    private $fieldName = null;
    /**
     * @var string|null The type of operation being performed (this helps determine the format of output)
     */
    private $operation = null;
    /**
     * @var array The fields which are to be returned from the current mutation upon success
     */
    private $returnFields = [];
    /**
     * @var array The parameters provided to the query or mutation
     */
    private $parameters = [];
    /**
     * @var mixed Expected return type of the field being resolved
     */
    private $returnType = null;

    /**
     * Initialize the state of the request
     *
     * @param string $resolver The resolver which was resolves the operation
     * @param array $args The arguments which are passed to the operation
     * @param \GraphQL\Type\Definition\ResolveInfo $info Information about the resolver
     * @return void
     */
    public function __construct($resolver, array $args, $info)
    {
        // prepare service from given resolver
        $this->prepareServiceFromResolver($resolver);

        // define parameters and the fields which should be returned
        $this->parameters = $args;
        $this->returnFields = $info->getFieldSelection($this::RETURN_FIELD_DEPTH);
        $this->operation = $info->operation->operation;
        $this->fieldName = $info->fieldName;
        $this->returnType = $info->returnType;
    }

    /**
     * Process a retrieval query
     *
     * @return array
     */
    public function retrieve()
    {
        try {
            return $this->generateResponse(
                $this->service->{$this->methodName}($this->parameters)
            );
        } catch (ServiceEntityNotFoundException $e) {
            return $this->handleException($e->getMessage());
        }
    }

    /**
     * Process a create mutation
     *
     * @return array
     */
    public function create()
    {
        try {
            $entity = $this->service->{$this->methodName}($this->parameters);
            return $this->generateResponse(
                $this->convertEntityToArray($entity)
            );
        } catch (ServiceValidationFailureException $e) {
            return $this->handleException($e->getMessage(), $e->getErrors());
        } catch (ServiceCreateFailureException $e) {
            return $this->handleException($e->getMessage());
        } catch (\Exception $e) {
            return $this->handleException($e->getMessage());
        }
    }

    /**
     * Process an update mutation
     *
     * @return array
     */
    public function update()
    {
        try {
            $entity = $this->service->{$this->methodName}($this->parameters);
            return $this->generateResponse(
                $this->convertEntityToArray($entity)
            );
        } catch (ServiceEntityNotFoundException $e) {
            return $this->handleException($e->getMessage());
        } catch (ServiceValidationFailureException $e) {
            return $this->handleException($e->getMessage(), $e->getErrors());
        } catch (ServiceUpdateFailureException $e) {
            return $this->handleException($e->getMessage());
        } catch (\Exception $e) {
            return $this->handleException($e->getMessage());
        }
    }

    /**
     * Process a delete mutation
     *
     * @return array
     */
    public function delete()
    {
        try {
            $this->service->{$this->methodName}($this->parameters);
            return $this->generateResponse(null);
        } catch (ServiceEntityNotFoundException $e) {
            return $this->handleException($e->getMessage());
        } catch (ServiceValidationFailureException $e) {
            return $this->handleException($e->getMessage(), $e->getErrors());
        } catch (ServiceExpireFailureException $e) {
            return $this->handleException($e->getMessage());
        } catch (\Exception $e) {
            return $this->handleException($e->getMessage());
        }
    }

    /**
     * Transforms a returned model instance into an array containing the output of instances getters
     * @SuppressWarnings(PHPMD.ElseExpression)
     *
     * @param \App\Contracts\EntityModel|array $entity The entity from which return data will be generated
     * @return array An array representation of the data from the entity
     */
    private function convertEntityToArray($entity = null)
    {
        if (is_array($entity)) {
            return $entity;
        }
        $data = [];
        $ref = new ReflectionObject($entity);
        foreach ($ref->getMethods() as $method) {
            if (substr($method->name, 0, 3) == 'get') {
                $propName = strtolower(substr($method->name, 3, 1)) . substr($method->name, 4);
                $propVal = $method->invoke($entity);

                // in the case of a nested mutation result, a property could be a collection of results
                // this is returned as a Doctrine Persistent Collection
                if ($propVal instanceof \Doctrine\ORM\PersistentCollection) {
                    $propRelations = $method->invoke($entity)->unwrap()->toArray();
                    foreach ($propRelations as $relation) {
                        $data[$propName][] = $this->convertEntityToArray($relation);
                    }
                } else {
                    $data[$propName] = $method->invoke($entity);
                }
            }
        }
        return $data;
    }

    /**
     * Handles exception states and generates a properly formatted GraphQL error response
     *
     * @param string $message The overall error message
     * @param \Illuminate\Support\MessageBag $errors The list of validation errors returned from the action, if any
     * @return array
     */
    private function handleException($message, MessageBag $errors = null)
    {
        $errorList = [['message' => $message]];
        if (!is_null($errors) && $errors instanceof MessageBag) {
            $errorList = [];
            foreach ($errors->getMessages() as $field => $messages) {
                foreach ($messages as $msg) {
                    $error = [
                        'message' => $msg
                    ];
                    if (!is_int($field)) {
                        $error['extensions'] = [
                            'field' => $field
                        ];
                    }
                    array_push($errorList, $error);
                }
            }
        }
        return $this->generateResponse(null, $errorList);
    }

    /**
     * Generates a proper response based on operation and error status
     * @SuppressWarnings(PHPMD.ExitExpression)
     *
     * @param array|null $data The data to return in the response
     * @param array $errorList A list of errors which exist for this operation
     * @return array
     */
    private function generateResponse($data = null, array $errorList = [])
    {
        // if this is a query and there's an error, the data will not match the correct format and will return a
        // schema validation error, so issue the response and die to show the actual error
        if (is_array($errorList) && sizeof($errorList) > 0) {
            $response = [
                "success" => false,
                "data" => $data,
                "errors" => $errorList
            ];
            Response::create(json_encode($response), 200, [
                'Content-Type' => 'application/json'
            ])->send();
            die();
        }

        // if this is a mutation, return a specific response
        if ($this->operation == 'mutation') {
            return [
                "success" => true,
                "data" => $data
            ];
        }

        // if this is a query, simply return the data
        return $data;
    }
}
