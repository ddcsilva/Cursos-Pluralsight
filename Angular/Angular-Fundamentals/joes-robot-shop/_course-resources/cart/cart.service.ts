import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { IProduct } from 'src/app/catalog/product.model';

// Serviço que representa o carrinho de compras
@Injectable({
  providedIn: 'root',
})
export class CartService {
  // Variável que armazena o carrinho de compras
  // * BehaviorSubject é um tipo de Observable que armazena o último valor emitido
  private carrinho: BehaviorSubject<IProduct[]> = new BehaviorSubject<IProduct[]>([]);

  // Construtor da classe que recebe o serviço de HTTP
  constructor(private http: HttpClient) {
    // Faz uma requisição GET para a URL '/api/cart' e armazena o resultado na variável carrinho
    this.http.get<IProduct[]>('/api/cart').subscribe({
      // Quando a requisição é completada, atualiza o valor do BehaviorSubject carrinho
      next: (cart) => this.carrinho.next(cart),
    });
  }

  // Método que retorna o carrinho de compras
  public obterCarrinho(): Observable<IProduct[]> {
    // Retorna o BehaviorSubject carrinho como um Observable
    return this.carrinho.asObservable();
  }

  // Método que adiciona um produto ao carrinho
  public adicionarProduto(produto: IProduct) {
    // Adiciona o produto ao carrinho
    // * O método getValue() retorna o valor atual do BehaviorSubject carrinho
    const novoCarrinho = [...this.carrinho.getValue(), produto];
    // Atualiza o valor do BehaviorSubject carrinho
    this.carrinho.next(novoCarrinho);
    // Faz uma requisição POST para a URL '/api/cart' com o novo carrinho
    this.http.post('/api/cart', novoCarrinho).subscribe(() => {
      console.log(`O produto ${produto.nome} foi adicionado ao carrinho!`);
    });
  }

  // Método que remove um produto do carrinho
  public removerProduto(produto: IProduct) {
    // Remove o produto do carrinho
    // * O método getValue() retorna o valor atual do BehaviorSubject carrinho
    // * O método filter() é um método de arrays que retorna um novo array com os elementos que atendem a uma condição
    let novoCarrinho = this.carrinho.getValue().filter((i) => i !== produto);
    // Atualiza o valor do BehaviorSubject carrinho
    this.carrinho.next(novoCarrinho);
    // Faz uma requisição POST para a URL '/api/cart' com o novo carrinho
    this.http.post('/api/cart', novoCarrinho).subscribe(() => {
      console.log(`O produto ${produto.nome} foi removido do carrinho!`);
    });
  }
}
