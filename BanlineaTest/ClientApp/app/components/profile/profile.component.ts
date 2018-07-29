import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from '../session/session.service';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html'
})
export class ProfileComponent {
    constructor(session: SessionService, router: Router) {
        if (session.user === undefined || session.user.email === undefined || session.user.name === undefined) {
            router.navigate(['./signin']);
        }
    }
}
