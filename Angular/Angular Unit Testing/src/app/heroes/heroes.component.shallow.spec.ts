import { ComponentFixture, TestBed } from "@angular/core/testing";
import { HeroesComponent } from "./heroes.component";
import { HeroService } from "../hero.service";
import { of } from "rxjs";
import { Component, Input } from "@angular/core";
import { Hero } from "../hero";
import { By } from "@angular/platform-browser";

describe('HeroesComponent (shallow tests)', () => {
    let fixture: ComponentFixture<HeroesComponent>;
    let mockHeroService;
    let HEROES;

    // Simula um componente filho
    @Component({
        selector: "app-hero",
        template: "<div></div>"
    })
    class FakeHeroComponent {
        @Input() hero: Hero;
        // @Output() delete = new EventEmitter();
    }

    beforeEach(() => {
        HEROES = [
            { id: 1, name: 'SpiderDude', strength: 8 },
            { id: 2, name: 'Wonderful Woman', strength: 24 },
            { id: 3, name: 'SuperDude', strength: 55 }
        ];

        mockHeroService = jasmine.createSpyObj(['getHeroes', 'addHero', 'deleteHero']);

        TestBed.configureTestingModule({
            declarations: [
                HeroesComponent,
                FakeHeroComponent // Declara o componente fake para ser utilizado no teste
            ],
            providers: [
                { provide: HeroService, useValue: mockHeroService }
            ],
            schemas: []
        });

        fixture = TestBed.createComponent(HeroesComponent);
    });

    it('Deve definir os heróis corretamente do serviço', () => {
        // Arrange => Preparação do teste
        // and.returnValue => Define o valor de retorno de um método
        mockHeroService.getHeroes.and.returnValue(of(HEROES)); // Define que o método getHeroes deve retornar um observable com a lista de heróis

        // Act => Execução do teste
        fixture.detectChanges(); // Atualiza o componente

        // Assert => Verificação do teste
        // Lê-se: Espera que os heróis do componente sejam iguais aos heróis definidos
        expect(fixture.componentInstance.heroes.length).toBe(3);
    });

    it('Deve criar um li para cada herói', () => {
        // Arrange => Preparação do teste
        mockHeroService.getHeroes.and.returnValue(of(HEROES)); // Define que o método getHeroes deve retornar um observable com a lista de heróis

        // Act => Execução do teste
        fixture.detectChanges(); // Atualiza o componente

        // Assert => Verificação do teste
        // queryAll => Busca todos os elementos que correspondem ao seletor passado
        // Lê-se: Espera que o número de elementos li seja igual ao número de heróis
        expect(fixture.debugElement.queryAll(By.css('li')).length).toBe(3);
    });
});