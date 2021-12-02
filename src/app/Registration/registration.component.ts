import { Component, OnInit, Input, ViewChild, TemplateRef } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { User } from '../Models/user';
import { UserService } from '../Services/user.service';
import { HttpHeaders } from '@angular/common/http';
import { NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { RegistrationServiceService } from '../Services/registration-service.service';
import { CookieService } from 'ngx-cookie-service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})

export class RegistrationComponent {

  //Gets data from Ng-template
  @ViewChild('content')
  private modalRef?: TemplateRef<any>;
  private newUser : User = {} as User;
  public closeResult = '';

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }  

  constructor(
    private msalService: MsalService,
    private userService: UserService, 
    private modalService: NgbModal,
    private registration: RegistrationServiceService,
    private cookieService: CookieService) 
    { 
      this.registration.popup.subscribe((val) => {
       if(val === 'open')
        {
          this.openModal(this.modalRef)
        }
        });
    }

    //Opens the modal when registationService 
    public openModal(content: any) : void {
      this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title', size: 'lg'}).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    }
  
    private getDismissReason(reason: any): string {
      if (reason === ModalDismissReasons.ESC) {
        return 'by pressing ESC';
      } else {
        return `with: ${reason}`;
      }
    }

  //On first login with microsoft account create a new User with data from Microsoft + your own username
  public registrate(user : User) : void {
    var _user: User = {} as User
    this.newUser.email =
    this.msalService.instance.getActiveAccount()!.username
    this.newUser.username = user.username 
    this.userService.createUser(this.newUser)
    .subscribe(
      (user) => {
        this.newUser = user
        console.log(user)
        this.cookieService.set("user", JSON.stringify(user));
      }
    )
  }
}
