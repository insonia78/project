import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {Users} from '../users.model/users.model';
import { UserService } from '../users.service';
@Component({
  selector: 'app-inactive-users',
  templateUrl: './inactive-users.component.html',
  styleUrls: ['./inactive-users.component.css']
})
export class InactiveUsersComponent implements OnInit {
  users:Users[] = [];
  
  constructor(private userService:UserService) { }

  ngOnInit() {
    this.users = this.userService.inactiveUsers;
  }
  onSetToActiveState(index:number)
   {
     console.log("on set active " + index);
     this.userService.onSetToActive(index);
   }
}
