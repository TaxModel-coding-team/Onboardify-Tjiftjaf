import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { GlassModule } from 'angular-glass';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { QuestsComponent } from './quests/quests.component';
import { ProgressBarModule } from 'angular-progress-bar';
import { MsalModule, MsalService, MSAL_INSTANCE } from '@azure/msal-angular';
import { IPublicClientApplication, PublicClientApplication } from '@azure/msal-browser';
import { MicrosoftLoginComponent } from './microsoft-login/microsoft-login.component';
import { RegistrationComponent } from './Registration/registration.component';
import { FormsModule } from '@angular/forms';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { HeaderComponent } from './header/header.component';
import { BadgesComponent } from './badges/badges.component';
import { AchievementsComponent } from './achievements/achievements.component';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { QRCodeModule } from 'angular2-qrcode';
import {ProfilePublicComponent} from "./profile-public/profile-public.component";
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {ScannerModalComponent} from "./Scanner/scanner-modal.component";
import {MatOptionModule} from "@angular/material/core";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatSelectModule} from "@angular/material/select";
import { QRDownloadComponent } from './QRDownload-page/QRDownload-page.component';
import {CompletedQuestsComponent} from "./completed-quests/completed-quests.component";
import {QuestPageComponent} from "./quest-page/quest-page.component";
import { PopUpCompleteComponent } from './Scanner/pop-up-complete.component';
import { PopUpGetQuestComponent } from './Scanner/pop-up-getquest.component';
import { PopUpErrorComponent } from './Scanner/Pop-up-error.component';

export function MSALInstanceFactory(): IPublicClientApplication{
  return new PublicClientApplication({
    auth: {
      clientId: '455b6cce-e291-46f6-a7d8-1dfecbe011da',
      redirectUri: 'http://localhost:4200'
    }
  })
}


@NgModule({
  declarations: [
    AppComponent,
    QuestsComponent,
    MicrosoftLoginComponent,
    RegistrationComponent,
    ProfilePageComponent,
    HeaderComponent,
    BadgesComponent,
    AchievementsComponent,
    ProfileDetailsComponent,
    ProfilePublicComponent,
    ScannerModalComponent,
    QRDownloadComponent,
    CompletedQuestsComponent,
    QuestPageComponent,
    PopUpCompleteComponent,
    PopUpGetQuestComponent,
    PopUpErrorComponent,

  ],
  
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatDialogModule,
    AppRoutingModule,
    HttpClientModule,
    ProgressBarModule,
    MsalModule,
    FormsModule,
    GlassModule,
    NgbModule,
    RouterModule,
    QRCodeModule,
    ZXingScannerModule,
    MatOptionModule,
    MatFormFieldModule,
    MatSelectModule
  ],
  providers: [
    {
      provide: MSAL_INSTANCE,
      useFactory: MSALInstanceFactory
    },
    MsalService
  ],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]

})
export class AppModule { }
