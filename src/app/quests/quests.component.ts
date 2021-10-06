import { Component, OnInit } from '@angular/core';
import { Quest } from '../quest';
import { QuestService } from '../quest.service';

@Component({
  selector: 'app-quests',
  templateUrl: './quests.component.html',
  styleUrls: ['./quests.component.css']
})
export class QuestsComponent implements OnInit {

  quests: Quest[] = [];
  gainedExp: number = 0;
  totalExp: number = 1850;

  constructor(private questService: QuestService) { }

  ngOnInit(): void {
    this.getQuests();

    console.log(this.quests);
  }

  getQuests(): void {
    this.questService.getQuests()
      .subscribe(quest => this.quests = quest);

  }

  updateExp(id: number, exp: number): void
  {
    var experience = exp / this.totalExp * 100;
    this.gainedExp += experience;
    console.log(this.gainedExp);

    (document.getElementById('ID ' + id.toString() + ' description') as HTMLSpanElement).style.color = "grey";
    

    (document.getElementById('ID ' + id.toString() + ' button') as HTMLButtonElement).disabled = true;
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
    
    
  }

}
