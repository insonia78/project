<?php

use Illuminate\Database\Seeder;

class CenterSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('center')->delete();

        DB::table('center')->insert([
           [
               'id' => 1,
               'label' => 'tysons-corner',
               'name' => 'Tysons Corner',
               'type' => 'local',
               'street_address' => '8300 Old Courthouse Road',
               'city' => 'Vienna',
               'state' => 'VA',
               'postal_code' => '22182',
               'phone' => '7033563141',
               'country' => 'USA',
               'latitude' => '38.914246',
               'longitude' => '-77.231239',
               'timezone' => 'America/New_York',
               'email' => 'tysons@spidersmart.com',
               'is_visible' => 1,
               'use_inventory' => 1,
               'book_checkout_limit' => 1,
               'book_checkout_frequency' => 'weekly'
           ],
            [
                'id' => 2,
                'label' => 'gaithersburg',
                'name' => 'Gaithersburg',
                'type' => 'local',
                'street_address' => '420 Main Street',
                'city' => 'Gaithersburg',
                'state' => 'MD',
                'postal_code' => '20878',
                'phone' => '3019901179',
                'country' => 'USA',
                'latitude' => '39.121101',
                'longitude' => '-77.236221',
                'timezone' => 'America/New_York',
                'email' => 'gaithersburg@spidersmart.com',
                'is_visible' => 1,
                'use_inventory' => 1,
                'book_checkout_limit' => 1,
                'book_checkout_frequency' => 'weekly'
            ],
            [
                'id' => 3,
                'label' => 'germantown',
                'name' => 'Germantown',
                'type' => 'local',
                'street_address' => '19739 Executive Park Circle',
                'city' => 'Germantown',
                'state' => 'MD',
                'postal_code' => '20874',
                'phone' => '3015285551',
                'country' => 'USA',
                'latitude' => '39.181057',
                'longitude' => '-77.273750',
                'timezone' => 'America/New_York',
                'email' => 'germantown@spidersmart.com',
                'is_visible' => 1,
                'use_inventory' => 1,
                'book_checkout_limit' => 1,
                'book_checkout_frequency' => 'weekly'
            ],
            [
                'id' => 4,
                'label' => 'online-two-per-month',
                'name' => 'Online Program (2/mo)',
                'type' => 'online',
                'street_address' => null,
                'city' => null,
                'state' => null,
                'postal_code' => null,
                'phone' => null,
                'country' => null,
                'latitude' => null,
                'longitude' => null,
                'timezone' => null,
                'email' => 'online@spidersmart.com',
                'is_visible' => 0,
                'use_inventory' => 0,
                'book_checkout_limit' => 2,
                'book_checkout_frequency' => 'monthly'
            ],
            [
                'id' => 5,
                'label' => 'online-four-per-month',
                'name' => 'Online Program (4/mo)',
                'type' => 'online',
                'street_address' => null,
                'city' => null,
                'state' => null,
                'postal_code' => null,
                'phone' => null,
                'country' => null,
                'latitude' => null,
                'longitude' => null,
                'timezone' => null,
                'email' => 'online@spidersmart.com',
                'is_visible' => 0,
                'use_inventory' => 0,
                'book_checkout_limit' => 4,
                'book_checkout_frequency' => 'monthly'
            ]
        ]);

        DB::table('center_subject')->insert([
            [ 'center_id' => 1, 'subject_id' => 1 ],
            [ 'center_id' => 1, 'subject_id' => 2 ],
            [ 'center_id' => 1, 'subject_id' => 3 ],
            [ 'center_id' => 1, 'subject_id' => 4 ],
            [ 'center_id' => 1, 'subject_id' => 5 ],
            [ 'center_id' => 1, 'subject_id' => 6 ],
            [ 'center_id' => 1, 'subject_id' => 7 ],
            [ 'center_id' => 1, 'subject_id' => 8 ],
            [ 'center_id' => 2, 'subject_id' => 1 ],
            [ 'center_id' => 2, 'subject_id' => 2 ],
            [ 'center_id' => 2, 'subject_id' => 3 ],
            [ 'center_id' => 2, 'subject_id' => 4 ],
            [ 'center_id' => 2, 'subject_id' => 5 ],
            [ 'center_id' => 2, 'subject_id' => 6 ],
            [ 'center_id' => 2, 'subject_id' => 7 ],
            [ 'center_id' => 2, 'subject_id' => 8 ],
            [ 'center_id' => 3, 'subject_id' => 1 ],
            [ 'center_id' => 3, 'subject_id' => 2 ],
            [ 'center_id' => 3, 'subject_id' => 3 ],
            [ 'center_id' => 3, 'subject_id' => 4 ],
            [ 'center_id' => 3, 'subject_id' => 5 ],
            [ 'center_id' => 3, 'subject_id' => 6 ],
            [ 'center_id' => 3, 'subject_id' => 7 ],
            [ 'center_id' => 3, 'subject_id' => 8 ],
            [ 'center_id' => 4, 'subject_id' => 1 ],
            [ 'center_id' => 4, 'subject_id' => 2 ],
            [ 'center_id' => 4, 'subject_id' => 3 ],
            [ 'center_id' => 5, 'subject_id' => 1 ],
            [ 'center_id' => 5, 'subject_id' => 2 ],
            [ 'center_id' => 5, 'subject_id' => 3 ]
        ]);

        $center_hour_inserts = [];
        for($i = 1; $i <= 3; $i++) {
            $rangeNum = rand(1,6);
            for ($j = 1; $j <= $rangeNum; $j ++) {
                $options = [
                    [ 'center_id' => $i, 'day' => 'M', 'start_time' => '10:00', 'end_time' => '14:00'],
                    [ 'center_id' => $i, 'day' => 'M', 'start_time' => '5:00', 'end_time' => '7:00'],
                    [ 'center_id' => $i, 'day' => 'T', 'start_time' => '10:00', 'end_time' => '16:00'],
                    [ 'center_id' => $i, 'day' => 'R', 'start_time' => '16:00', 'end_time' => '19:00'],
                    [ 'center_id' => $i, 'day' => 'W', 'start_time' => '15:30', 'end_time' => '18:30'],
                    [ 'center_id' => $i, 'day' => 'F', 'start_time' => '10:00', 'end_time' => '14:00'],
                    [ 'center_id' => $i, 'day' => 'S', 'start_time' => '10:00', 'end_time' => '14:00'],
                    [ 'center_id' => $i, 'day' => 'F', 'start_time' => '16:00', 'end_time' => '20:00'],
                    [ 'center_id' => $i, 'day' => 'R', 'start_time' => '10:00', 'end_time' => '14:00']
                ];
                $center_hour_inserts[] = $options[rand(0,sizeof($options)-1)];
            }
        }
        DB::table('center_hour_range')->insert($center_hour_inserts);

        $center_book_inserts = [];
        for ($i = 1; $i <= 4; $i++) {
            for ($j = 1; $j <= 31; $j++) {
                $center_book_inserts[] = [ 'center_id' => $i, 'book_id' => $j, 'quantity' => rand(1,8) ];
            }
        }
        DB::table('center_book')->insert($center_book_inserts);
    }
}
