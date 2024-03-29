import { Injectable } from '@angular/core';

@Injectable()
// Serviço que gerencia mensagens, permitindo adicionar e limpar mensagens
export class MessageService {
  messages: string[] = [];

  // Adiciona uma mensagem ao array de mensagens
  add(message: string) {
    this.messages.push(message);
  }

  // Limpa o array de mensagens
  clear() {
    this.messages = [];
  }
}
