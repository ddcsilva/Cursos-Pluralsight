import { of } from "rxjs";
import { HeroesComponent } from "./heroes.component";

describe('HeroesComponent', () => {
    let component: HeroesComponent;
    let heroes;
    let mockHeroService;

    beforeEach(() => {
        heroes = [
            { id: 1, name: 'SpiderDude', strength: 8 },
            { id: 2, name: 'Wonderful Woman', strength: 24 },
            { id: 3, name: 'SuperDude', strength: 55 }
        ];

        mockHeroService = jasmine.createSpyObj(['getHeroes', 'addHero', 'deleteHero']);

        component = new HeroesComponent(mockHeroService);
    });

    describe('delete', () => {
        it('Deve remover o herói da lista', () => {
            // Arrange
            mockHeroService.deleteHero.and.returnValue(of(true));
            component.heroes = heroes;

            // Act
            component.delete(heroes[2]);

            // Assert
            expect(component.heroes.length).toBe(2); // Verifica se o herói foi removido da lista
            // toHaveBeenCalledWith => Verifica se o método foi chamado com os parâmetros corretos
            expect(mockHeroService.deleteHero).toHaveBeenCalledWith(heroes[2]); // Verifica se o método deleteHero foi chamado com o herói correto
        });
    });
});