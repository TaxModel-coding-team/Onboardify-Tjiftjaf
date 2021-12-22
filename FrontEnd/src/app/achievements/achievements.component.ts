import { Component, OnInit } from '@angular/core';
import { Achievement } from '../Models/achievement';
import { AchievementService } from '../Services/achievement.service';

@Component({
  selector: 'app-achievements',
  templateUrl: './achievements.component.html',
  styleUrls: ['./achievements.component.css']
})
export class AchievementsComponent implements OnInit {
  
  public achievements: Achievement[] = [];

  constructor(private service: AchievementService) { }

  ngOnInit(): void {
    this.getAchievements();
  }


  getAchievements(): void 
  {
    this.service.getAchievements()
      .subscribe(achievements => {
        this.achievements = achievements;
      });
  }

}
