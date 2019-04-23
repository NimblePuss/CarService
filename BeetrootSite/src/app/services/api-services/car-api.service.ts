import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UrlConstants } from './url-constants';
import { Observable } from 'rxjs';
import { Car } from 'src/app/models/car';
import { environment } from 'src/environments/environment';

@Injectable()
export class CarApiService {

    public baseUrl: string;
    constructor(private http: HttpClient, private urls: UrlConstants) {
        this.baseUrl = environment.apiUrl() + 'Car/';
    }

    public getCars(skip: number, take: number): Observable<Array<Car>> {
        return this.http.get<Array<Car>>(this.baseUrl + this.urls.Car.GET_ALL_CARS);
    }

    public getById(id: number) {
        return this.http.get<Car>(this.baseUrl + this.urls.Car.GET_BY_ID);
    }
}
