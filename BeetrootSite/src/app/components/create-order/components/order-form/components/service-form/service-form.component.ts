import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-service-form',
  templateUrl: './service-form.component.html',
  styleUrls: ['./service-form.component.scss']
})
export class ServiceFormComponent implements OnInit {

  @Input() newOrderForm: FormGroup;

  serviceForm = new FormGroup({
    transmission: new FormControl(),
    maintenance: new FormControl(),
    repair: new FormControl(),
    other: new FormControl()

  });
  constructor() { }

  ngOnInit() {
    this.newOrderForm.addControl('services', this.serviceForm);
  }

}
