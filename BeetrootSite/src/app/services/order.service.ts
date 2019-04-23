import { OrderApiService } from './api-services/order-api.service';
import { Observable } from 'rxjs';
import { Order } from '../models/order';
import { Injectable } from '@angular/core';
import { NewOrder } from '../models/new-order';
import { Service } from '../models/service';

@Injectable()
export class OrderService {
    constructor(private orderApi: OrderApiService) {
    }

    public getOrders() {
        return this.orderApi.getOrders();
    }

    public create(newOrder: NewOrder): Observable<void> {
        return this.orderApi.create(newOrder);
    }

    public getById(id: number): Observable<Order> {
        return this.orderApi.getById(id);
    }

    public getOrderServices(id: number): Observable<Array<Service>> {
        return this.orderApi.getOrderServices(id);
    }
}
