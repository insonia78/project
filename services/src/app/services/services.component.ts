import { Component, OnInit } from '@angular/core';
import {Users} from './users.model/users.model';
import { InactiveUsersComponent } from './inactive-users/inactive-users.component';
import { UserService } from './users.service';
@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css'],
  providers:[UserService] 
})
export class ServicesComponent implements OnInit {
  
  constructor(public userService:UserService) { }

  ngOnInit() {
  }
  
}
