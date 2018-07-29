import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from '../session/session.service';

@Component({
    selector: 'signup',
    templateUrl: './signup.component.html'
})
export class SignUpComponent {
    public name = null;

    public lastName = null;

    public documentTypeId = null;

    public documentId = null;

    public mobileNumber = null;

    public email = null;

    public pwd = null;

    constructor(session: SessionService, router: Router) {
        if (session.user !== undefined && session.user.email !== undefined && session.user.name !== undefined) {
            router.navigate(['./profile']);
        }
    }

    public register() {

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
