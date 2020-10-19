<?php

namespace App\Services;

use App\Contracts\BusinessModelService;
use App\Exceptions\ServiceEntityNotFoundException;
use App\Helpers\RepositoryIdentifier;
use App\Models\Entities\Primary\Book;
use App\Transformers\BookTransformer;
use Illuminate\Support\Facades\File;
use Illuminate\Support\Facades\Storage;
use Illuminate\Support\Facades\URL;
use Symfony;

/**
 * Class BookService
 * @package App\Services
 */
class BookService extends BaseService implements BusinessModelService
{
    /**
     * @inheritDoc
     */
    protected $rules = [
        'title' => 'required|string',
        'description' => 'string',
        'isbn' => 'required|string',
        'coverImage' => 'string',
        'active' => 'int'
    ];

    /**
     * @inheritDoc
     */
    protected $createRelationships = [
        'authors' => \App\Services\AuthorService::class,
        'publishers' => \App\Services\PublisherService::class,
        'genres' => \App\Services\GenreService::class
    ];

    /**
     * Retrieve a book from given input data
     *
     * @param array $inputs The data provided for the request
     * @throws \App\Exceptions\ServiceEntityNotFoundException If no identifier was provided to validate
     * @return array The data returned for the entity
     */
    public function get(array $inputs = [])
    {        
        // show "deleted" information to show full history of book
        if (isset($inputs['showDeleted']) && $inputs['showDeleted'] == 'true') {
            $this->entityManager->getFilters()->disable('soft-deleteable');
        }

        // support lookup by id or label
        if (!isset($inputs['id'])) {
            throw new ServiceEntityNotFoundException('No identifier was provided to find the entity.');
        }

        return $this->loadRepositoryItem(
            Book::class,
            new RepositoryIdentifier($inputs['id']),
            new BookTransformer(),
            ['authors', 'publishers', 'genres', 'assignment', 'assignment.level']
        );       
    }

    /**
     * Retrieve all books
     *
     * @return array An array of returned entities
     */
    public function getAll()
    {
        return $this->loadRepositoryCollection(
            Book::class,
            new BookTransformer(),
            ['assignment', 'assignment.level']
        );
    }

    /**
     * Create a new book
     *
     * @param array $inputs The data provided for the request
     * @return array The newly created entity data
     */
    public function create(array $inputs)
    {    
        
        $file = $inputs['file']; 
        if(isset($file))
        { 
            $uniqid = uniqid().'_'.date('Ymd');
            $fileName = $file->getClientOriginalName();
            
            for($i = 1 ; $i < strlen($fileName)-1 ; $i++ )
            {
                if($fileName[$i] == ' ') 
                {
                    $fileName[$i] = '_' ;
                }
            }            
            
            $fileName = $uniqid.'_'.$fileName;
            
            if(!$file->move(public_path('image/book/'),$file->getClientOriginalName()))
            {
                print("file did not move");
                return false;
            } 
            if(!rename(public_path('image/book/').$file->getClientOriginalName(),public_path('image/book/').$fileName))
            {
                print 'something went wrong';
                return false;
            }                            
            
            $inputs['coverImage'] = url('image/book/'.$fileName);            
        }           
        return $this->insert(
            $inputs,
            new Book(),
            new BookTransformer()
        );
    }    
    /**
     * Updates a book with given information
     *
     * @param array $inputs The data provided for the request
     * @return array The updated entity data
     */
    public function update(array $inputs)
    {
        $file = $inputs['file']; 
        if(isset($file))
        {                     
            $success = $file->StoreAs('bookImage', $file->getClientOriginalName());
            if(!$success)
                return $success;
        }        
        return $this->modify(
            $inputs,
            $this->getEntityFromRepository(Book::class, new RepositoryIdentifier($inputs['id'])),
            new BookTransformer()
        );
    }

    /**
     * Deletes a given book
     *
     * @param array $inputs The data provided for the request
     *
     * @return void
     */
    public function delete(array $inputs)
    {
        $this->expire(
            $this->getEntityFromRepository(Book::class, new RepositoryIdentifier($inputs['id']))
        );
    }
}
