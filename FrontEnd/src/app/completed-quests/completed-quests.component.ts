import {Component, OnDestroy, OnInit} from "@angular/core";
import {Quest} from "../Models/quest";
import {QuestService} from "../Services/quest.service";
import {CookieService} from "ngx-cookie-service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-completed-quests',
  templateUrl: './completed-quests.component.html',
  styleUrls: ['../quests/quests.component.css', './completed-quests.component.css']
})
export class CompletedQuestsComponent implements OnInit, OnDestroy {
  public quests: Quest[] = [];
  private subscription: Subscription = new Subscription();

  constructor(private questService: QuestService,
              private cookies: CookieService) { }

  ngOnInit(): void {
    this.getCompletedQuests()
  }

  public getCompletedQuests(): void {
    this.subscription.add(this.questService.getQuests()
      .subscribe(quest => {
        quest.forEach(element => {
          if(element.completed) this.quests.push(element);
        })
      }));
  }

  ngOnDestroy()
  {
    this.subscription.unsubscribe();
  }
}
