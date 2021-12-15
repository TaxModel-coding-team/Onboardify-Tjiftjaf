import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { User } from '../Models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent implements OnInit {

  public badgeBtn: boolean = true;
  public achievementBtn: boolean = false;
  constructor(private cookieService:CookieService, private router:Router) { }

  user:User = {} as User


  ngOnInit(): void {

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
