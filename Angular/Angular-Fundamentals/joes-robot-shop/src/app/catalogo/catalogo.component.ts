import { Component } from '@angular/core';
import { IProduto } from './produto.model';

@Component({
  selector: 'bot-catalogo',
  templateUrl: './catalogo.component.html',
  styleUrls: ['./catalogo.component.css']
})
export class CatalogoComponent {
  produto: IProduto;

  constructor() {
    this.produto = {
      id: 1,
      descricao: 'Uma cabeça de robô amigável com dois olhos e um sorriso - ótima para uso doméstico.',
      nome: 'Robo Amigável',
      nomeImagem: 'head-friendly.png',
      categoria: 'Cabeças',
      preco: 945.0,
      desconto: 0.2
    };
  }

  obterUrlImagem(produto: IProduto) {
    return `assets/images/robot-parts/${produto.nomeImagem}`;
  }
}
