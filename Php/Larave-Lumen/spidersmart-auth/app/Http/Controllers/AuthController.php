<?php

namespace App\Http\Controllers;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Auth;
use Illuminate\Http\Request;
use Lcobucci\JWT\Parser;
use  App\User;

class AuthController extends Controller
{
    /**
     * Store a new user.
     *
     * @param  Request  $request
     * @return Response
     */
    public function register(Request $request)
    {
        //validate incoming request
        $this->validate($request, [
            'id' => 'required|integer|unique:user_auth,id',
            'username' => 'required|unique:user_auth,username',
            'password' => 'required',
        ]);

        try {
            $user = new User;
            $user->id = $request->input('id');
            $user->username = $request->input('username');
            $plainPassword = $request->input('password');
            $user->password = app('hash')->make($plainPassword);

            $user->save();

            //return successful response
            return response()->json(['user' => $user, 'message' => 'CREATED'], 201);

        } catch (\Exception $e) {
            //return error message
            dd($e);
            return response()->json(['message' => 'User Registration Failed!'], 409);
        }

    }

    /**
     * Get a JWT via given credentials.
     *
     * @param  Request  $request
     * @return Response
     */
    public function login(Request $request)
    {
        try
        {
            //validate incoming request
            $this->validate($request, [
                'username' => 'required|string',
                'password' => 'required|string',
            ]);

            $credentials = $request->only(['username', 'password']);


            if (! $token = Auth::attempt($credentials)) {
                return response()->json(['message' => 'Unauthorized'], 401);
            }

            return $this->respondWithToken($token);
        }catch (\Exception $e) {

            //dd($e);
            //return error message
            return response()->json(['message' => 'Login Failed!'], 409);
        }

    }
    public function authenticateToken()
    {
        try
        {
            //validate incoming request

            dd($request);
            //return response('Authorized', 200);

        }catch (\Exception $e) {


            //return error message
            return response('Unauthorized', 401);
        }

    }
    public function logout(Request $request,$id)
    {
        try
        {                         
            $response = DB::table('oauth_access_tokens')->where('id', '=', $id)->update(['revoked' => 1]);
            $response = DB::table('oauth_refresh_tokens')->where('access_token_id', '=', $id)->update(['revoked' => 1]);
            return response($response, 200);
        }catch (\Exception $e) {
            //return error message
            dd($e);
            return response('Unauthorized', 401);
        }

    }

}
