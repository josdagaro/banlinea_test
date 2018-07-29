import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from '../session/session.service';
import { UsersService } from '../users/users.service';
import { User } from '../interfaces/user';
import { Email } from '../interfaces/email';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html'
})
export class ProfileComponent {
    public profile: User;

    public emails: Email[];

    //public newEmail: Email;

    public newEmailAddress: string = '';

    constructor(private session: SessionService, router: Router, private usersService: UsersService) {
        if (this.session.user === undefined || this.session.user.email === undefined || this.session.user.name === undefined) {
            router.navigate(['./signin']);
        } else {
            this.usersService.find(this.session.user.id).subscribe(result => {
                this.profile = result.json() as User;
                this.usersService.getEmails(this.profile.id).subscribe(result => {
                    this.emails = result.json() as Email[];
                }, error => alert('Server error at the moment of consulting user emails'));
            }, error => {
                alert('Error finding user: ' + error._body);
                });
        }
    }

    public update() {
        this.usersService.update(this.profile).subscribe(result => {
            console.log(result);
        }, error => {
            console.log(error);
            alert('Updating process could not be completed: ' + error._body)
        });
    }

    public addEmail() {
        var email = { address: this.newEmailAddress, userId: this.profile.id };

        this.usersService.addEmail(email).subscribe(result => {
            console.log(result);
            this.usersService.getEmails(this.profile.id).subscribe(result => {
                this.emails = result.json() as Email[];
            }, error => alert('Server error at the moment of consulting user emails'));
        }, error => {
            alert('The email could not be added: ' + error._body);
            });
    }
}
