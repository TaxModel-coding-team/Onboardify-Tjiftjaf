import { Component, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { AuthenticationResult } from '@azure/msal-common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'front-end';


constructor(private msalService: MsalService) {
  
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
     } );
}

logout() {
  this.msalService.logout();
  // this.logincheck = false
}

}