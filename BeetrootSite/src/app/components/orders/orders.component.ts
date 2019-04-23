import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/services/order.service';
import { Order } from 'src/app/models/order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders: Array<Order>;
  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.orderService.getOrders().subscribe( data => {
      this.orders = data;
    });
  }

}
