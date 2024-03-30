import { Component, Input } from '@angular/core';
import { IProduct } from '../catalog/product.model';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent {
  @Input() public produto!: IProduct;

  public obterCaminhoImagem(product: IProduct): string {
    if (!product) {
      return '';
    }

    return '/assets/images/robot-parts/' + product.imageName;
  }

  public obterClassesDesconto(produto: IProduct): string[] {
    if (produto.discount > 0) {
      return ['strikethrough'];
    } else {
      return [];
    }
  }

  public adicionarAoCarrinho(produto: IProduct): void {
  }
}
