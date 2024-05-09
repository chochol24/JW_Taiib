import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDTOResponse } from './models/product.interface';
import { PaginationDTO } from './models/pagination.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private httpClient: HttpClient) { }

  public get(pagination: PaginationDTO, nameF: string, isActive: boolean, sortB: string, sorting: boolean): Observable<ProductDTOResponse[]>{
    return this.httpClient.get<ProductDTOResponse[]>(
      'https://localhost:7123/api/products',{params:{
        page: pagination.page ?? 0,
        count: pagination.count ?? 10,
        nameFilter: nameF ?? null, 
        isActiveFilter: isActive ?? null,
        sortBy: sortB ?? null,
        sortAscending: sorting ?? null
      },
      
    }
    );
  }
}
