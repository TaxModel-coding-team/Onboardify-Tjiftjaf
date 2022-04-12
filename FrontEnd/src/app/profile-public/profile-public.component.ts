import { Component, OnInit } from "@angular/core";
import { CookieService } from 'ngx-cookie-service';
import { User } from '../Models/user';
import { Router } from '@angular/router';
import {Subscription} from "rxjs";
import {UserService} from "../Services/user.service";

@Component({
  selector: 'app-profile-public',
  templateUrl: './profile-public.component.html',
  styleUrls: ['./profile-public.component.css', '../profile-page/profile-page.component.css']
})
export class ProfilePublicComponent implements OnInit {
  constructor(private cookieService: CookieService,
    private router: Router, private userService: UserService) {  }

  public user: User = {} as User;
  private subscription: Subscription = new Subscription();
  private urlParams = new URLSearchParams(window.location.search);
  public badgeBtn: boolean = true;
  public achievementBtn: boolean = false;

  ngOnInit(): void {
    this.getPublicUserDetails();
  }
  private getPublicUserDetails(): void {
    let jsonString = '{"userId":"'+this.urlParams.get('id')+'"}';
    this.subscription.add(this.userService.getUser(JSON.parse(jsonString))
      .subscribe(user => this.user = user));
  }

  public badgeBtnClick() : void {
    this.achievementBtn = false;
    this.badgeBtn = true;

  }
  public achievementBtnClick() : void {
    this.achievementBtn = true;
    this.badgeBtn = false;

  }
}
