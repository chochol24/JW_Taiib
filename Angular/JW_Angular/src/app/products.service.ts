import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDTOResponse } from './models/product.interface';
import { PaginationDTO } from './models/pagination.interface';
import { ProductDTORequest } from './models/product-request.interface';

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

  public getProductById(id: number): Observable<ProductDTOResponse>{
    return this.httpClient.get<ProductDTOResponse>(`https://localhost:7123/api/products/${id}`)
  }

  public delete(id: number): Observable<void>{
    return this.httpClient.delete<void>(`https://localhost:7123/api/products/${id}`);
  }

  public changeActiveState(id: number): Observable<void>{
    return this.httpClient.put<void>(`https://localhost:7123/api/products/Activate/${id}`, null);
  }

  public update(id: number, product: ProductDTORequest): Observable<void>{
    return this.httpClient.put<void>(`https://localhost:7123/api/products/${id}`, product);
  }

  public add(product: ProductDTORequest): Observable<void>{
    return this.httpClient.post<void>('https://localhost:7123/api/products', product);
  }
}
