import { Component } from '@angular/core';
import { IProduct } from './product.model';
import { CartService } from '_course-resources/cart/cart.service';
import { ProductService } from './product.service';

// Componente que representa a página de catálogo de produtos
@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent {
  public produtos: IProduct[] = []; // Lista de produtos
  public filtro: string = ''; // Filtro de categoria
  public carrinho: IProduct[] = []; // Carrinho de compras

  // Construtor da classe que recebe os serviços de carrinho e de produtos
  constructor(private produtoService: ProductService) { }

  // Método chamado quando o componente é inicializado
  public ngOnInit(): void {
    // Obtém a lista de produtos do serviço de produtos e a armazena na variável produtos
    // * O método obterProdutos() retorna um Observable, que é uma forma de trabalhar com assincronismo em Angular
    this.produtoService.obterProdutos().subscribe((produtos: IProduct[]) => {
      this.produtos = produtos;
    });
  }

  // Método que retorna a lista de produtos filtrada
  public obterProdutosFiltrados(): IProduct[] {
    // Se o filtro estiver vazio, retorna a lista de produtos completa
    // Caso contrário, retorna apenas os produtos cuja categoria é igual ao filtro
    // * O método filter() é um método de arrays que retorna um novo array com os elementos que atendem a uma condição
    return this.filtro === ''
      ? this.produtos
      : this.produtos.filter((produto: any) => produto.category === this.filtro);
  }

  // Método que adiciona um produto ao carrinho
  public adicionarAoCarrinho(produto: IProduct): void {
    // Adiciona o produto ao carrinho
    this.carrinho.push(produto);
    console.log(`O produto ${produto.nome} foi adicionado ao carrinho!`);
  }
}
