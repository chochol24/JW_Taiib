import { Component } from '@angular/core';
import { OrderDTOResponse } from '../models/order.interface';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent {
  public data: OrderDTOResponse[] = [];


  constructor(private ordersService: OrdersService){
    this.getData();
  }

  private getData(): void{
    this.ordersService.get().subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }
}
