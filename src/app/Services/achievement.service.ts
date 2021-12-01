import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Achievement } from '../Models/achievement';

@Injectable({
  providedIn: 'root'
})
export class AchievementService {

  private API_URL = environment.ACHIEVEMENT_API_URL;
  
  constructor(
    private http: HttpClient){ }
  
    private achievementURL = this.API_URL + "/achievements";

  getAchievements(): Observable<Achievement[]> {
    return this.http.get<Achievement[]>(this.achievementURL);
  }
}
