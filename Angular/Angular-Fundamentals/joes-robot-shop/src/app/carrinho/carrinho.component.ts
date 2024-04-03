import { Component, OnInit } from '@angular/core';
import { IProduct } from '../catalog/product.model';
import { CarrinhoService } from './carrinho.service';

// Componente que representa a página de carrinho de compras
@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {
  private carrinho: IProduct[] = []; // Lista de produtos no carrinho

  // Construtor da classe que recebe o serviço de carrinho
  constructor(private carrinhoService: CarrinhoService) { }

  // Método chamado quando o componente é inicializado
  ngOnInit() {
    // Obtém a lista de produtos do carrinho e a armazena na variável carrinho
    this.carrinhoService.obterCarrinho().subscribe({
      next: carrinho => this.carrinho = carrinho // O método obterCarrinho() retorna um Observable, que é uma forma de trabalhar com assincronismo em Angular
    });
  }

  // Método que retorna a lista de produtos no carrinho
  get itensDoCarrinho() {
    return this.carrinho;
  }

  // Método que retorna o total do carrinho
  get totalDoCarrinho() {
    // O método reduce() é um método de arrays que reduz um array a um único valor
    // Neste caso, ele soma o preço de cada produto no carrinho, aplicando o desconto se houver
    return this.carrinho.reduce((prev, next) => {
      let desconto = next.desconto && next.desconto > 0 ? 1 - next.desconto : 1;
      return prev + next.preco * desconto;
    }, 0);
  }

  // Método que remove um produto do carrinho
  removerDoCarrinho(produto: IProduct) {
    this.carrinhoService.remover(produto); // Remove o produto do carrinho
  }

  // Método que retorna a URL da imagem de um produto
  obterUrlDaImagem(produto: IProduct) {
    // Se o produto não existir, retorna uma string vazia
    // Caso contrário, retorna a URL da imagem do produto
    if (!produto) {
      return '';
    }

    return '/assets/images/robot-parts/' + produto.nomeImagem;
  }
}
