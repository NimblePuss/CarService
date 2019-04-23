import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UrlConstants } from './url-constants';
import { Observable } from 'rxjs';
import { Order } from 'src/app/models/order';
import { environment } from 'src/environments/environment';
import { NewOrder } from 'src/app/models/new-order';
import { Service } from 'src/app/models/service';

@Injectable()
export class OrderApiService {

    public baseUrl: string;
    constructor(private http: HttpClient, private urls: UrlConstants) {
        this.baseUrl = environment.apiUrl() + 'Order/';
    }

    public create(newOrder: NewOrder): Observable<void> {
        return this.http.post<void>(this.baseUrl + this.urls.Order.CREATE, newOrder);
    }

    public getOrders(): Observable<Array<Order>> {
        const headers = new HttpHeaders();
        headers.append('Access-Control-Allow-Headers', 'Content-Type');
        headers.append('Access-Control-Allow-Methods', 'GET');
        headers.append('Access-Control-Allow-Origin', '*');

        return this.http.get<Array<Order>>(this.baseUrl + this.urls.Order.GET_ALL_ORDERS);
    }

    public getById(id: number): Observable<Order> {
        return this.http.get<Order>(this.baseUrl + this.urls.Order.GET_BY_ID);
    }

    public getOrderServices(id: number): Observable<Array<Service>> {
        return this.http.get<Array<Service>>(this.baseUrl + this.urls.Order.GET_ORDER_SERVICES);
    }
}
