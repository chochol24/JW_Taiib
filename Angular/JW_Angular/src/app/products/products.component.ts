import { Component, inject } from '@angular/core';
import { ProductDTOResponse } from '../models/product.interface';
import { ProductsService } from '../products.service';
import { Router } from '@angular/router';
import { BasketPositionsService } from '../basket-positions.service';
import { BasketPositionDTORequest } from '../models/basket-position-request.interface';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  public data: ProductDTOResponse[] = [];
  public page: number = 0;
  public count: number = 10;
  public name: string = "";
  public sortBy: string = "";
  public isActive: boolean = true;
  public sortingAsc: boolean = false;


  constructor(private productsService: ProductsService, private router: Router) {
    this.getData();
  }

  private getData(): void {
    this.productsService.get({ count: this.count, page: this.page }, this.name, this.isActive, this.sortBy, this.sortingAsc).subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }

  public onPaginationSubmit(): void {
    this.getData();
  }

  public addNewProduct(): void{
    this.router.navigate(['/products/add']);
  }


  private readonly apiBasket = inject(BasketPositionsService);

  public basketRequest: BasketPositionDTORequest = {
    userID: 2,
    productID: 0,
    amount: 1
  };

  public addToBasket(id: number): void{
    this.basketRequest.productID = id;
    console.log(this.basketRequest);
    this.apiBasket.addToBasket(this.basketRequest).subscribe({
      next: (res) => {
        this.router.navigate(['/products']);
      },
      error: (err) => console.error(err)
    })
  }
}

