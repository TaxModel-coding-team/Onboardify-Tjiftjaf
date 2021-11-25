import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AchievementsComponent } from './achievements/achievements.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { QuestsComponent } from './quests/quests.component';

const routes: Routes = [
  { path: 'Quests', component: QuestsComponent },
  { path: 'Profile', component: ProfilePageComponent },
  { path: 'Achievements', component: AchievementsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
