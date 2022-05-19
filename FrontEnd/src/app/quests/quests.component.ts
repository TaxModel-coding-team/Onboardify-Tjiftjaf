import { Component, OnDestroy, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Subscription } from 'rxjs';
import { textChangeRangeIsUnchanged } from 'typescript';
import { Quest } from '../Models/quest';
import { QuestService } from '../Services/quest.service';
import { ScannerModalComponent } from '../Scanner/scanner-modal.component'
import { MatDialog } from  '@angular/material/dialog';

@Component({
  selector: 'app-quests',
  templateUrl: './quests.component.html',
  styleUrls: ['./quests.component.css']
})
export class QuestsComponent implements OnInit, OnDestroy {

  //Fields
  public quests: Quest[] = [];
  public completedQuests: Quest[] = [];
  public greeting: String = '';
  private subscription: Subscription = new Subscription();

  constructor(private questService: QuestService,
    private cookies: CookieService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getQuests();
    this.getGreeting();


  }

  //Getting all quests from API and caching to observable
  public getQuests(): void {
      this.subscription.add(this.questService.getQuests()
      .subscribe((_quests) => {
        console.log(_quests);
        this.sortQuests(_quests);
        console.log(this.completedQuests);
        console.log(this.quests);
      }));
        
  }
  // Sorting Quests based on completion\
  private sortQuests(unsortedQuests : Quest[]): void{
    unsortedQuests.forEach(element => {
      console.log(element.completed);
      if(element.completed === true) this.completedQuests.push(element);
      else this.quests.push(element);
    });
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

    public ScanQRBtnClickNew(): void {
      const dialogRef = this.dialog.open(ScannerModalComponent, {
        width: '600px',
      });
    }

    public ScanQRBtnClick(questId: number): void{
      const dialogRef = this.dialog.open(ScannerModalComponent, {
        width: '600px',
        data: { QuestId: questId },
      });
    }

  //Unsubscribe from all made subscriptions to prevent background processes and possible memory leakage.
  ngOnDestroy()
  {
    this.subscription.unsubscribe();
  }
}
