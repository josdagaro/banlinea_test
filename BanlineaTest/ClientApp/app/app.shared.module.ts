import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { SignInComponent } from './components/signin/signin.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { SignUpComponent } from './components/signup/signup.component';
import { ProfileComponent } from './components/profile/profile.component';
import { SessionService } from './components/session/session.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        SignUpComponent,
        FetchDataComponent,
        SignInComponent,
        ProfileComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'signin', pathMatch: 'full' },
            { path: 'signin', component: SignInComponent },
            { path: 'signup', component: SignUpComponent },
            { path: 'profile', component: ProfileComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'profile' }
        ])
    ],
    providers: [SessionService]
})
export class AppModuleShared {
}
