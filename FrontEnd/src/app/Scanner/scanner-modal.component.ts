import {Component, Inject, OnInit} from "@angular/core";
import {CookieService} from "ngx-cookie-service";
import {Router} from "@angular/router";
import {UserService} from "../Services/user.service";
import { MatDialogRef } from "@angular/material/dialog";
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-scanner-modal',
  templateUrl: './scanner-modal.component.html',
  styleUrls: ['./scanner-modal.component.css']
})

export class ScannerModalComponent {
  constructor(private cookieService: CookieService,
              private userService: UserService,
              public dialogRef: MatDialogRef<ScannerModalComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any) {  }
  public currentDevice: MediaDeviceInfo | undefined;
  public availableCameras: MediaDeviceInfo[] = [];
  public hasDevices: boolean = false;

  camerasFound(cameras: MediaDeviceInfo[]){
    this.availableCameras = cameras;
    this.hasDevices = Boolean(cameras && cameras.length);
    this.currentDevice = this.availableCameras[0];
  }

  onScanSuccess(result: string){
    console.log(result);
  }

  closeDialog() {
    this.dialogRef.close();
  }

}
