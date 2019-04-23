import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UrlConstants } from './url-constants';
import { Observable } from 'rxjs';
import { Person } from 'src/app/models/person';
import { Order } from 'src/app/models/order';
import { environment } from 'src/environments/environment';

@Injectable()
export class PersonApiService {

    public baseUrl: string;
    constructor(private http: HttpClient, private urls: UrlConstants) {
        this.baseUrl = environment.apiUrl() + 'Person/';
    }

    public getPerson(id: number): Observable<Person> {
        return this.http.get<Person>(this.baseUrl + this.urls.Person.GET_BY_ID);
    }

    public change(person: Person): Observable<void> {
        return this.http.put<void>(this.baseUrl + this.urls.Person.CHANGE, person);
    }
}
