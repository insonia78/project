import {Users} from "./users.model/users.model"
import { Injectable } from '@angular/core';
import { CounterService } from './counter.servivce';
@Injectable()
export class UserService{
    activeUsers:Users[] = [new Users('Thomas','active'),
    new Users('Susan','active')];
    inactiveUsers:Users[] = [new Users("Marika",'inactive'),new Users("Malane",'inactive')];
    constructor(private counterUser:CounterService){}   
    onSetToInactive(index:number){
        console.log(index);
         this.activeUsers[index].status="active"
         this.inactiveUsers.push(this.activeUsers[index]);
         this.activeUsers.splice( index , 1 );
         this.counterUser.incrementActivetoInactive();
     }
     onSetToActive(index:number){
       console.log(index);
        this.inactiveUsers[index].status="inactive"
        this.activeUsers.push(this.inactiveUsers[index]);
        this.inactiveUsers.splice( index , 1 );
        this.counterUser.incrementInactivetoActive()
    }
}