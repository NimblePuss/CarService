import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CarService } from 'src/app/services/car.service';
import { Car } from 'src/app/models/car';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss']
})
export class VehicleFormComponent implements OnInit {

  @Input() newOrderForm: FormGroup;
  carForm = new FormGroup({
    year: new FormControl('', [Validators.required]),
    name: new FormControl('', [Validators.required])
  });

  public cars: Array<Car>;
  message = new FormControl();

  constructor(private carService: CarService) {
   }

  ngOnInit() {
    this.newOrderForm.addControl('car', this.carForm);
    this.newOrderForm.addControl('message', this.message);
    this.carService.getCars().subscribe(data => { this.cars = data; });

  }

}
