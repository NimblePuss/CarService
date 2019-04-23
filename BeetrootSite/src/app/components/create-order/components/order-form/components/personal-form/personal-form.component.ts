import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { add } from 'ngx-bootstrap/chronos/public_api';

@Component({
  selector: 'app-personal-form',
  templateUrl: './personal-form.component.html',
  styleUrls: ['./personal-form.component.scss']
})
export class PersonalFormComponent implements OnInit {

  constructor() { }

  @Input() newOrderForm: FormGroup;

  personalForm = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    secondName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phone: new FormControl('', [Validators.required])

  });

  ngOnInit() {
    this.newOrderForm.addControl('person', this.personalForm);
  }

}
