import { OrderApiService } from './api-services/order-api.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { CarApiService } from './api-services/car-api.service';
import { Car } from '../models/car';

@Injectable()
export class CarService {
    constructor(private carApi: CarApiService) {
    }

    public getCars(skip: number = 0, take: number = 20): Observable<Array<Car>> {
        return this.carApi.getCars(skip, take);
    }

    public getById(id: number): Observable<Car> {
        return this.carApi.getById(id);
    }
}
