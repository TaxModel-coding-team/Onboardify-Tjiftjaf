import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { User } from '../Models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile-details',
  templateUrl: './profile-details.component.html',
  styleUrls: ['./profile-details.component.css']
})
export class ProfileDetailsComponent implements OnInit {

  constructor(private cookieService: CookieService, private router:Router) { }

  user: User = {} as User

  ngOnInit(): void {
    this.getUserDetails();
  }
  private getUserDetails() : void {
    this.user = (JSON.parse(this.cookieService.get("user")));
    console.log(this.user);
  }
  public logout() {
    this.cookieService.delete("user");
    this.router.navigateByUrl("")
  }

}
