describe('Meu Primeiro Teste', () => {
    let sut;

    // beforeEach => Antes de cada teste
    beforeEach(() => {
        sut = {}; // Inicializa o objeto
    });

    // it => Função de teste
    it('Deve ser verdadeiro se verdadeiro', () => {
        // Arrange
        sut.a = false;

        // Act
        sut.a = true;

        // Assert
        // expect => Função de asserção
        // toBe => Função de comparação
        expect(sut.a).toBe(true); // Deve ser verdadeiro
    });
});