import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IProduct } from '../catalog/product.model';

// Componente que representa os detalhes de um produto
@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent {
  // Propriedade que representa o produto a ser exibido
  // * O decorator @Input() indica que a propriedade produto é um input do componente. Isso significa que ela pode ser passada como atributo no HTML
  @Input() public produto!: IProduct;
  // Propriedade que representa o evento de compra
  // * O decorator @Output() indica que a propriedade comprar é um output do componente. Isso significa que ela pode ser ouvida no HTML
  @Output() public comprar = new EventEmitter();

  // Método que retorna o caminho da imagem do produto
  public obterCaminhoImagem(produto: IProduct): string {
    // Se o produto não existir, retorna uma string vazia
    if (!produto) {
      return '';
    }

    // Caso contrário, retorna o caminho da imagem do produto
    return '/assets/images/robot-parts/' + produto.nomeImagem;
  }

  // Método que retorna as classes CSS do desconto
  public obterClassesCSSDesconto(produto: IProduct): string[] {
    // Se o desconto for maior que 0, retorna a classe CSS 'strikethrough'
    // Caso contrário, retorna um array vazio
    if (produto.desconto > 0) {
      return ['strikethrough'];
    } else {
      return [];
    }
  }

  // Método chamado quando o botão de comprar é clicado
  public botaoComprarClicado(produto: IProduct): void {
    this.comprar.emit();
  }
}
