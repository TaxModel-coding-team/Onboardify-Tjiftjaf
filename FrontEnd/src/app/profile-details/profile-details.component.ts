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

  public user: User = {} as User
  public href: string =  window.location.href;
  private urlParams = new URLSearchParams(window.location.search);

  ngOnInit(): void {
    if(this.urlParams.has('id')){
      this.redirectToPublicProfile(this.urlParams.get('id'));
    } else {
      this.getUserDetails();
    }
  }
  private getUserDetails() : void {
    this.user = (JSON.parse(this.cookieService.get("user")));
    this.href = this.href + "/?id=" + this.user.id;
  }
  private redirectToPublicProfile(id: string | null): void {
    this.router.navigateByUrl("public"+"?id="+id);
  }
  public logout(): void {
    this.cookieService.delete("user");
    this.router.navigateByUrl("")
  }

}
