import { Component, Input, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from '../products.service';
import { ProductDTOResponse } from '../models/product.interface';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent {
  public product: ProductDTOResponse | undefined;

  constructor(private route: ActivatedRoute, private productService: ProductsService, private router: Router ) {
    const id = route.snapshot.paramMap.get('id');
    if (id !== null) {
      productService.getProductById(parseInt(id)).subscribe({
        next: (product) => {
          this.product = product;
        },
        error: (err) => console.error(err)
      });
    }
  }
  public onSubmit(event: any) {
    if (this.product != undefined) {
      if (event.submitter && event.submitter.name === 'delete') {
        this.productService.delete(this.product?.id).subscribe({
          next: () => {
            this.router.navigate([`/products`]);
          },
          error: (err) => console.error(err)
        })
      }
      else if (event.submitter && event.submitter.name === 'changeState') {
        this.productService.changeActiveState(this.product?.id).subscribe({
          next: () => {
            this.router.navigateByUrl('/', {skipLocationChange: true}).then(()=>{
              this.router.navigate([`/products/${this.product?.id}`]);
            })
          },
          error: (err) => console.error(err)
        })
      }
    }

  }
}
