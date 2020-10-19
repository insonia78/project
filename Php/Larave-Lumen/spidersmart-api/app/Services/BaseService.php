<?php

namespace App\Services;

use App\Contracts\BusinessModelService;
use App\Contracts\EntityModel;
use App\Contracts\IdentifiableModel;
use App\Contracts\VersionedModel;
use App\Exceptions\ServiceCreateFailureException;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Exceptions\ServiceExpireFailureException;
use App\Exceptions\ServiceRetrieveFailureException;
use App\Exceptions\ServiceUpdateFailureException;
use App\Exceptions\ServiceValidationFailureException;
use App\Helpers\RepositoryFilter;
use App\Helpers\RepositoryIdentifier;
use App\Serializers\BaseSerializer;
use Doctrine\Common\Collections\Collection as DoctrineCollection;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Criteria;
use Doctrine\Common\Collections\Expr\Comparison;
use Doctrine\ORM\EntityManager;
use League\Fractal\Manager;
use League\Fractal\Resource\Collection;
use League\Fractal\Resource\Item;
use Illuminate\Support\Facades\Log;
use DateTime;
use League\Fractal\TransformerAbstract;
use ReflectionClass;

/**
 * Class BaseService
 * @SuppressWarnings(PHPMD.CouplingBetweenObjects)
 * @SuppressWarnings(PHPMD.NumberOfChildren)
 * @package App\Services
 */
class BaseService
{
    /**
     * @var array The validation rules for data attributes on related data model
     * @see https://laravel.com/docs/5.6/validation#available-validation-rules
     */
    protected $rules = [];

    /**
     * @var array The validation messages for data attributes on related data model
     * @see https://laravel.com/docs/5.6/validation#available-validation-rules
     */
    protected $messages = [];

    /**
     * @var array The list of entity relationships which should be transformed in responses from list operations (e.g. getAll())
     */
    protected $listTransformations = [];

    /**
     * @var array The list of entity relationships which should be transformed in responses from retrieve operations (e.g. get())
     */
    protected $retrieveTransformations = [];

    /**
     * @var array The list of relationships which should be parsed during create operations (e.g. insert())
     */
    protected $createRelationships = [];

    /**
     * @var array The list of filter criteria which map to special criteria methods in the model
     * This can be useful to make relations filterable, filters that are passed which do not exist in this list will
     * be parsed using the built in Criteria methods which do not support relations (but are preferable for standard data)
     */
    protected $filterCriteria = [];

    /**
     * @var string|null
     */
    protected $model = null;

    /**
     * @var string|null
     */
    protected $modelRelationName = null;

    /**
     * @var EntityManager
     */
    protected $entityManager;

    /**
     * @var Manager
     */
    protected $transformerManager;

    /**
     * BaseService constructor.
     */
    public function __construct()
    {
        $this->entityManager = app()->make(EntityManager::class);
        $this->transformerManager = app()->make(Manager::class);
        $this->transformerManager->setSerializer(new BaseSerializer());
    }

    /**
     * Gets the validation rules associated with a given entity
     * @return array
     */
    public function getRules(): array
    {
        return $this->rules;
    }

    /**
     * Gets the validation messages associated with a given entity
     * @return array
     */
    public function getMessages(): array
    {
        return $this->messages;
    }

    /**
     * Gets the list of relationships for which data should be processed in create/update actions
     * @return array
     */
    public function getCreateRelationships(): array
    {
        return $this->createRelationships;
    }

    /**
     * Returns the fully qualified name of the model which this service manages
     * @throws \ReflectionException If reflection of the service fails
     * @return string The name of the model
     */
    public function getModel(): string
    {
        if (is_null($this->model) || !class_exists($this->model)) {
            $serviceIdentifier = str_replace('Service', '', (new ReflectionClass($this))->getShortName());

            // set available namespaces for models
            $modelNamespaces = ['Primary', 'Secondary', 'Relation', 'Storage'];
            // look for the model in each namespace and return when found
            foreach ($modelNamespaces as $modelNamespace) {
                $model = '\\App\\Models\\Entities\\' . $modelNamespace . '\\' . $serviceIdentifier;
                if (class_exists($model)) {
                    $this->model = $model;
                    break;
                }
            }
        }
        return $this->model;
    }

    /**
     * Returns the name of the model as it is referred by relations rather than the formal model name
     * @throws \ReflectionException If reflection of the service fails
     * @return string The name of the model for relations
     */
    public function getModelRelationName(): string
    {
        if (!isset($this->modelRelationName)) {
            $this->modelRelationName = (new ReflectionClass($this->getModel()))->getShortName();
        }
        return $this->modelRelationName;
    }


    /**
     * This will retrieve an entity from a given repository with a given identifier
     * @param string $repository The repository/model from which to load resources
     * @param RepositoryIdentifier $identifier The identifier to use for retrieval
     * @throws ServiceRetrieveFailureException If the entity could not be retrieved from the repository
     * @return EntityModel|null  The instance of the repository entity or null if not found
     */
    protected function getEntityFromRepository(string $repository, RepositoryIdentifier $identifier): ?EntityModel
    {
        try {
            $this->validateIdentifier($identifier);
            return $this->entityManager->getRepository($repository)->findOneBy(
                [$identifier->getField() => $identifier->getId()]
            );
        } catch (\Exception $e) {
            throw new ServiceRetrieveFailureException('An issue occurred while retrieving the data.', 0, $e);
        }
    }

    /**
     * This will return a collection of results from a given repository
     * @param EntityModel $repository The repository/model from which to load resources
     * @param RepositoryIdentifier $identifier The identifier to use for retrieval
     * @param TransformerAbstract $transformer The transformer for the repository resource
     * @param array $includes Includes to parse from the transformer
     * @throws ServiceEntityNotFoundException If the entity cannot be found with the given identifier*@see https://fractal.thephpleague.com/transformers/
     * @throws ServiceRetrieveFailureException If the entity could not be retrieved from the repository
     * @return array The resource data in an array format
     */
    protected function loadRepositoryItem($repository, RepositoryIdentifier $identifier, $transformer, $includes = null): array
    {
        $repositoryItem = $this->getEntityFromRepository($repository, $identifier);
        
        if (is_null($repositoryItem)) {
            throw new ServiceEntityNotFoundException('The entity could not be found.');
        }

        $includes = $includes ?? $this->retrieveTransformations;
    
        if (is_array($includes) && count($includes) > 0) {
            $this->transformerManager->parseIncludes($includes);
        }

        $resourcesItem = new Item($repositoryItem, $transformer);
         
        return $this->transformerManager->createData($resourcesItem)->toArray();
    }

    /**
     * This will retrieve a collection of entities from a given repository
     * @SuppressWarnings(PHPMD.ElseExpression)
     * @SuppressWarnings(PHPMD.StaticAccess)
     *
     * @param string $repository The repository/model from which to load resources
     * @param RepositoryFilter[] $filters Any filters which should be applied to the result set
     * @throws ServiceRetrieveFailureException If some unexpected issue occurred such as a database or connection issue
     * @return array An array of instances of the repository entity
     */
    protected function getEntityCollectionFromRepository(string $repository, $filters = []): array
    {
        try {
            // if there are no filters, just return all results
            if (sizeof($filters) < 1) {
                return $this->entityManager->getRepository($repository)->findAll();
            }

            // TODO: VALIDATE FORMAT OF CRITERIA ELSE THROW EXCEPTION

            // split filters into natural filters and filters mapped to model-defined criteria
            $naturalFilters = [];
            $filtersWithModelCriteria = [];
            foreach ($filters as $filter) {
                if (in_array($filter->getField(), array_keys($this->filterCriteria))) {
                    $filtersWithModelCriteria[] = $filter;
                } else {
                    $naturalFilters[] = $filter;
                }
            }

            // process any natural filters
            if (sizeof($naturalFilters) > 0) {
                $criteria = Criteria::create();
                foreach ($naturalFilters as $i => $filter) {
                    if ($i == 0) {
                        $criteria->where($this->parseCriteria($filter));
                    } else {
                        $criteria->andWhere($this->parseCriteria($filter));
                    }
                }
                $results = $this->entityManager->getRepository($repository)->matching($criteria);
            } else {
                $results = new ArrayCollection($this->entityManager->getRepository($repository)->findAll());
            }

            // apply any model-defined-criteria based filters
            if (sizeof($filtersWithModelCriteria) > 0) {
                foreach ($filtersWithModelCriteria as $filter) {
                    $filteredResults = $results->filter(
                        function ($result) use ($filter) {
                            return $result->{$this->filterCriteria[$filter->getField()]}($filter->getValue());
                        }
                    );
                    $results = $filteredResults;
                }
            }

            return $results->toArray();
        } catch (\Exception $e) {
            throw new ServiceRetrieveFailureException('An issue occurred while retrieving the data.', 0, $e);
        }
    }

    /**
     * This will return a transformed collection of results from a given repository
     * @param EntityModel $repository The repository/model from which to load resources
     * @param TransformerAbstract $transformer The transformer for the repository resource
     * @param array $includes Includes to parse from the transformer @see https://fractal.thephpleague.com/transformers/
     * @param RepositoryFilter[] $filters Any filters which should be applied to the result set
     * @throws ServiceRetrieveFailureException If the entity could not be retrieved from the repository
     * @return array The resource data in an array format
     */
    protected function loadRepositoryCollection($repository, $transformer, $includes = null, $filters = []): array
    {
        
        $repositoryResources = $this->getEntityCollectionFromRepository($repository, $filters);
        $repositoryCollection = collect($repositoryResources);
        
        $includes = $includes ?? $this->listTransformations;
    
        if (is_array($includes) && count($includes) > 0) {
            $this->transformerManager->parseIncludes($includes);
        }

        $resourcesCollection = new Collection($repositoryCollection, $transformer);
        return $this->transformerManager->createData($resourcesCollection)->toArray();
    }

    /**
     * Parses filters from given request inputs and returns parsed RepositoryFilter objects
     *
     * @param array $inputs The inputs to use to prepare the filters
     * @return RepositoryFilter[] The parsed filters
     */
    protected function prepareFiltersFromInputs(array $inputs = []): array
    {
        $filters = [];
        if (array_key_exists('filter', $inputs) && sizeof($inputs['filter']) > 0) {
            foreach ($inputs['filter'] as $filter) {
                if (array_key_exists('field', $filter) && (array_key_exists('value', $filter) xor array_key_exists('values', $filter))) {
                    $filterValue = (array_key_exists('value', $filter)) ? $filter['value'] : $filter['values'];
                    $filters[] = (array_key_exists('comparison', $filter)) ?
                        new RepositoryFilter($filter['field'], $filterValue, $filter['comparison']) :
                        new RepositoryFilter($filter['field'], $filterValue);
                }
            }
        }
        return $filters;
    }

    /**
     * This will insert the given entity into the database
     * @param array $inputs The data provided for the request
     * @param EntityModel|null $entity The entity from which to create
     * @param \League\Fractal\TransformerAbstract $transformer The transformer for the repository resource
     * @param array $includes Includes to parse from the transformer
     * @param int $depth The maximum depth into the data structure to traverse for creation
     * @throws ServiceValidationFailureException If validation of the relation data fails
     * @throws ServiceCreateFailureException If insertion failed for some reason other than validation
     * @throws ServiceEntityNotFoundException If the passed entity does not exist
     * @see https://fractal.thephpleague.com/transformers/
     * @return array The newly created entity data
     */
    protected function insert(array $inputs, ?EntityModel $entity, TransformerAbstract $transformer, array $includes = null, int $depth = 3): array
    {
        // ensure that the entity exists and the input is valid
        if (is_null($entity)) {
            throw new ServiceEntityNotFoundException('The entity could not be found.');
        }
    
        $this->validateRequest($inputs);
        
        try {
            // map updated data to a new instance of the entity and add it to the queue for persistence
            $preparedEntity = $this->mapRequestToEntity($inputs, $entity);
            $this->entityManager->persist($preparedEntity);
              
            // get all relationship data defined for the entity
            if ($depth > 0) {
                $relations = array_intersect_key($this->getCreateRelationships(), $inputs);

                foreach ($relations as $key => $relation) {
                    if (array_key_exists($key, $inputs) && !is_null($inputs[$key])) {
                        $this->insertRelation($preparedEntity, new $relation(), $inputs[$key], $depth - 1);
                    }
                }
            }

            // commit the transaction
            $this->entityManager->flush();
        } catch (\Exception $e) {
            throw new ServiceCreateFailureException($e->getMessage(), $e->getCode(), $e->getPrevious());
        }

        // run the transformer on the resulting data so that the output is consistent with what we get from retrieve operations
        // use the same includes as retrieve operation if not overridden
        $includes = $includes ?? $this->retrieveTransformations;
        $this->transformerManager->parseIncludes($includes);
        $resourcesItem = new Item($preparedEntity, $transformer);
        return $this->transformerManager->createData($resourcesItem)->toArray();
    }

    /**
     * This will update the given entity into the database
     *
     * @param array $inputs The data provided for the request
     * @param VersionedModel|null $entity The entity to update
     * @param TransformerAbstract $transformer The transformer for the repository resource
     * @param array $includes Includes to parse from the transformer
     * @param int $depth The maximum depth into the data structure to traverse for modifications
     * @throws ServiceEntityNotFoundException If the passed entity does not exist
     * @throws ServiceValidationFailureException If the entity is invalid
     * @throws ServiceUpdateFailureException If the update failed for some reason other than validation
     * @see https://fractal.thephpleague.com/transformers/
     * @return array The updated entity data
     */
    protected function modify(array $inputs, ?VersionedModel $entity, TransformerAbstract $transformer, $includes = null, int $depth = 2): array
    {
        if (is_null($entity)) {
            throw new ServiceEntityNotFoundException('The entity could not be found.');
        }

        // validate the properties of the entity overridden with new properties send in request
        $this->validateRequest($this->mapEntityPropertiesToArray($entity, $inputs));

        try {
            // first, create an expired copy of the current state of the entity
            $entityExpiredCopy = $this->prepareEntityForDelete(clone $entity);
            $this->entityManager->persist($entityExpiredCopy);

            // NOTE: we must persist here to get the auto-generated id
            // it will attempt to rollback if this fails
            $this->entityManager->flush();

            // set the previousId to the id for the expired version that was just created
            // this previousId will reference the entities version history
            $entity->setPreviousId($entityExpiredCopy->getId());

            // next prepare the original entity with updates
            // the entity must be reset as if it were a new entity so that the current entity becomes the new version
            $entity = $this->prepareEntityForInsert(
                $this->mapRequestToEntity($inputs, $entity)
            );

            // next handle any relationships attached to the entity
            if ($depth > 0) {
                $existingData = $this->mapEntityPropertiesToArray($entity);
                $relations = array_intersect_key($this->getCreateRelationships(), $inputs);

                foreach ($relations as $key => $relation) {
                    // ensure that existing data is in an array format
                    $this->updateRelation($entity, $existingData[$key], new $relation(), $inputs[$key], $depth - 1);
                }
            }

            $this->entityManager->flush();
        } catch (\Throwable $e) {
            // attempt to rollback the expired version of the entity which was created
            try {
                if (isset($entityExpiredCopy)) {
                    $this->entityManager->remove($entityExpiredCopy);
                    $this->entityManager->flush();
                }
            } catch (\Exception $e) {
                Log::error('Failed to rollback expired version created during failed entity update.  Check database for orphans. Original entity: ' . print_r($entity, true));
            }
            dd($e);
            throw new ServiceUpdateFailureException('The new version of the entity could not be created.', $e->getCode(), $e->getPrevious());
        }

        // run the transformer on the resulting data so that the output is consistent with what we get from retrieve operations
        // use the same includes as retrieve operation if not overridden
        $includes = $includes ?? $this->retrieveTransformations;
        $this->transformerManager->parseIncludes($includes);
        $resourcesItem = new Item($entity, $transformer);
        return $this->transformerManager->createData($resourcesItem)->toArray();
    }

    /**
     * This will expire the given entity
     * @param EntityModel|null $entity The entity to expire
     * @throws ServiceExpireFailureException If the expire failed for some reason other than validation
     * @throws ServiceEntityNotFoundException If the passed entity does not exist
     * @return void
     */
    protected function expire(?EntityModel $entity): void
    {
        if (is_null($entity)) {
            throw new ServiceEntityNotFoundException('The entity could not be found.');
        }
        try {
            $this->prepareEntityForDelete($entity);
            $this->entityManager->flush();
        } catch (\Exception $e) {
            throw new ServiceExpireFailureException($e->getMessage(), $e->getCode(), $e->getPrevious());
        }
    }

    /**
     * Handles the insert of a relation to a given model
     * @param EntityModel $owner The owning entity of the relation (already prepared with any pending changes)
     * @param BusinessModelService $service The service for the owning entity
     * @param array $inputs Input data for the new relation
     * @param int $depth The maximum depth into the data structure to traverse for creation
     * @throws ServiceCreateFailureException If there is no method on the owning model to add the relation
     * @throws ServiceValidationFailureException If validation of the relation data fails
     * @return void
     */
    private function insertRelation(EntityModel $owner, BusinessModelService $service, array $inputs, int $depth = 1)
    {
        // get the service for the relation and some other general info about the service
        $model = $service->getModel();
        $addMethod = 'add' . $service->getModelRelationName();

        // if the main entity does not have an "add" method for the relation, then it cannot be added
        if (!method_exists($owner, $addMethod)) {
            throw new ServiceCreateFailureException('Model ' . class_basename($owner) . ' does not provide method to add ' . $service->getModelRelationName() . ' relation.');
        }

        // persist a new instance of the relation for each data collection
        foreach ($inputs as $relationData) {
            $preparedRelation = null;

            // if the relationship is an association with an existing one - get that instance of the relationship
            if (array_key_exists('id', $relationData) && !is_null($relationData['id'])) {
                try {
                    $preparedRelation = $this->entityManager->find($model, $relationData['id']);
                    $owner->$addMethod($preparedRelation);
                } catch (\Throwable $e) {
                    Log::warning('Insert relationship passed with ID that failed lookup so was created as new entity instead.  Owning model: ' . print_r(get_class($owner), true) . ', Created Relation: ' . print_r($model, true));
                }
            }

            // if the relationship was not an existing one, create the entity and relate it
            if (is_null($preparedRelation)) {
                // validate the data provided for this relation and prepare it for persistence
                $this->validateRequest($relationData, $service->getRules());
                $preparedRelation = $this->mapRequestToEntity($relationData, new $model(), array_merge(array_keys($service->getRules()), ['id']));

                // add the relation to the owner and persist it
                $owner->$addMethod($preparedRelation);
                $this->entityManager->persist($preparedRelation);
            }

            // if the next level of relationships should also be persisted, recurse
            if ($depth > 0) {
                $subRelations = array_intersect_key($service->getCreateRelationships(), $relationData);
                foreach ($subRelations as $subKey => $subRelation) {
                    // NOTE: By default insertRelation will not recurse, so this will never recurse more than once
                    // If we need to recurse more than once, we will need to implement a depth that can be set
                    $this->insertRelation($preparedRelation, new $subRelation(), $relationData[$subKey], $depth - 1);
                }
            }
        }
    }

    /**
     * Handles the update of a relation to a given model
     * @SuppressWarnings(PHPMD.ElseExpression)
     * @SuppressWarnings(PHPMD.CyclomaticComplexity)
     *
     * @param EntityModel $owner The owning entity of the relation (already prepared with any pending changes)
     * @param DoctrineCollection $existingData The data which is currently stored for the owning entity
     * @param BusinessModelService $service The service for the owning entity
     * @param array $inputs Input data for the new relation
     * @param int $depth The maximum depth into the data structure to traverse for modifications
     * @throws ServiceRetrieveFailureException If the entity could not be retrieved
     * @throws ServiceCreateFailureException If there is no method on the owning model to add the relation
     * @throws ServiceValidationFailureException If validation of the relation data fails
     * @return void
     */
    private function updateRelation(EntityModel $owner, DoctrineCollection $existingData, BusinessModelService $service, array $inputs, int $depth = 1): void
    {
        // get the service for the relation and some other general info about the service
        $model = $service->getModel();
        $existingData = $existingData->getValues();

        // handle any any relations that were removed
        // NOTE: THIS MUST BE DONE BEFORE HANDLING EDITED OR NEW RELATIONS
        // Since removed relations don't have an id assigned in the input BUT WILL in the entity, they will be flagged as removed immediately after being added
        $inputRelationIds = array_column($inputs, 'id');
        foreach ($existingData as $rel) {
            if (method_exists($rel, 'getId') && !in_array($rel->getId(), $inputRelationIds)) {
                $this->prepareEntityForDelete($rel);
            }
        }

        // handle any relations that were edited or added
        foreach ($inputs as $relationData) {
            // validate the data provided for this relation
            $this->validateRequest($relationData, $service->getRules());

            // if this is a new relation
            if (!isset($relationData['id']) || is_null($relationData['id']) || !$this->objectExistsInArray($relationData['id'], $existingData)) {
                // get reference to "add" method - this is done here since we only need it if we are adding a new relation
                $addMethod = 'add' . $service->getModelRelationName();

                // if the main entity does not have an "add" method for the relation, then it cannot be added
                if (!method_exists($owner, $addMethod)) {
                    throw new ServiceCreateFailureException('Model ' . class_basename($owner) . ' does not provide method to add ' . $service->getModelRelationName() . ' relation.');
                }

                // if the new relationship is an association with an existing entity - get that instance of the relationship
                // else, this is a relationship being defined with a new entity - so the entity must be created as well
                if (array_key_exists('id', $relationData) && !is_null($relationData['id'])) {
                    try {
                        $preparedRelation = $this->entityManager->find($model, $relationData['id']);
                        $owner->$addMethod($preparedRelation);
                    } catch (\Throwable $e) {
                        Log::warning('Update relationship passed with ID that failed lookup so was created as new entity instead.  Owning model: ' . print_r(get_class($owner), true) . ', Created Relation: ' . print_r($model, true));
                    }
                } else {
                    // prepare the relation for persistence
                    $preparedRelation = $this->mapRequestToEntity($relationData, new $model(), array_keys($service->getRules()));
                    // add the relation to the entity and persist it
                    $owner->$addMethod($preparedRelation);
                    $this->entityManager->persist($preparedRelation);
                }
            } else {
                // otherwise this is an existing relation
                // see if the relation is updated
                $relationUpdated = false;
                $relationModel = $this->getEntityFromRepository($model, new RepositoryIdentifier($relationData['id']));
                $existingRelationData = $this->mapEntityPropertiesToArray($relationModel);
                foreach ($relationData as $field => $data) {
                    // ignore any fields that don't exist in the relation data structure
                    if (!array_key_exists($field, $existingRelationData)) {
                        continue;
                    }
                    // if this property is not an object and is changed, set relation to be updated
                    if (!is_object($existingRelationData[$field]) && $data !== $existingRelationData[$field]) {
                        $relationUpdated = true;
                    } elseif (
                        // if this property is an object which has an id and we have an id property for data, compare the id with the data to detect a changed element
                        // NOTE: DOES DATA['ID'] WORK HERE?  ISN'T DATA['OBJECT_KEY'] A COPY OF THE ORIGINAL OBJECT?
                        is_object($existingRelationData[$field]) && is_array($data) &&
                        method_exists($existingRelationData[$field], 'getId') && array_key_exists('id', $data) &&
                        $existingRelationData[$field]->getId() != $data['id']
                    ) {
                        $relationUpdated = true;
                    }
                }

                // if there was a data change in the relation, persist the change
                $preparedRelation = $relationModel;
                if ($relationUpdated) {
                    // create an expired copy of the current state of the relationship and prepare it for persistence
                    $relationshipExpiredCopy = $this->prepareEntityForDelete(clone $relationModel);
                    $this->entityManager->persist($relationshipExpiredCopy);

                    // update and prepare the original relation for persistence
                    // the entity must be reset as if it were a new entity so that the current entity becomes the new version
                    $preparedRelation = $this->mapRequestToEntity($relationData, $relationModel, array_keys($service->getRules()));

                    // finally, reset the relation to be same as a new one
                    $this->prepareEntityForInsert($preparedRelation);
                }
            }

            // if the next level of relationships should also be persisted, recurse
            if ($depth > 0 && isset($preparedRelation)) {
                $subExistingData = $this->mapEntityPropertiesToArray($preparedRelation);
                $subRelations = array_intersect_key($service->getCreateRelationships(), $relationData);

                foreach ($subRelations as $subKey => $subRelation) {
                    // NOTE: By default insertRelation will not recurse, so this will never recurse more than once
                    // If we need to recurse more than once, we will need to implement a depth that can be set
                    // ensure that existing data is in an array format
                    $this->updateRelation($preparedRelation, $subExistingData[$subKey], new $subRelation(), $relationData[$subKey], $depth - 1);
                }
            }
        }
    }

    /**
     * This will prepare a given entity for deletion
     * @param IdentifiableModel $entity The entity or relation to prepare
     * @return IdentifiableModel The prepared entity or relation
     * @throws \Exception If the date fails to create
     */
    private function prepareEntityForDelete(IdentifiableModel $entity): IdentifiableModel
    {
        if (method_exists($entity, 'setDateTo')) {
            $entity->setDateTo(new DateTime());
        }
        return $entity;
    }

    /**
     * This will prepare a given entity for insertion
     * @param EntityModel $entity The entity to prepare
     * @return EntityModel The prepared entity
     */
    private function prepareEntityForInsert(EntityModel $entity): EntityModel
    {
        if (method_exists($entity, 'setDateFrom')) {
            $entity->setDateFrom(null);
        }
        return $entity;
    }

    /**
     * This will check if a given object exists in an array of objects
     * @param mixed $needle The object which should be checked
     * @param object[] $haystack The array which should be searched
     * @param string $comparator The comparator which should be used to compare the objects
     * @return bool True if it exists
     */
    private function objectExistsInArray($needle, array $haystack, string $comparator = 'id'): bool
    {
        foreach ($haystack as $el) {
            $method = 'get' . ucfirst($comparator);
            if (method_exists($el, $method) && $needle == $el->$method()) {
                return true;
            }
        }
        return false;
    }

    /**
     * This will map request variables to a given entity to prepare for storage
     * @param array $inputs The data provided for the request
     * @param EntityModel $entity The entity to which to map the request variables
     * @param array|null $fields The fields to map
     * @param array $relations The relations to map
     * @return EntityModel The given entity with the request variables mapped
     */
    private function mapRequestToEntity(array $inputs, EntityModel $entity, ?array $fields = null, array $relations = []): EntityModel
    {
        // if no fields array is provided, default to the keys of the rules array
        $fields = (!is_array($fields)) ? array_keys($this->rules) : $fields;

        // handle direct properties
        foreach ($fields as $field) {
            $ruleMethod = 'set' . ucfirst($field);
            if (method_exists($entity, $ruleMethod) && isset($inputs[$field])) {
                $entity->{$ruleMethod}($inputs[$field]);
            }
        }

        // handle relationships
        foreach ($relations as $relation => $relationServiceName) {
            $ruleMethod = 'set' . ucfirst($relation);

            // NOTE: this will only recur once for performance reasons and because there are no cases where
            // an entity should be manipulating the data of relationships two or more levels deep
            if (in_array($relation, array_keys($inputs)) && is_array($inputs[$relation]) && method_exists($entity, $ruleMethod)) {
                $relationService = new $relationServiceName();
                if ($relationService instanceof BaseService) {
                    $relationModel = $relationService->getModel();
                    $relation = $this->mapRequestToEntity($inputs[$relation], new $relationModel(), ['id']);
                    $entity->{$ruleMethod}($relation);
                }
            }
        }
        return $entity;
    }

    /**
     * This will map all variables existing on an entity to a returned array
     * @param EntityModel $entity The entity from which to variables should be loaded
     * @param array $fields Any specific values which should override the corresponding values in the entity
     * @return array An array of properties from the entity
     */
    private function mapEntityPropertiesToArray(EntityModel $entity, array $fields = []): array
    {
        $properties = [];
        $methods = get_class_methods($entity);
        foreach ($methods as $method) {
            // only process getters
            if (substr($method, 0, 3) === 'get' || substr($method, 0, 3) === 'has') {
                $property = lcfirst(substr($method, 3));
                $properties[$property] = (array_key_exists($property, $fields)) ? $fields[$property] : $entity->$method();
            } elseif (substr($method, 0, 2) === 'is') {
                $property = lcfirst(substr($method, 2));
                $properties[$property] = (array_key_exists($property, $fields)) ? $fields[$property] : $entity->$method();
            }
        }
        return $properties;
    }

    /**
     * Parses a single criteria comparison based on given value and comparison type
     * @param RepositoryFilter $criteria The criteria to parse
     * @return Comparison
     */
    private function parseCriteria(RepositoryFilter $criteria): Comparison
    {
        switch ($criteria->getComparison()) {
            case '=':
                return Criteria::expr()->eq($criteria->getField(), $criteria->getValue());

            case '!=':
                return Criteria::expr()->neq($criteria->getField(), $criteria->getValue());

            case '>':
                return Criteria::expr()->gt($criteria->getField(), $criteria->getValue());

            case '>=':
                return Criteria::expr()->gte($criteria->getField(), $criteria->getValue());

            case '<':
                return Criteria::expr()->lt($criteria->getField(), $criteria->getValue());

            case '<=':
                return Criteria::expr()->lte($criteria->getField(), $criteria->getValue());

            case 'in':
                return Criteria::expr()->in($criteria->getField(), $criteria->getValue());

            case '!in':
                return Criteria::expr()->notIn($criteria->getField(), $criteria->getValue());

            default:
                if (is_array($criteria->getValue())) {
                    return Criteria::expr()->in($criteria->getField(), $criteria->getValue());
                }
                return Criteria::expr()->eq($criteria->getField(), $criteria->getValue());
        }
    }

    /**
     * This will validate a given identifier for an entity
     * @param RepositoryIdentifier $identifier The identifier to validate
     * @throws ServiceEntityNotFoundException If the identifier is invalid
     * @return void
     */
    private function validateIdentifier(RepositoryIdentifier $identifier): void
    {
        if (!$identifier instanceof RepositoryIdentifier) {
            throw new ServiceEntityNotFoundException('No identifier was provided for the entity.');
        }

        if (!$identifier->validate()) {
            throw new ServiceEntityNotFoundException('The identifier provided for the entity was of invalid type.');
        }
    }

    /**
     * This will validate the given request variables against the validation rules given
     * @param array $inputs The data provided for the request
     * @param array $rules The rules to validate against
     * @param array $messages The messages to display for validation errors
     * @throws ServiceValidationFailureException If validation of the data fails
     * @return void
     */
    private function validateRequest(array $inputs, array $rules = null, array $messages = null): void
    {
        $rules = (!is_array($rules)) ? $this->rules : $rules;
        $messages = (!is_array($messages)) ? $this->messages : $messages;

        $validator = app('validator')->make($inputs, $rules, $messages);
        
        
        if ($validator->fails()) {
            throw new ServiceValidationFailureException('The entity could not be created.', $validator->errors());
        }
    }
}
