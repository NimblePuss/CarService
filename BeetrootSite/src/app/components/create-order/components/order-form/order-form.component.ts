import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidatorFn, FormBuilder } from '@angular/forms';
import { OrderService } from 'src/app/services/order.service';
import { Order } from 'src/app/models/order';
import { NewOrder } from 'src/app/models/new-order';

@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.scss']
})
export class OrderFormComponent implements OnInit {

  public newOrder: NewOrder;
  newOrderForm = new FormGroup({

  });
  constructor(private fb: FormBuilder, private orderService: OrderService) { }


  ngOnInit() {
  }

  clearData() {
    for (const field in this.newOrderForm.controls) {
      const child = this.newOrderForm.get(field);
      child.reset();
    }
  }

  sendData() {
    this.newOrder = new NewOrder();
    this.newOrder.Person = this.newOrderForm.get('person').value;
    this.newOrder.Car = this.newOrderForm.get('car').value;
    this.newOrder.message = this.newOrderForm.get('message').value;
    this.newOrder.dateFrom = this.newOrderForm.get('dateFrom').value + this.newOrderForm.get('timeFrom').value;
    this.newOrder.dateTo = this.newOrderForm.get('dateTo').value + this.newOrderForm.get('timeTo').value;
    this.orderService.create(this.newOrder).subscribe(data => {
      this.clearData();
    });
  }
}
