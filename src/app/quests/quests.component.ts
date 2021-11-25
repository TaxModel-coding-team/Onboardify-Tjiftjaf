import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Quest } from '../Models/quest';
import { QuestService } from '../Services/quest.service';

@Component({
  selector: 'app-quests',
  templateUrl: './quests.component.html',
  styleUrls: ['./quests.component.css']
})
export class QuestsComponent implements OnInit, OnDestroy {

  //Fields
  public quests: Quest[] = [];
  public gainedExp: number = 0;
  private totalExp: number = 1850;
  public greeting: String = '';
  private subscription: Subscription = new Subscription();

  constructor(private questService: QuestService) { }

  ngOnInit(): void {
    this.getQuests() 
    this.getGreeting();
    
  }

  //Getting all quests from API and caching to observable
  public getQuests(): Subscription {
    return this.subscription.add(this.questService.getQuests()
      .subscribe(quest => this.quests = quest))     
  }

  //On quest completion add expierence in % (will be changed into amount of quests completed,
  //and will be moved to backend.)
  public updateExp(id: number, exp: number): void
  {
    var experience = exp / this.totalExp * 100;
    this.gainedExp += experience;

    var subQuest;
    this.quests.forEach(quest => {
      if(subQuest = quest.subQuests.find(subQuest => subQuest.id == id)){
        subQuest.completed = true;
        return;
      }
    });
  }

  //Calculates total expierence from all quests
  public getTotalExp(): void{
    this.quests.forEach(quest => {
      quest.subQuests.forEach(subQuest => {
        this.totalExp += subQuest.experience;
      });
    });
  }

  //Simple greeting based on your time of day
  public getGreeting(): void{
    
    var today = new Date()
    var curHr = today.getHours()

    if (curHr < 12) {
      this.greeting = 'Good morning';
    } else if (curHr < 18) {
      this.greeting = 'Good afternoon';
    } else {
      this.greeting = 'Good evening';
    }
  }

  //Unsubscribe from all made subscriptions to prevent background processes and possible memory leakage.
  ngOnDestroy()
  {
    this.subscription.unsubscribe();
  }
}
