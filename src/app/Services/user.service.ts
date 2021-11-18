import { APP_ID, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../Models/user';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {  
  
  public API_URL: string = environment.USER_API_URL;
  public userURL: string = this.API_URL + '/users/Login'

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  constructor(
    private http: HttpClient){ }
  
  addUser(User: User): Observable<User> {
    return this.http.post<User>(this.userURL, User, this.httpOptions)
  }
}
