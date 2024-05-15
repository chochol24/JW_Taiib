import { Component } from '@angular/core';
import { ProductDTOResponse } from '../models/product.interface';
import { ProductsService } from '../products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  public data: ProductDTOResponse[] = [];
  public page: number = 0;
  public count: number = 10;
  public name: string = "drugi";
  public sortBy: string = "";
  public isActive: boolean = true;
  public sortingAsc: boolean = false;


  constructor(private productsService: ProductsService){
    this.getData();
  }

  private getData(): void{
    this.productsService.get({count: this.count, page: this.page}, this.name, this.isActive, this.sortBy, this.sortingAsc).subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });
  }

  public onPaginationSubmit(): void{
    this.getData();
  }
  
}
