import {Component} from '@angular/core';

@Component({
    selector: 'pop-up-complete-error',
    templateUrl: 'Pop-up-error.component.html',
    styleUrls: ['./scanner-modal.component.css']

})

export class PopUpErrorComponent {
    Error =  "Can't connect to server, please try again";
}
