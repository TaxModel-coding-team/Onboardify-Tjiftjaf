import {Component, Inject, OnInit} from "@angular/core";
import {CookieService} from "ngx-cookie-service";
import {Router} from "@angular/router";
import {UserService} from "../Services/user.service";
import { MatDialogRef } from "@angular/material/dialog";
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { QuestService } from "../Services/quest.service";
import { questUserViewModel } from "../Models/QuestUserViewModel";


@Component({
  selector: 'app-scanner-modal',
  templateUrl: './scanner-modal.component.html',
  styleUrls: ['./scanner-modal.component.css']
})

export class ScannerModalComponent {
  constructor(private cookieService: CookieService,
              private userService: UserService,
              private questService: QuestService,
              public dialogRef: MatDialogRef<ScannerModalComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any) {  }
  public currentDevice: MediaDeviceInfo | undefined;
  public availableCameras: MediaDeviceInfo[] = [];
  public hasDevices: boolean = false;
  public returnedvalue: boolean = false;
  private questUserViewModel : questUserViewModel = {} as questUserViewModel;

  camerasFound(cameras: MediaDeviceInfo[]){
    this.availableCameras = cameras;
    this.hasDevices = Boolean(cameras && cameras.length);
    this.currentDevice = this.availableCameras[0];
  }

  onScanSuccess(result: string){
    let userId = JSON.parse(this.cookieService.get("user")).id
    if(result.includes("complete") == true)
    {
      this.questUserViewModel.Id = userId;
      this.questUserViewModel.QuestId = result.slice(0,-9);
    } else{
      this.questUserViewModel.Id = userId;
      this.questUserViewModel.QuestId = result.slice(1,-1);
      console.log(this.questService.assignQuestByQR(this.questUserViewModel));
    } 
   
  }

  closeDialog() {
    this.dialogRef.close();
  }

}
