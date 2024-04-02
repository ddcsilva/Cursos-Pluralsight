import { Injectable } from '@angular/core';
import { IProduct } from './catalog/product.model';
import { HttpClient } from '@angular/common/http';

// Serviço que representa o carrinho de compras
@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {
  public carrinho: IProduct[] = []; // Carrinho de compras

  constructor(private http: HttpClient) { }

  // Método que adiciona um produto ao carrinho
  public adicionar(produto: IProduct): void {
    // Adiciona o produto ao carrinho
    this.carrinho.push(produto);
    // Faz uma requisição POST para a URL '/api/carrinho' com o carrinho atualizado
    this.http.post('/api/carrinho', this.carrinho).subscribe(() => {
      // Exibe uma mensagem no console informando que o produto foi adicionado ao carrinho se a requisição for bem-sucedida
      console.log(`O produto ${produto.nome} foi adicionado ao carrinho!`);
    });
  }
}
