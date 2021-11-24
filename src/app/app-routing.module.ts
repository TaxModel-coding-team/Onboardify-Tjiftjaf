import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AchievementsComponent } from './achievements/achievements.component';
import { MicrosoftLoginComponent } from './microsoft-login/microsoft-login.component';
import { RegistrationComponent } from './Registration/registration.component';
import { QuestsComponent } from './quests/quests.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';

const routes: Routes = [
  { path: '', component: MicrosoftLoginComponent, pathMatch: 'full'},
  { path: 'quests', component: QuestsComponent},
  { path: 'profile', component: ProfilePageComponent },
  { path: 'achievements', component: AchievementsComponent }

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
