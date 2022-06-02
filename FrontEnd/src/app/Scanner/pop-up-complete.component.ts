import {Component} from '@angular/core';
import { MatDialog } from "@angular/material/dialog";
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
    selector: 'pop-up-complete',
    templateUrl: 'pop-up-complete.component.html',
    styleUrls: ['./scanner-modal.component.css']
})


export class PopUpCompleteComponent {
    QuestTitle = localStorage.getItem("QuestTitle")

    refresh(): void {
        window.location.reload();
    }
}