import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProduct } from './product.model';
import { Observable } from 'rxjs';

// Serviço que representa a entidade Produto
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  // Construtor da classe que recebe o serviço de HTTP
  // * O serviço de HTTP é utilizado para fazer requisições HTTP
  constructor(private http: HttpClient) { }

  // Método que retorna a lista de produtos
  // * O método obterProdutos() retorna um Observable, que é uma forma de trabalhar com assincronismo em Angular
  public obterProdutos(): Observable<IProduct[]> {
    // Faz uma requisição GET para a URL '/api/produtos' e retorna o resultado
    return this.http.get<IProduct[]>('/api/produtos');
  }
}
