import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class UsersService {
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public find(id: number) {
        return this.http.get(this.baseUrl + 'api/User/' + id);
    }
}
