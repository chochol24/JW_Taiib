import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BasketPositionDTOResponse } from './models/basket-position.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BasketPositionsService {

  constructor(private httpClient: HttpClient) { }

  public getUserBasket(userId: number): Observable<BasketPositionDTOResponse[]> {
    return this.httpClient.get<BasketPositionDTOResponse[]>(`https://localhost:7123/api/basketpositions/${userId}`);
  }
}
