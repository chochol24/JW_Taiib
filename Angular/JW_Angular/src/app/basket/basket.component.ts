import { Component, ViewChild } from '@angular/core';
import { BasketPositionDTOResponse } from '../models/basket-position.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdersService } from '../orders.service';
import { BasketPositionsService } from '../basket-positions.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css'
})
export class BasketComponent {
  public pos: BasketPositionDTOResponse[] = [];
  public userId: number = 2;
  displayedColumns: string[] = ['id', 'userID', 'productID', 'amount', 'changeAmount', 'remove']
  dataSource!: MatTableDataSource<BasketPositionDTOResponse>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private route: ActivatedRoute, private basketPositionsService: BasketPositionsService, private router: Router ) {
    if (this.userId !== null) {
       this.basketPositionsService.getUserBasket(this.userId).subscribe({
        next: (pos) => {
          this.pos = pos;
          this.dataSource = new MatTableDataSource(this.pos);
        },
        error: (err) => console.error(err)
      });
    }
  }

  public changeAmount(id: number, amount: number): void{
    console.log(id);
    this.basketPositionsService.changeAmount(id,amount).subscribe({
      next: () => {
        this.router.navigateByUrl('/', {skipLocationChange: true}).then(()=>{
          this.router.navigate([`/basket`]);
        })
      },
      error: (err) => console.error(err)
    })
  }

  public remove(id: number): void{
    console.log(id);
    this.basketPositionsService.remove(id).subscribe({
      next: () => {
        this.router.navigateByUrl('/', {skipLocationChange: true}).then(()=>{
          this.router.navigate([`/basket`]);
        })
      },
      error: (err) => console.error(err)
    })
  }

  public order(id: number){
    console.log(id);
    this.basketPositionsService.order(id).subscribe({
      next: () => {
        this.router.navigateByUrl('/', {skipLocationChange: true}).then(()=>{
          this.router.navigate([`/basket`]);
        })
      },
      error: (err) => console.error(err)
    })
  }
}
