import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent implements OnInit {

  constructor() { }
  public badgeBtn: boolean = true;
  public achievementBtn: boolean = false;

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
