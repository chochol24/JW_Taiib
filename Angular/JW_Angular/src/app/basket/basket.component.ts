import { Component } from '@angular/core';
import { BasketPositionDTOResponse } from '../models/basket-position.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdersService } from '../orders.service';
import { BasketPositionsService } from '../basket-positions.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css'
})
export class BasketComponent {
  public pos: BasketPositionDTOResponse[] = [];
  userId: number = 2;
  constructor(private route: ActivatedRoute, private basketPositionsService: BasketPositionsService, private router: Router ) {
    
    if (this.userId !== null) {
       this.basketPositionsService.getUserBasket(this.userId).subscribe({
        next: (pos) => {
          this.pos = pos;
        },
        error: (err) => console.error(err)
      });
    }
  }
}
