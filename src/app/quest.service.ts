import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Quest } from './quest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuestService {  
  private questURL = "https://localhost:44329/api/task/all"

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  constructor(
    private http: HttpClient){ }
  
  getQuests(): Observable<Quest[]> {
    return this.http.get<Quest[]>(this.questURL);
  }
}
