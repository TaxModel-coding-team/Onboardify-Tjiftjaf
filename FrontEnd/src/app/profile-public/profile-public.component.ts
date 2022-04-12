import { Component, OnInit } from "@angular/core";
import { CookieService } from 'ngx-cookie-service';
import { User } from '../Models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile-public',
  templateUrl: './profile-public.component.html',
  styleUrls: ['./profile-public.component.css', '../profile-details/profile-details.component.css']
})
export class ProfilePublicComponent implements OnInit {
  constructor(private cookieService: CookieService, private router: Router) {  }

  public user: User = {} as User;

  ngOnInit(): void {
    
  }

}
