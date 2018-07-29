import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from '../session/session.service';
import { UsersService } from '../users/users.service';
import { User } from '../interfaces/user';

@Component({
    selector: 'signup',
    templateUrl: './signup.component.html'
})
export class SignUpComponent {
    private user: User;

    public name = null;

    public lastName = null;

    public documentTypeId = null;

    public documentId = null;

    public mobileNumber = null;

    public email = null;

    public pwd = null;

    constructor(session: SessionService, private router: Router, private usersService: UsersService) {
        if (session.user !== undefined && session.user.email !== undefined && session.user.name !== undefined) {
            router.navigate(['./profile']);
        }
    }

    public register() {
        var user = { name: this.name, lastName: this.lastName, documentTypeId: this.documentTypeId, documentId: this.documentId, mobileNumber: this.mobileNumber, password: this.pwd, residenceCountry: '', residenceCity: '', address: '', age: 0, company: '' };
        this.usersService.create(user).subscribe(result => {
            this.user = result.json() as User;
            var email = { address: this.email, userId: this.user.id };
            this.usersService.addEmail(email).subscribe(result => {
                console.log(result)
                this.router.navigate(['./signin']);
            }, error => alert('The email could not be created'));
        }, error => alert('User could not be created'));
    }

    public clean() {
        this.name = null;
        this.lastName = null;
        this.documentTypeId = null;
        this.documentId = null;
        this.mobileNumber = null;
        this.email = null;
        this.pwd = null;
    }
}
