<?php

namespace App\Providers;

use DateTime;
use Dusterio\LumenPassport\LumenPassport;
use Carbon\Carbon;
use Laravel\Passport\Passport;
use App\User;
use Illuminate\Support\Facades\Gate;
use Illuminate\Support\ServiceProvider;
//use Illuminate\Foundation\Support\Providers\AuthServiceProvider as ServiceProvider;
class AuthServiceProvider extends ServiceProvider
{
    /**
     * Register any application services.
     *
     * @return void
     */
    public function register()
    {
        //
    }

    /**
     * Boot the authentication services for the application.
     *
     * @return void
     */
    public function boot()
    {
        // Here you may define how you wish users to be authenticated for your Lumen
        // application. The callback which receives the incoming request instance
        // should return either a User instance or null. You're free to obtain
        // the User instance via an API token or any other method necessary.
       // $this->registerPolicies();
         
        LumenPassport::tokensExpireIn(Carbon::now()->addMinutes(480),2);
       // LumenPassport::tokensExpireIn(Carbon::now()->addYears(50), 2);
        $this->app['auth']->viaRequest('api', function ($request) {
            if ($request->input('api_token')) {
                return User::where('api_token', $request->input('api_token'))->first();
            }
        });
    }
}
