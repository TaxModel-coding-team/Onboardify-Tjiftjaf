import { Component, OnInit } from '@angular/core';
import { Quest } from '../quest';
import { QuestService } from '../quest.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class QuestsComponent implements OnInit {

  quests: Quest[] = [];

  constructor(private questService: QuestService) { }

  ngOnInit(): void {
    this.getQuests();
  }

  getQuests(): void {
    this.questService.getQuests()
      .subscribe(quest => this.quests = quest);
  }

  getGreeting(): String{
    var greeting: String;
    var today = new Date()
    var curHr = today.getHours()

    if (curHr < 12) {
      greeting = 'Good morning';
    } else if (curHr < 18) {
      greeting = 'Good afternoon';
    } else {
      greeting = 'Good evening';
    }
    return greeting;
  }


}
