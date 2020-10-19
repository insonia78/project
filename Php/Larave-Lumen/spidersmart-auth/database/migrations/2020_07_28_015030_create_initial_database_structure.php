<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateInitialDatabaseStructure extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        // create all tables
        Schema::create('permission', function (Blueprint $table) {
            $table->increments('id');
            $table->string('title', 100)->notNullable();
            $table->string('description', 100)->nullable();
            $table->timestamp('date_from')->useCurrent();
            $table->timestamp('date_to')->nullable();
            $table->boolean('is_active')->default(true);
            $table->integer('previous_id')->unsigned()->nullable()->index();
        });
        Schema::create('role', function (Blueprint $table) {
            $table->increments('id');
            $table->string('title', 100)->notNullable();
            $table->string('description', 100)->nullable();
            $table->timestamp('date_from')->useCurrent();
            $table->timestamp('date_to')->nullable();
            $table->boolean('is_active')->default(true);
            $table->integer('previous_id')->unsigned()->nullable()->index();
        });
        Schema::create('role_permission', function (Blueprint $table) {
            $table->integer('role_id')->unsigned()->index();
            $table->integer('permission_id')->unsigned()->index();
            $table->timestamp('date_from')->useCurrent();
            $table->timestamp('date_to')->nullable();
        });
        Schema::create('user_auth', function (Blueprint $table) {
            $table->integer('id')->unsigned()->index();
            $table->string('username', 100)->unique()->notNullable();
            $table->string('password', 100)->notNullable();
            $table->boolean('is_active')->default(true);
        });
        Schema::create('user_role', function (Blueprint $table) {
            $table->integer('user_id')->unsigned()->index();
            $table->integer('role_id')->unsigned()->index();
            $table->timestamp('date_from')->useCurrent();
            $table->timestamp('date_to')->nullable();
        });

        // set foreign keys for tables
        Schema::table('role_permission', function (Blueprint $table) {
            $table->foreign('role_id')
                ->references('id')->on('role')
                ->onUpdate('cascade')
                ->onDelete('cascade');
            $table->foreign('permission_id')
                ->references('id')->on('permission')
                ->onUpdate('cascade')
                ->onDelete('cascade');
        });
        Schema::table('user_auth', function (Blueprint $table) {
            $table->foreign('id')
                ->references('id')->on('user')
                ->onUpdate('cascade')
                ->onDelete('cascade');
        });
        Schema::table('user_role', function (Blueprint $table) {
            $table->foreign('user_id')
                ->references('id')->on('user')
                ->onUpdate('cascade')
                ->onDelete('cascade');
            $table->foreign('role_id')
                ->references('id')->on('role')
                ->onUpdate('cascade')
                ->onDelete('cascade');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        // remove foreign keys
        Schema::table('user_role', function (Blueprint $table) {
            $table->dropForeign('user_role_user_id_foreign');
            $table->dropForeign('user_role_role_id_foreign');
        });
        Schema::table('user_auth', function (Blueprint $table) {
            $table->dropForeign('user_auth_user_id_foreign');
        });
        Schema::table('role_permission', function (Blueprint $table) {
            $table->dropForeign('role_permission_role_id_foreign');
            $table->dropForeign('role_permission_permission_id_foreign');
        });

        // drop tables
        Schema::dropIfExists('permission');
        Schema::dropIfExists('role');
        Schema::dropIfExists('role_permission');
        Schema::dropIfExists('user_auth');
        Schema::dropIfExists('user_permission');
    }
}
