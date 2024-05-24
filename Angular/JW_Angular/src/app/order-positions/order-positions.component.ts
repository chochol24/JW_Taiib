import { Component } from '@angular/core';
import { OrderPositionDTOResponse } from '../models/order-position.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-order-positions',
  templateUrl: './order-positions.component.html',
  styleUrl: './order-positions.component.css'
})
export class OrderPositionsComponent {
  public pos: OrderPositionDTOResponse[] = [];

  constructor(private route: ActivatedRoute, private orderService: OrdersService, private router: Router ) {
    const orderId = route.snapshot.paramMap.get('orderId');
    if (orderId !== null) {
       orderService.getOrderPositions(parseInt(orderId)).subscribe({
        next: (pos) => {
          this.pos = pos;
        },
        error: (err) => console.error(err)
      });
    }
  }
}
