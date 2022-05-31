import {Component, Inject, OnInit} from "@angular/core";
import {CookieService} from "ngx-cookie-service";
import {Router} from "@angular/router";
import {UserService} from "../Services/user.service";
import { PopUpCompleteComponent } from "./pop-up-complete.component";
import { PopUpGetQuestComponent } from "./pop-up-getquest.component"
import { MatDialogRef } from "@angular/material/dialog";
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { QuestService } from "../Services/quest.service";
import { questUserViewModel } from "../Models/questUserViewModel";
import { MatDialog } from  '@angular/material/dialog';
import { PopUpError } from "./Pop-up-error";
import { PopupClient } from "@azure/msal-browser";
import { Console } from "console";

@Component({
  selector: 'app-scanner-modal',
  templateUrl: './scanner-modal.component.html',
  styleUrls: ['./scanner-modal.component.css']
})

export class ScannerModalComponent implements OnInit {

  constructor(private cookieService: CookieService,
              private userService: UserService,
              private questService: QuestService,
              public dialogRef: MatDialogRef<ScannerModalComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any, private dialog: MatDialog) {   }
  public currentDevice: MediaDeviceInfo | undefined;
  public availableCameras: MediaDeviceInfo[] = [];
  public hasDevices: boolean = false;
  public returnedvalue: boolean = false;
  public popupComplete: PopUpCompleteComponent = {} as PopUpCompleteComponent;
  public popupGetQuest: PopUpGetQuestComponent = {} as PopUpGetQuestComponent;
  private questUserViewModel : questUserViewModel = {} as questUserViewModel;

  ngOnInit(): void {
    
  }

  camerasFound(cameras: MediaDeviceInfo[]){
    this.availableCameras = cameras;
    this.hasDevices = Boolean(cameras && cameras.length);
    this.currentDevice = this.availableCameras[0];
  }

  async onScanSuccess(result: string){
    this.dialogRef.close();
    let userId = JSON.parse(this.cookieService.get("user")).id
    if(result.includes("complete") == true)
    {
      this.questUserViewModel.UserId = userId;
      this.questUserViewModel.QuestId = result.slice(0,-9);
      var Result : Boolean;
      Result = await this.questService.completeQuest(this.questUserViewModel);
      if(Result == true)
      {
        this.dialog.open(PopUpCompleteComponent , {
          data: {
            QuestTitle : localStorage.getItem("QuestTitle")},
        });
      } else{
        this.dialog.open(PopUpError, { panelClass: '.e-dialog'});
      }
    } else{
      this.questUserViewModel.UserId = userId;
      this.questUserViewModel.QuestId = result.slice(1,-1);
      if(await this.questService.assignQuestByQR(this.questUserViewModel) == true)
      {
        this.dialog.open(PopUpGetQuestComponent, {
          data: { QuestTitle : localStorage.getItem("QuestTitle")},
        });
      }else{
        this.dialog.open(PopUpError, { panelClass: '.e-dialog'});
      }
    } 
  }

  closeDialog() {
    localStorage.clear();
    this.dialogRef.close();
  }

  

}
