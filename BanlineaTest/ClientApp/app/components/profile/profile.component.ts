import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from '../session/session.service';
import { UsersService } from '../users/users.service';
import { User } from '../interfaces/user';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html'
})
export class ProfileComponent {
    public profile: User;

    constructor(session: SessionService, router: Router, private usersService: UsersService) {
        if (session.user === undefined || session.user.email === undefined || session.user.name === undefined) {
            router.navigate(['./signin']);
        } else {
            usersService.find(session.user.id).subscribe(result => {
                this.profile = result.json() as User;
            }, error => alert('Error. Maybe the current user (you) has an invalid ID'));
        }
    }

    public update() {

    }
}
