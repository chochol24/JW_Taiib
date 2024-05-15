import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginationDTO } from './models/pagination.interface';
import { ProductDTOResponse } from './models/product.interface';
import { Observable } from 'rxjs';
import { OrderDTOResponse } from './models/order.interface';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(private httpClient: HttpClient) { }

  public get(): Observable<OrderDTOResponse[]>{
    return this.httpClient.get<OrderDTOResponse[]>(
      'https://localhost:7123/api/orders'
    );
  }
}
