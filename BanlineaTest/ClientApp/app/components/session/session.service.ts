import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { User } from '../interfaces/user';

@Injectable()
export class SessionService {
    public user: User;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public start(email: string, pwd: string) {
        return this.http.post(this.baseUrl + 'api/Session/Start', { email, pwd });
    }

    public destroy() {
        return this.http.get(this.baseUrl + 'api/Session/Destroy');
    }
}
