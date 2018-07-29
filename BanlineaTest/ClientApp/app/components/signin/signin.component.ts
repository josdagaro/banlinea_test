import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from '../session/session.service';
import { User } from '../interfaces/user';

@Component({
    selector: 'signin',
    templateUrl: './signin.component.html'
})
export class SignInComponent {
    private session: SessionService;

    public email: string;

    public pwd: string;

    constructor(session: SessionService, router: Router) {
        if (session.user !== undefined && session.user.email !== undefined && session.user.name !== undefined) {
            router.navigate(['./profile']);
        }
    }

    public logIn() {
        var message: string = 'User email and password are required to log in';

        if (this.email && this.pwd) {
            this.session.start(this.email, this.pwd).subscribe(result => {
                this.session.user = result.json() as User;

                if (this.session.user.email && this.session.user.name) {

                } else {
                    alert(message);
                }
            }, error => console.error(error));
        } else {
            alert(message);
        }
    }

    public clean() {
        this.email = '';
        this.pwd = '';
    }
}
