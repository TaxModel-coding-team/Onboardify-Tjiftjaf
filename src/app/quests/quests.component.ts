import { Component, Input, OnInit } from '@angular/core';
import { QuestService } from '../quest.service';
import { Quest } from '../quest';

@Component({
  selector: 'app-quests',
  templateUrl: './quests.component.html',
  styleUrls: ['./quests.component.css']
})
export class QuestsComponent implements OnInit {

  quests: Quest[] = [];
  @Input() gainedExp: number = 0;
  @Input() totalExp: number = 0;

  constructor(private questService: QuestService) { }

  ngOnInit(): void {
    this.getQuests();

    console.log(this.quests);
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

  getTotalExp(): void{
    this.quests.forEach(quest => {
      quest.subQuests.forEach(subQuest => {
        this.totalExp += subQuest.experience;
      });
    });
  }

  sendExp(id :number, exp: number) : void
  {
    this.gainedExp += exp;
    console.log(this.gainedExp);
    
    (document.getElementById('ID ' + id.toString() + ' description') as HTMLSpanElement).style.color = "grey";
    

    (document.getElementById('ID ' + id.toString() + ' button') as HTMLButtonElement).disabled = true;
  }

}
