import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AchievementsComponent } from './achievements/achievements.component';
import { MicrosoftLoginComponent } from './microsoft-login/microsoft-login.component';
import { RegistrationComponent } from './Registration/registration.component';
import { QuestsComponent } from './quests/quests.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { BadgesComponent } from './badges/badges.component';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { QRDownloadComponent } from './QRDownload-page/QRDownload-page.component';
import {ProfilePublicComponent} from "./profile-public/profile-public.component";

const routes: Routes = [
  { path: '', component: MicrosoftLoginComponent, pathMatch: 'full' },
  { path: 'quests', component: QuestsComponent },
  { path: 'profile', component: ProfilePageComponent, children: [
    { path: '', component: BadgesComponent, pathMatch: 'full'},
    { path: 'badges', component: BadgesComponent},
    { path: 'achievements', component: AchievementsComponent},
    {path: 'QRDownload-page', component: QRDownloadComponent}]
  },
  { path: 'public', component: ProfilePublicComponent, children: [
      { path: '', component: BadgesComponent, pathMatch: 'full' },
      { path: 'badges', component: BadgesComponent },
      { path: 'achievements', component: AchievementsComponent }] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
