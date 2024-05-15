import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent {

  public id: any;
  constructor(private productsService: ProductsService, private route: ActivatedRoute){
    this.route.params.subscribe(params => {
      this.id = params['iD'];
      console.log(params['price']);
      });
    this.getData();
  }

  

  private getData(): void{
    /*this.productsService.get({count: 1, page: 0}, this.name, this.isActive, this.sortBy, this.sortingAsc).subscribe({
      next: (res) => {
        this.data = res;
      },
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    });*/
  }
}
