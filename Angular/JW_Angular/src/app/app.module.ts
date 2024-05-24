import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { OrderPositionsComponent } from './order-positions/order-positions.component';
import { ProductAddFormComponent } from './product-add-form/product-add-form.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    OrdersComponent,
    BasketComponent,
    ProductDetailsComponent,
    OrderPositionsComponent,
    ProductAddFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
