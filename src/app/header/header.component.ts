import { Component, OnInit } from '@angular/core';
import { Directive } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {

  activequests: boolean = false;
  activeprofile: boolean = true;

  public active(button: string): void{
    if(button == "quests"){
      this.activequests = true;
      this.activeprofile = false;
    }
    else if(button == "profile"){
      this.activequests = false;
      this.activeprofile = true;
    }
  }

  ngOnInit(): void {
  }

}
