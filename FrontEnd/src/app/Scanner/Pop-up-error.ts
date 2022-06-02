import {Component} from '@angular/core';
import { MatDialog } from "@angular/material/dialog";
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
    selector: 'pop-up-complete-error',
    templateUrl: 'pop-up-error.html',
    styleUrls: ['./scanner-modal.component.css']
    
})

export class PopUpError {
    Eror = localStorage.getItem("Error")
}