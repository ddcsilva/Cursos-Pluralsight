import { StrengthPipe } from "./strength.pipe";

describe('StrengthPipe', () => {
    it('Deve mostrar a força como fraca se o valor for 5', () => {
        // Arrange
        let pipe = new StrengthPipe();

        // Act
        let valor = pipe.transform(5);

        // Assert
        expect(valor).toEqual('5 (weak)');
    });

    it('Deve mostrar a força como forte se o valor for 10', () => {
        // Arrange
        let pipe = new StrengthPipe();

        // Act
        let valor = pipe.transform(10);

        // Assert
        expect(valor).toEqual('10 (strong)');
    });
});