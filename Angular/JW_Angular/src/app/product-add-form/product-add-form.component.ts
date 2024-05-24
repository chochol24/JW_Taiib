import { Component, EventEmitter, Output, inject } from '@angular/core';
import { ProductDTORequest } from '../models/product-request.interface';
import { ProductsService } from '../products.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-product-add-form',
  templateUrl: './product-add-form.component.html',
  styleUrl: './product-add-form.component.css'
})
export class ProductAddFormComponent {
  constructor(private router: Router) {

  }

  public productRequest: ProductDTORequest = {
    name: '',
    price: 0,
    image: null,
    isActive: true
  };

  private readonly api = inject(ProductsService);

  public onSubmit(event: any): void{
    this.api.add(this.productRequest).subscribe({
      next: () => {
          this.router.navigate([`/products`]);
      },
      error: (err) => console.log(err)
    })
  }

  public cancel(): void{
        this.productRequest = {
          name: '',
          price: 0,
          image: null,
          isActive: true
        };
      
  }
}
