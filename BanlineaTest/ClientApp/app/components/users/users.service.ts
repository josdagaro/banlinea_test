import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { User } from '../interfaces/user';

@Injectable()
export class UsersService {
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public find(id: number) {
        return this.http.get(this.baseUrl + 'api/User/' + id);
    }

    public update(user: User) {
        return this.http.put(this.baseUrl + 'api/User/' + user.id, user);
    }
}
