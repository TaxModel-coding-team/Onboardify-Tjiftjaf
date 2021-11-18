import { Component, OnInit, Input } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { User } from '../Models/user';
import { UserService } from '../Services/user.service';
import { HttpHeaders } from '@angular/common/http';
import { NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})

export class RegistrationComponent {

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }  

  constructor(private msalService: MsalService, private userService: UserService, private modalService: NgbModal) { }

  newUser : User = {} as User;
  public closeResult = '';

  registrate(user : User) {
    this.newUser.email =
    this.msalService.instance.getActiveAccount()!.username
    this.newUser.username = user.username 
    this.userService.createUser(this.newUser)
    .subscribe(
      (user) => {
        this.newUser = user
        console.log(user)
      }
    )
  }

  openModal(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title', size: 'lg'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

}
