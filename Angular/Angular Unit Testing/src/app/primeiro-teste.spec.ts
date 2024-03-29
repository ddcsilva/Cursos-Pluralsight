// describe => Função de agrupamento de testes
// Lê-se: Descreva o MeuPrimeiroTeste
describe('MeuPrimeiroTeste', () => {
    let sut; // System Under Test => Objeto que será testado

    // beforeEach => Função que será executada antes de cada teste
    beforeEach(() => {
        sut = {}; // Inicializa o objeto que será testado
    });

    // it => Função de teste
    // Lê-se: Deve ser verdadeiro se verdadeiro
    it('Deve ser verdadeiro se verdadeiro', () => {
        // Arrange => Preparação do teste
        sut.a = false;

        // Act => Execução do teste
        sut.a = true;

        // Assert => Verificação do teste
        // expect => Função de verificação. Recebe o valor a ser verificado
        // toBe => Função de comparação. Recebe o valor esperado
        expect(sut.a).toBe(true);
    });
});