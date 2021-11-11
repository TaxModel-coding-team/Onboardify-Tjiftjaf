import { Component, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { AuthenticationResult } from '@azure/msal-common';
import { User } from '../Models/user';
import { UserService } from '../Services/user.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-microsoft-login',
  templateUrl: './microsoft-login.component.html',
  styleUrls: ['./microsoft-login.component.css']
})

export class MicrosoftLoginComponent implements OnInit {

  
  newUser: string
  constructor(private msalService: MsalService, private userService: UserService, private http: HttpClient) {
    this.newUser = '';
  }

  logincheck : boolean = false;
  

  ngOnInit(): void {
    this.msalService.instance.handleRedirectPromise().then(
      res => {
        if (res != null && res.account != null) {
          this.msalService.instance.setActiveAccount(res.account)
        }
      }
    )
  }

  login() {
    this.msalService.loginPopup().subscribe( (response: AuthenticationResult) => {
      this.msalService.instance.setActiveAccount(response.account)
      this.logincheck = true
      
      this.newUser = 
      this.msalService.instance.getActiveAccount()!.username
      console.log(this.newUser)
      this.addUser()
    } )
  }

  logout() {
    this.msalService.logout();
    this.logincheck = false
  }

  addUser() {
    this.userService.addUser(this.newUser)
    .subscribe(user => this.newUser = user)
  }

  
}
