<?php

/** @var \Laravel\Lumen\Routing\Router $router */

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

$router->get('/', function () use ($router) {
    return view('login');
});
//$router->post('/login','UsersController@login');
$router->get('authenticateToken', 'AuthController@authenticateToken');
$router->post('register', 'AuthController@register');
 
$router->group(['prefix'=>'api','middleware' => 'auth'],function() use ($router){
   $router->post('login', 'AuthController@login');
   $router->get('authenticateToken', 'AuthController@authenticateToken');
   $router->get('logout/{id}','AuthController@logout');
});
