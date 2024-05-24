import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { OrderPositionsComponent } from './order-positions/order-positions.component';
import { ProductAddFormComponent } from './product-add-form/product-add-form.component';

const routes: Routes = [
  {path: 'products', component: ProductsComponent},
  {path: 'orders', component: OrdersComponent},
  {path: 'basket', component: BasketComponent},
  {path: 'orders/all', component: OrdersComponent},
  {path: 'products/add', component: ProductAddFormComponent},
  {path: 'products/:id', component: ProductDetailsComponent},
  {path: 'orders/:orderId', component: OrderPositionsComponent},
  {path: 'orders/all/:orderId', component: OrderPositionsComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
