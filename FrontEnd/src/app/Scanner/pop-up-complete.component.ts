import { MatDialog } from "@angular/material/dialog";
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {Component} from '@angular/core';

@Component({
    selector: 'pop-up-complete',
    templateUrl: 'pop-up-complete.component.html'
})

export class PopUpComplete {
    constructor(public dialog: MatDialog) {}

    public open(result: Boolean): void{
        const dialogRef = this.dialog.open(PopUpCompleteDialog);
        console.log("opendialog")
        dialogRef.afterClosed().subscribe(result => {
           //refresh hier
        })
    }
}
export class PopUpCompleteDialog { }