import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { OrderPositionsComponent } from './order-positions/order-positions.component';
import { ProductAddFormComponent } from './product-add-form/product-add-form.component';
import { LoginComponent } from './login/login.component';
import { authGuard } from './auth.guard';

const routes: Routes = [
  {path: 'products', component: ProductsComponent, canActivate: [authGuard]},
  {path: 'orders', component: OrdersComponent, canActivate: [authGuard]},
  {path: 'basket', component: BasketComponent, canActivate: [authGuard]},
  {path: 'orders/all', component: OrdersComponent, canActivate: [authGuard]},
  {path: 'products/add', component: ProductAddFormComponent, canActivate: [authGuard]},
  {path: 'login', component: LoginComponent},
  {path: 'products/:id', component: ProductDetailsComponent, canActivate: [authGuard]},
  {path: 'orders/:orderId', component: OrderPositionsComponent, canActivate: [authGuard]},
  {path: 'orders/all/:orderId', component: OrderPositionsComponent, canActivate: [authGuard]},
  {path: '', redirectTo: 'login', pathMatch: 'full'}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
