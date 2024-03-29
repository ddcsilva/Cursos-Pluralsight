import { MessageService } from "./message.service";

// describe => Função de agrupamento de testes
// Lê-se: Descreva o MessageService
describe('MessageService', () => {
    let service: MessageService; // Variável que armazenará a instância da classe MessageService

    // beforeEach => Função que será executada antes de cada teste
    beforeEach(() => {

    });

    // it => Função de teste
    // Lê-se: Deve ser inicializado sem mensagens
    it('Deve ser inicializado sem mensagens', () => {
        // Arrange => Preparação do teste
        service = new MessageService();

        // Act => Execução do teste
        let quantidadeDeMensagens = service.messages.length; // Obtém a quantidade de mensagens

        // Assert => Verificação do teste
        // Lê-se: Espera que a quantidade de mensagens seja igual a 0
        expect(quantidadeDeMensagens).toEqual(0);
    });

    // it => Função de teste
    // Lê-se: Deve adicionar uma mensagem quando add é chamado
    it('Deve adicionar uma mensagem quando add é chamado', () => {
        // Arrange => Preparação do teste
        service = new MessageService();

        // Act => Execução do teste
        service.add('mensagem1');

        // Assert => Verificação do teste
        // Lê-se: Espera que a quantidade de mensagens seja igual a 1
        expect(service.messages.length).toEqual(1);
    });

    // it => Função de teste
    // Lê-se: Deve remover todas as mensagens quando clear é chamado
    it('Deve remover todas as mensagens quando clear é chamado', () => {
        // Arrange => Preparação do teste
        service = new MessageService();
        service.add('mensagem1');

        // Act => Execução do teste
        service.clear();

        // Assert => Verificação do teste
        // Lê-se: Espera que a quantidade de mensagens seja igual a 0
        expect(service.messages.length).toEqual(0);
    });
});