import { Injectable } from '@angular/core';
import { IProduct } from '../catalog/product.model';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

// Serviço que representa o carrinho de compras
@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {
  // Variável que armazena o carrinho de compras
  // * O BehaviorSubject é um tipo de Observable que armazena o valor atual e notifica os observadores quando esse valor muda
  private carrinho: BehaviorSubject<IProduct[]> = new BehaviorSubject<IProduct[]>([]);

  constructor(private http: HttpClient) {
    // Faz uma requisição GET para a URL '/api/carrinho' e armazena o resultado na variável carrinho
    // * O método subscribe() é utilizado para se inscrever a um Observable e receber notificações quando o valor do Observable muda
    // * O método next() é utilizado para notificar os observadores de um BehaviorSubject que o valor mudou
    this.http.get<IProduct[]>('/api/carrinho').subscribe({
      next: (carrinho) => this.carrinho.next(carrinho) // Notifica os observadores de que o carrinho foi atualizado
    });
  }

  public obterCarrinho(): Observable<IProduct[]> {
    // Retorna o carrinho como um Observable
    // * O método asObservable() é utilizado para retornar um Observable a partir de um BehaviorSubject
    return this.carrinho.asObservable();
  }

  // Método que adiciona um produto ao carrinho
  public adicionar(produto: IProduct): void {
    // Cria um novo array com o produto adicionado
    // * O operador spread (...) é utilizado para criar uma cópia de um array
    const novoCarrinho = [...this.carrinho.getValue(), produto];
    // Atualiza o carrinho com o novo array
    this.carrinho.next(novoCarrinho); // Notifica os observadores de que o carrinho foi atualizado
    // Faz uma requisição POST para a URL '/api/carrinho' com o carrinho atualizado
    this.http.post('/api/carrinho', novoCarrinho).subscribe(() => {
      // Exibe uma mensagem no console informando que o produto foi adicionado ao carrinho se a requisição for bem-sucedida
      console.log(`O produto ${produto.nome} foi adicionado ao carrinho!`);
    });
  }

  // Método que remove um produto do carrinho
  public remover(produto: IProduct): void {
    // Cria um novo array sem o produto removido
    // * O método filter() é um método de arrays que retorna um novo array com os elementos que atendem a uma condição
    const novoCarrinho = this.carrinho.getValue().filter((p: IProduct) => p !== produto);
    // Atualiza o carrinho com o novo array
    this.carrinho.next(novoCarrinho); // Notifica os observadores de que o carrinho foi atualizado
    // Faz uma requisição POST para a URL '/api/carrinho' com o carrinho atualizado
    this.http.post('/api/carrinho', novoCarrinho).subscribe(() => {
      // Exibe uma mensagem no console informando que o produto foi removido do carrinho se a requisição for bem-sucedida
      console.log(`O produto ${produto.nome} foi removido do carrinho!`);
    });
  }
}
