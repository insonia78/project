<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Auth;
use App\User;
//use Validator;

class UsersController extends Controller
{

    
    // public function register(Request $request)
    // {
    //     $validator = Validator::make($request->all(), [
    //         'username' => 'required',
    //         'password' => 'required'
    //     ]);//validate incoming request            
        
    //     $this->validate($request, [
    //         'username' => 'required|string',
    //         'password' => 'required|string',
    //     ]);

    //     if($validator->fails()){
    //         return response(['message' => 'Validation errors', 'errors' =>  $validator->errors(), 'status' => false], 422);
    //     }

    //     $input = $request->all();
    //     $input['password'] = Hash::make($input['password']);
    //     $user = User::create($input);
      
    //     /**Take note of this: Your user authentication access token is generated here **/
    //     $data['token'] =  $user->createToken('MyApp')->accessToken;
    //     $data['name'] =  $user->name;

    //     return response(['data' => $data, 'message' => 'Account created successfully!', 'status' => true]);
    // }  

    public function login(Request $request)
    {
        try
        {
            $loginData = $request->validate([
                'username' => 'required',
                'password' => 'required'
            ]);

            if (!auth()->attempt($loginData)) {
                return response(['message' => 'Invalid Credentials']);
            }

            $accessToken = auth()->user()->createToken('authToken')->accessToken;

            return response(['user' => auth()->user(), 'access_token' => $accessToken]);
        }catch (\Exception $e) {
            
            dd($e);
            //return error message
            return response()->json(['message' => 'Login Failed!'], 409);
        }

    }
     
}