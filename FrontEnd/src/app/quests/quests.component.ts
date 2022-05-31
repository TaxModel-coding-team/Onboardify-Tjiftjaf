import { Component, OnDestroy, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Subscription } from 'rxjs';
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
  private subscription: Subscription = new Subscription();

  constructor(private questService: QuestService,
    private cookies: CookieService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getQuests()
  }

  //Getting all quests from API and caching to observable
  public getQuests(): void {
      this.subscription.add(this.questService.getQuests()
      .subscribe(quest =>
        quest.forEach(element =>{
          console.log(element.completed);
            if(!element.completed) this.quests.push(element);
        })
      ));
      console.log(this.quests);
  }

    public ScanQRBtnClickNew(): void {
      const dialogRef = this.dialog.open(ScannerModalComponent, {
        width: '600px',
      });
    }

    public ScanQRBtnClick(questId: number, questtitle: string): void{
      localStorage.setItem("QuestTitle", questtitle);
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
