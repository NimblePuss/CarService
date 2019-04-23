import { OrderApiService } from './api-services/order-api.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { PersonApiService } from './api-services/person-api.service';
import { Person } from '../models/person';

@Injectable()
export class PersonService {
    constructor(private personApi: PersonApiService) {
    }

    public getPerson(id: number): Observable<Person> {
        return this.personApi.getPerson(id);
    }

    public change(person: Person) {
        return this.personApi.change(person);
    }
}
