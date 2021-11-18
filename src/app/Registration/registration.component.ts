import { Component, OnInit, Input, ViewChild, TemplateRef } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { User } from '../Models/user';
import { UserService } from '../Services/user.service';
import { HttpHeaders } from '@angular/common/http';
import { NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { RegistrationServiceService } from '../Services/registration-service.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})



export class RegistrationComponent {
  @ViewChild('content')
  private modalRef?: TemplateRef<any>;

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }  

  constructor(private msalService: MsalService,
               private userService: UserService, 
               private modalService: NgbModal,
               private registration: RegistrationServiceService) 
               { 
                 this.registration.popup.subscribe((val) => {
                   if(val === 'open')
                   {
                     this.openModal(this.modalRef)
                   }
                 } )
               }

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
