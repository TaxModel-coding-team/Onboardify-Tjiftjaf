import { APP_ID, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Quest } from '../Models/quest';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CookieService } from 'ngx-cookie-service';
import { questUserViewModel } from '../Models/QuestUserViewModel';

@Injectable({
  providedIn: 'root'
})
export class QuestService {  
  
  //Url's fetched from enviroments.ts 
  private API_URL= environment.API_URL;
  private questURL= this.API_URL + '/quests'
  private completeQuestURL = this.questURL + '/complete'
  private assignQuestURL = this.questURL + '/assignQRQuests'

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  constructor(
    private http: HttpClient,
    private cookies: CookieService){ }
  
  //GET: fetches all quests
  public getQuests(): Observable<Quest[]> 
  {
    return this.http.get<Quest[]>(this.questURL + "/" + JSON.parse(this.cookies.get("user")).id);
  }

  public completeQuest(questUserViewModel: questUserViewModel): Boolean
  {
    console.log("Api call");
    console.log(questUserViewModel.QuestId)
    //let model = {Id: questUserViewModel.Id, QuestId: questUserViewModel.QuestId}
   this.http.put<boolean>(this.completeQuestURL, questUserViewModel, this.httpOptions).subscribe(response =>  {
    console.log(response); 
    return response.valueOf()})
   return false;    
  }

  
  public assignQuestByQR(questUserViewModel: questUserViewModel): Boolean
  {
    console.log("Api call");
    console.log(questUserViewModel.QuestId)
    //let model = {Id: questUserViewModel.Id, QuestId: questUserViewModel.QuestId}
   this.http.post<boolean>(this.assignQuestURL, questUserViewModel, this.httpOptions).subscribe(response =>  {
    console.log(response); 
    return response.valueOf()})
   return false;    
    }
}
