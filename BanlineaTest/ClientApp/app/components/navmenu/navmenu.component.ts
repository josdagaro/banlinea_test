import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from '../session/session.service';
import { User } from '../interfaces/user';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    constructor(private session: SessionService) { }

    public logOut() {
        if (this.session.user !== undefined && this.session.user.email !== undefined && this.session.user.name !== undefined) {
            window.location.replace(window.location.pathname + window.location.search + window.location.hash);
        }
    }
}
