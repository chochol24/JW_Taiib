import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginationDTO } from './models/pagination.interface';
import { ProductDTOResponse } from './models/product.interface';
import { Observable } from 'rxjs';
import { OrderDTOResponse } from './models/order.interface';
import { OrderPositionDTOResponse } from './models/order-position.interface';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(private httpClient: HttpClient) { }

  public getUserOrders(id: number): Observable<OrderDTOResponse[]> {
    return this.httpClient.get<OrderDTOResponse[]>(`https://localhost:7123/api/orders/${id}`);
  }

  public getAllOrders(id: number): Observable<OrderDTOResponse[]> {
    return this.httpClient.get<OrderDTOResponse[]>(`https://localhost:7123/api/orders`);
  }

  public getOrderPositions(orderId: number): Observable<OrderPositionDTOResponse[]> {
    return this.httpClient.get<OrderPositionDTOResponse[]>(`https://localhost:7123/api/orders/${orderId}/positions`);
  }
}
