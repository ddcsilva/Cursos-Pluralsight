import { Component } from '@angular/core';
import { IProduct } from './product.model';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent {
  public product: IProduct;

  constructor() {
    this.product = {
      id: 2,
      description: 'A friendly robot with two eyes and a smile -- great for domestic use.',
      name: 'Friendly Bot',
      imageName: 'head-friendly.png',
      category: 'Heads',
      price: 945.0,
      discount: 0.2
    };
  }

  public obterCaminhoImagem(product: IProduct): string {
    return '/assets/images/robot-parts/' + product.imageName;
  }
}
