import { Component, OnInit, Input } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { User } from '../Models/user';
import { UserService } from '../Services/user.service';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})

export class RegistrationComponent {

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }  

  constructor(private msalService: MsalService, private userService: UserService) { }

  newUser : User = {} as User;

  registrate(user : User) {
    this.newUser.email =
    this.msalService.instance.getActiveAccount()!.username
    this.newUser.username = user.username 
    this.userService.createUser(this.newUser)
    .subscribe(
      (user) => {
        this.newUser = user
        console.log(user)
      }
    )
  }

}
