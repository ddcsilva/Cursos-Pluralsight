import { MessageService } from "./message.service";

describe('MessageService', () => {
    let service: MessageService;

    beforeEach(() => {

    });

    it('Deve ser inicializado sem mensagens', () => {
        // Arrange
        service = new MessageService();

        // Act
        let quantidadeDeMensagens = service.messages.length;

        // Assert
        expect(quantidadeDeMensagens).toEqual(0);
    });

    it('Deve adicionar uma mensagem quando add é chamado', () => {
        // Arrange
        service = new MessageService();

        // Act
        service.add('mensagem1');

        // Assert
        expect(service.messages.length).toEqual(1);
    });

    it('Deve remover todas as mensagens quando clear é chamado', () => {
        // Arrange
        service = new MessageService();
        service.add('mensagem1');

        // Act
        service.clear();

        // Assert
        expect(service.messages.length).toEqual(0);
    });
});