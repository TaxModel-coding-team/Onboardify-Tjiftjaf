import { APP_ID, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Quest } from '../Models/quest';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuestService {  
  
  //Url's fetched from enviroments.ts 
  private API_URL= environment.API_URL;
  private questURL= this.API_URL + '/quests'

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  constructor(
    private http: HttpClient){ }
  
  //GET: fetches all quests
  public getQuests(): Observable<Quest[]> {
    return this.http.get<Quest[]>(this.questURL);
  }
}
