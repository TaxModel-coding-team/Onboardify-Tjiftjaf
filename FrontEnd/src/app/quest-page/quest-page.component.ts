import {Component, OnInit} from "@angular/core";
import {CookieService} from "ngx-cookie-service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-quest-page',
  templateUrl: './quest-page.component.html',
  styleUrls: ['./quest-page.component.css']
})
export class QuestPageComponent implements OnInit {
  public greeting: String = '';
  constructor(private cookies:CookieService) { }

  ngOnInit(): void {
    this.getGreeting();
  }

  //Simple greeting based on your time of day
  public getGreeting(): void{

    var today = new Date()
    var curHr = today.getHours()

    if (curHr < 12) {
      this.greeting = 'Good morning ';
    } else if (curHr < 18) {
      this.greeting = 'Good afternoon ';
    } else {
      this.greeting = 'Good evening ';
    }
    this.greeting += JSON.parse(this.cookies.get("user")).username
  }
}
