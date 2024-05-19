import { Component } from '@angular/core';
import { IProduto } from './produto.model';

@Component({
  selector: 'bot-catalogo',
  templateUrl: './catalogo.component.html',
  styleUrls: ['./catalogo.component.css']
})
export class CatalogoComponent {
  produtos: IProduto[];
  filtro: string = '';

  constructor() {
    this.produtos = [
      {
        id: 1,
        descricao:
          'Uma cabeça de robô com um olho incomumente grande e pescoço telescópico -- excelente para explorar lugares altos.',
        nome: 'Ciclope Grande',
        nomeImagem: 'head-big-eye.png',
        categoria: 'Cabeças',
        preco: 1220.5,
        desconto: 0.2,
      },
      {
        id: 17,
        descricao: 'Uma base com mola - ótima para alcançar lugares altos.',
        nome: 'Base com Mola',
        nomeImagem: 'base-spring.png',
        categoria: 'Bases',
        preco: 1190.5,
        desconto: 0,
      },
      {
        id: 6,
        descricao:
          'Um braço articulado com uma garra -- ótimo para alcançar cantos ou trabalhar em espaços apertados.',
        nome: 'Braço Articulado',
        nomeImagem: 'arm-articulated-claw.png',
        categoria: 'Braços',
        preco: 275,
        desconto: 0,
      },
      {
        id: 2,
        descricao:
          'Uma cabeça de robô amigável com dois olhos e um sorriso -- ótima para uso doméstico.',
        nome: 'Robô Amigável',
        nomeImagem: 'head-friendly.png',
        categoria: 'Cabeças',
        preco: 945.0,
        desconto: 0.2,
      },
      {
        id: 3,
        descricao:
          'Uma grande cabeça de três olhos com um triturador na boca -- ótima para triturar metais leves ou destruir documentos.',
        nome: 'Triturador',
        nomeImagem: 'head-shredder.png',
        categoria: 'Cabeças',
        preco: 1275.5,
        desconto: 0,
      },
      {
        id: 16,
        descricao:
          'Uma base de uma única roda com um acelerômetro capaz de alcançar altas velocidades e navegar por terrenos irregulares.',
        nome: 'Base de Roda Única',
        nomeImagem: 'base-single-wheel.png',
        categoria: 'Bases',
        preco: 1190.5,
        desconto: 0.1,
      },
      {
        id: 13,
        descricao: 'Um tronco simples com um bolso para carregar itens.',
        nome: 'Tronco com Bolso',
        nomeImagem: 'torso-pouch.png',
        categoria: 'Troncos',
        preco: 785,
        desconto: 0,
      },
      {
        id: 7,
        descricao:
          'Um braço com duas garras independentes -- ótimo quando você precisa de uma mão extra. Precisa de quatro mãos? Equipe seu robô com dois desses braços.',
        nome: 'Braço de Duas Garras',
        nomeImagem: 'arm-dual-claw.png',
        categoria: 'Braços',
        preco: 285,
        desconto: 0,
      },
      {
        id: 4,
        descricao: 'Uma cabeça simples com um único olho -- simples e barata.',
        nome: 'Ciclope Pequeno',
        nomeImagem: 'head-single-eye.png',
        categoria: 'Cabeças',
        preco: 750.0,
        desconto: 0,
      },
      {
        id: 9,
        descricao:
          'Um braço com uma hélice -- bom para propulsão ou como ventilador.',
        nome: 'Braço com Hélice',
        nomeImagem: 'arm-propeller.png',
        categoria: 'Braços',
        preco: 230,
        desconto: 0.1,
      },
      {
        id: 15,
        descricao: 'Uma base com foguete capaz de voo controlado em alta velocidade.',
        nome: 'Base com Foguete',
        nomeImagem: 'base-rocket.png',
        categoria: 'Bases',
        preco: 1520.5,
        desconto: 0,
      },
      {
        id: 10,
        descricao: 'Um braço curto e robusto com uma garra -- simples, mas barato.',
        nome: 'Braço com Garra Robusta',
        nomeImagem: 'arm-stubby-claw.png',
        categoria: 'Braços',
        preco: 125,
        desconto: 0,
      },
      {
        id: 11,
        descricao:
          'Um tronco que pode dobrar ligeiramente na cintura e equipado com um medidor de calor.',
        nome: 'Tronco Flexível com Medidor',
        nomeImagem: 'torso-flexible-gauged.png',
        categoria: 'Troncos',
        preco: 1575,
        desconto: 0,
      },
      {
        id: 14,
        descricao: 'Uma base de duas rodas com um acelerômetro para estabilidade.',
        nome: 'Base de Duas Rodas',
        nomeImagem: 'base-double-wheel.png',
        categoria: 'Bases',
        preco: 895,
        desconto: 0,
      },
      {
        id: 5,
        descricao:
          'Uma cabeça de robô com três olhos oscilantes -- excelente para vigilância.',
        nome: 'Vigilância',
        nomeImagem: 'head-surveillance.png',
        categoria: 'Cabeças',
        preco: 1255.5,
        desconto: 0,
      },
      {
        id: 8,
        descricao: 'Um braço telescópico com um pegador.',
        nome: 'Braço com Pegador',
        nomeImagem: 'arm-grabber.png',
        categoria: 'Braços',
        preco: 205.5,
        desconto: 0,
      },
      {
        id: 12,
        descricao: 'Um tronco menos flexível com um medidor de bateria.',
        nome: 'Tronco com Medidor',
        nomeImagem: 'torso-gauged.png',
        categoria: 'Troncos',
        preco: 1385,
        desconto: 0,
      },
      {
        id: 18,
        descricao:
          'Uma base de três rodas barata, apenas capaz de velocidades lentas e só pode funcionar em superfícies lisas.',
        nome: 'Base de Três Rodas',
        nomeImagem: 'base-triple-wheel.png',
        categoria: 'Bases',
        preco: 700.5,
        desconto: 0,
      },
    ];
  }

  obterUrlImagem(produto: IProduto) {
    return `assets/images/robot-parts/${produto.nomeImagem}`;
  }

  obterProdutosFiltrados() {
    return this.filtro === ''
      ? this.produtos
      : this.produtos.filter((produto) => produto.categoria === this.filtro);
  }
}
