<?php

/*
|--------------------------------------------------------------------------
| Application Routes
|--------------------------------------------------------------------------
|
| Here is where you can register all of the routes for an application.
| It is a breeze. Simply tell Lumen the URIs it should respond to
| and give it the Closure to call when that URI is requested.
|
*/

$api = app('Dingo\Api\Routing\Router');
$api->version('v1', [], function ($api) {
    //$api->post('/graphql', ['uses' => 'Nuwave\Lighthouse\Support\Http\Controllers\GraphQLController@query']);
});