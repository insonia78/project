<?php

namespace App\Http\GraphQL\Mutations;

class UploadFile
{
    /**
     * Upload a file, store it on the server and return the path.
     *
     * @param  mixed  $root
     * @param  mixed[]  $args
     * @return string|null
     */
    public function resolve($root, array $args): ?string
    {    
        /** @var \Illuminate\Http\UploadedFile $file */
        $file = $args['file'];
            
        return $file->storePublicly('uploads');
    }
}
