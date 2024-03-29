import { of } from "rxjs";
import { HeroesComponent } from "./heroes.component";

// describe => Função de agrupamento de testes
// Lê-se: Descreva o HeroesComponent
describe('HeroesComponent', () => {
    let component: HeroesComponent; // Variável que armazenará a instância da classe HeroesComponent
    let heroes; // Variável que armazenará a lista de heróis
    let mockHeroService; // Variável que armazenará o mock do serviço de heróis

    // beforeEach => Função que será executada antes de cada teste
    beforeEach(() => {
        heroes = [
            { id: 1, name: 'SpiderDude', strength: 8 },
            { id: 2, name: 'Wonderful Woman', strength: 24 },
            { id: 3, name: 'SuperDude', strength: 55 }
        ];

        // jasmine.createSpyObj => Cria um mock de um objeto
        // Parâmetros: Array de strings com os nomes dos métodos que o mock deve ter
        mockHeroService = jasmine.createSpyObj(['getHeroes', 'addHero', 'deleteHero']); // Cria um mock do serviço de heróis

        // Cria uma instância da classe HeroesComponent, passando o mock do serviço de heróis
        component = new HeroesComponent(mockHeroService);
    });

    // describe => Função de agrupamento de testes
    // Lê-se: Descreva o delete
    describe('delete', () => {
        // it => Função de teste
        // Lê-se: Deve remover o herói da lista
        it('Deve remover o herói da lista', () => {
            // Arrange => Preparação do teste
            // and.returnValue => Define o valor de retorno de um método
            // of => Cria um observable com o valor passado
            mockHeroService.deleteHero.and.returnValue(of(true)); // Define que o método deleteHero deve retornar um observable com o valor true
            component.heroes = heroes; // Atribui a lista de heróis ao componente

            // Act => Execução do teste
            component.delete(heroes[2]); // Chama o método delete, passando o herói a ser removido através do índice

            // Assert => Verificação do teste
            // Lê-se: Espera que o tamanho da lista de heróis seja igual a 2
            expect(component.heroes.length).toBe(2); // Verifica se o herói foi removido da lista
            // toHaveBeenCalledWith => Verifica se o método foi chamado com os parâmetros corretos
            // Lê-se: Espera que o método deleteHero tenha sido chamado com o herói correto
            expect(mockHeroService.deleteHero).toHaveBeenCalledWith(heroes[2]);
        });

        it('Deve chamar deleteHero com o herói correto', () => {
            // Arrange => Preparação do teste
            // and.returnValue => Define o valor de retorno de um método
            // of => Cria um observable com o valor passado
            mockHeroService.deleteHero.and.returnValue(of(true)); // Define que o método deleteHero deve retornar um observable com o valor true
            component.heroes = heroes; // Atribui a lista de heróis ao componente

            // Act => Execução do teste
            component.delete(heroes[2]); // Chama o método delete, passando o herói a ser removido através do índice

            // Assert => Verificação do teste
            // toHaveBeenCalled => Verifica se o método foi chamado
            expect(mockHeroService.deleteHero).toHaveBeenCalledWith(heroes[2]);
        });
    });
});