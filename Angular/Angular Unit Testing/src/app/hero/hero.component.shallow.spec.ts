import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HeroComponent } from './hero.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { By } from '@angular/platform-browser';

// describe => Função de agrupamento de testes
// Lê-se: Descreva o HeroComponent
describe('HeroComponent (shallow tests)', () => {
  let component: HeroComponent; // Variável que armazenará a instância do componente
  let fixture: ComponentFixture<HeroComponent>; // ComponentFixture é uma classe do Angular que permite manipular o componente

  // beforeEach => Função que será executada antes de cada teste
  // TestBed.configureTestingModule => Configuração do módulo de testes
  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HeroComponent], // Declarando o componente a ser testado
      schemas: [NO_ERRORS_SCHEMA], // Schemas é uma propriedade que permite ignorar a validação de propriedades desconhecidas
    });

    // createComponent => Método que cria uma instância do componente
    fixture = TestBed.createComponent(HeroComponent);
    // componentInstance => Propriedade que retorna a instância do componente
    component = fixture.componentInstance;
  });

  // it => Função de teste
  // Lê-se: Deve ser criado
  it('Deve ser criado', () => {
    // Lê-se: Espera que a instância do componente não seja nula
    expect(component).toBeTruthy();
  });

  // it => Função de teste
  // Lê-se: Deve ter o herói correto
  it('Deve ter o herói correto', () => {
    // Arrange => Preparação do teste
    component.hero = { id: 1, name: 'Superman', strength: 9 };

    // Act => Execução do teste
    fixture.detectChanges(); // Método que atualiza o componente. Sem ele, o componente não será renderizado

    // Assert => Verificação do teste
    // Lê-se: Espera que o herói seja igual ao objeto informado
    expect(component.hero.name).toEqual('Superman');
  });

  it('Deve renderizar o herói correto em um link', () => {
    // Arrange => Preparação do teste
    component.hero = { id: 1, name: 'Superman', strength: 9 };

    // Act => Execução do teste
    fixture.detectChanges(); // Método que atualiza o componente. Sem ele, o componente não será renderizado

    // Assert => Verificação do teste
    // Lê-se: Espera que o texto do link seja igual ao nome do herói
    expect(fixture.nativeElement.querySelector('a').textContent).toContain('Superman');

    // Outra forma de fazer a mesma verificação
    // query => Método que busca um elemento no DOM
    // By.css => Método que busca um elemento pelo seletor CSS
    let deA = fixture.debugElement.query(By.css('a'));
    expect(deA.nativeElement.textContent).toContain('Superman');
  });
});