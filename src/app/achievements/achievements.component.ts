import { Component, OnInit } from '@angular/core';
import { Achievement } from '../Models/achievement';

@Component({
  selector: 'app-achievements',
  templateUrl: './achievements.component.html',
  styleUrls: ['./achievements.component.css']
})
export class AchievementsComponent implements OnInit {

  public achievements: Achievement[] = [];

  constructor() { }

  ngOnInit(): void {
    //MOCK DATA
    this.achievements.push({name: "Achievement1", description: "Description 1"} as Achievement);
    this.achievements.push({name: "Achievement2", description: "Description 2"} as Achievement);
    this.achievements.push({name: "Achievement3", description: "Description 3"} as Achievement);
    this.achievements.push({name: "Achievement4", description: "Description 4"} as Achievement);
  }

}
