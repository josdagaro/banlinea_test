import { Component } from '@angular/core';
import { SessionService } from '../session/session.service';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    constructor(session: SessionService) { }
}
