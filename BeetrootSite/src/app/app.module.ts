import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { FooterComponent } from './components/footer/footer.component';
import { CreateOrderComponent } from './components/create-order/create-order.component';
import { OrderFormComponent } from './components/create-order/components/order-form/order-form.component';
import { DateFormComponent } from './components/create-order/components/order-form/components/date-form/date-form.component';
import { VehicleFormComponent } from './components/create-order/components/order-form/components/vehicle-form/vehicle-form.component';
import { PersonalFormComponent } from './components/create-order/components/order-form/components/personal-form/personal-form.component';
import { ServiceFormComponent } from './components/create-order/components/order-form/components/service-form/service-form.component';
import { ShareComponent } from './components/create-order/components/share/share.component';
import { OffersComponent } from './components/create-order/components/offers/offers.component';
import { AppRoutingModule } from './app-routing.module';
import { OrderApiService } from './services/api-services/order-api.service';
import { OrderService } from './services/order.service';
import { HttpClientModule } from '@angular/common/http';
import { UrlConstants } from './services/api-services/url-constants';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {TooltipModule} from 'ngx-bootstrap/tooltip';
import { DatepickerModule, BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { from } from 'rxjs';
import { CarApiService } from './services/api-services/car-api.service';
import { PersonApiService } from './services/api-services/person-api.service';
import { CarService } from './services/car.service';
import { PersonService } from './services/person.service';
import { OrdersComponent } from './components/orders/orders.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FooterComponent,
    CreateOrderComponent,
    OrderFormComponent,
    DateFormComponent,
    VehicleFormComponent,
    PersonalFormComponent,
    ServiceFormComponent,
    ShareComponent,
    OffersComponent,
    OrdersComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    // TooltipModule.forRoot(),
    BsDatepickerModule.forRoot(),
    DatepickerModule.forRoot()
  ],
  providers: [
    OrderApiService,
    CarApiService,
    PersonApiService,
    OrderService,
    CarService,
    PersonService,
    UrlConstants
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
