import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { CreateOrderComponent } from './components/create-order/create-order.component';
import { OrdersComponent } from './components/orders/orders.component';


const routes: Routes = [
    {
        path: 'createOrder',
        component: CreateOrderComponent,
    },
    {
        path: 'orders',
        component: OrdersComponent,
    },
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'createOrder'
    }
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
