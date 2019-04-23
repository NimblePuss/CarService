import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-date-form',
  templateUrl: './date-form.component.html',
  styleUrls: ['./date-form.component.scss']
})
export class DateFormComponent implements OnInit {

  constructor() { }

  @Input() newOrderForm: FormGroup;
  dateFrom = new FormControl('', [Validators.required]);
  timeFrom = new FormControl('', [Validators.required]);
  dateTo = new FormControl();
  timeTo = new FormControl();

  ngOnInit() {
    this.newOrderForm.addControl('dateFrom', this.dateFrom);
    this.newOrderForm.addControl('timeFrom', this.timeFrom);
    this.newOrderForm.addControl('dateTo', this.dateTo);
    this.newOrderForm.addControl('timeTo', this.timeTo);
  }

}
