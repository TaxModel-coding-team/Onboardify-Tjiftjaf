import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import { User } from '../Models/user';
import { UserId } from '../Models/userId';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  //Url's from enviroment.ts and seperate routes
  private API_URL: string = environment.USER_API_URL;
  private userURL: string = this.API_URL + '/users/Login';
  private createURL: string = this.API_URL + '/users/create';
  private getURL: string = this.API_URL + '/users/get';

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  constructor(private http: HttpClient){ }

  //POST: Sends user to api and verifies if user exists
  public verifyIfUserExists(User: User): Observable<User> {
    return this.http.post<User>(this.userURL, User, this.httpOptions)
  }

  //POST: Creates a new user
  public createUser(User: User): Observable<User> {
    return this.http.post<User>(this.createURL, User, this.httpOptions)
  }

  //POST: gets user
  public getUser(UserId: UserId): Observable<User> {
    return this.http.post<User>(this.getURL, UserId, this.httpOptions)
  }
}
