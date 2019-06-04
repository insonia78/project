import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {Users} from '../users.model/users.model';
import { UserService } from '../users.service';
@Component({
  selector: 'app-active-users',
  templateUrl: './active-users.component.html',
  styleUrls: ['./active-users.component.css']
})
export class ActiveUsersComponent implements OnInit {
  @Input() users:Users[] = [];
  
  constructor(private userService:UserService) { }

  ngOnInit() {
    this.users = this.userService.activeUsers;
  }
  onSetToInactiveState(index:number)
   {
    
     this.userService.onSetToInactive(index);
   }

}
