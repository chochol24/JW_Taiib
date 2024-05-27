import { Component, ViewChild, inject } from '@angular/core';
import { OrderDTOResponse } from '../models/order.interface';
import { OrdersService } from '../orders.service';
import { ActivatedRoute, Router} from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { TokenService } from '../token.service';



@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent {
  public data: OrderDTOResponse[] = [];
  public id: number = 1;
  public isAllOrdersPage: boolean = false;
  public choosedOrder?: OrderDTOResponse = undefined;
  displayedColumns: string[] = ['date', 'id', 'userID'];
  dataSource: MatTableDataSource<OrderDTOResponse>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  private readonly apiToken = inject(TokenService);

  constructor(private ordersService: OrdersService, private route: ActivatedRoute, private router: Router) {
    this.id = this.apiToken.decode();
    this.checkPage();
    this.getData();
    this.dataSource = new MatTableDataSource(this.data);
  }

  private getData(): void {
    if (!this.isAllOrdersPage) {
      this.ordersService.getUserOrders(this.id).subscribe({
        next: (res) => {
          this.data = res;
          this.updateDataSource();
        },
        error: (err) => console.error(err),
        complete: () => console.log('complete')
      });
    }
    else{
      this.ordersService.getAllOrders(this.id).subscribe({
        next: (res) => {
          this.data = res;
          this.updateDataSource();
        },
        error: (err) => console.error(err),
        complete: () => console.log('complete')
      });
    }
  }

  private updateDataSource(): void {
    this.dataSource.data = this.data;
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private checkPage(): void {
    this.route.url.subscribe(urlSegments => {
      const current = urlSegments.map(segment => segment.path).join('/');
      this.isAllOrdersPage = current === 'orders/all';
    });
  }

  public toPage(orderId: number){
    if(this.isAllOrdersPage) this.router.navigate(['/orders/all/', orderId]);
    else this.router.navigate(['/orders/', orderId]);
  }
}
