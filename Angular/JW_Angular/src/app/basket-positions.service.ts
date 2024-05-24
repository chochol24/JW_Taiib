import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BasketPositionDTOResponse } from './models/basket-position.interface';
import { Observable } from 'rxjs';
import { BasketPositionDTORequest } from './models/basket-position-request.interface';

@Injectable({
  providedIn: 'root'
})
export class BasketPositionsService {

  constructor(private httpClient: HttpClient) { }

  public getUserBasket(userId: number): Observable<BasketPositionDTOResponse[]> {
    return this.httpClient.get<BasketPositionDTOResponse[]>(`https://localhost:7123/api/basketpositions/${userId}`);
  }

  public addToBasket(basketPos: BasketPositionDTORequest): Observable<BasketPositionDTORequest> {
    return this.httpClient.post<BasketPositionDTORequest>(`https://localhost:7123/api/basketpositions/`, basketPos)
  }

  public changeAmount(id: number, amount: number): Observable<void> {
    return this.httpClient.put<void>(`https://localhost:7123/api/basketpositions/Amount/${id}`, amount);
  } 

  public remove(id: number): Observable<void> {
    return this.httpClient.delete<void>(`https://localhost:7123/api/basketpositions/${id}`)
  }

  public order(id: number): Observable<void> {
    return this.httpClient.post<void>(`https://localhost:7123/api/basketpositions/order/${id}`,null)
  }
}
