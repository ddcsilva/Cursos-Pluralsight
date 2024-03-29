import { StrengthPipe } from "./strength.pipe";

// describe => Função de agrupamento de testes
// Lê-se: Descreva o StrengthPipe
describe('StrengthPipe', () => {
    // it => Função de teste
    // Lê-se: Deve mostrar a força como weak se o valor for 5
    it('Deve mostrar a força como weak se o valor for 5', () => {
        // Arrange => Preparação do teste
        let pipe = new StrengthPipe();

        // Act => Execução do teste
        let valor = pipe.transform(5);

        // Assert => Verificação do teste
        // Lê-se: Espera que o valor seja igual a '5 (weak)'
        expect(valor).toEqual('5 (weak)');
    });

    // it => Função de teste
    // Lê-se: Deve mostrar a força como strong se o valor for 10
    it('Deve mostrar a força como strong se o valor for 10', () => {
        // Arrange => Preparação do teste
        let pipe = new StrengthPipe();

        // Act => Execução do teste
        let valor = pipe.transform(10);

        // Assert => Verificação do teste
        // Lê-se: Espera que o valor seja igual a '10 (strong)'
        expect(valor).toEqual('10 (strong)');
    });

    // it => Função de teste
    // Lê-se: Deve mostrar a força como unbelievable se o valor for 20
    it('Deve mostrar a força como unbelievable se o valor for 20', () => {
        // Arrange => Preparação do teste
        let pipe = new StrengthPipe();

        // Act => Execução do teste
        let valor = pipe.transform(20);

        // Assert => Verificação do teste
        // Lê-se: Espera que o valor seja igual a '20 (unbelievable)'
        expect(valor).toEqual('20 (unbelievable)');
    });
});