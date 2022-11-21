using System;

namespace GameEngine
{
    public class CreateInimigoException : Exception
    {
        public CreateInimigoException(string mensagem, string nomeInimigo) : base(mensagem)
        {
            RequestedNomeInimigo = nomeInimigo;
        }

        public string RequestedNomeInimigo { get; private set; }
    }
}
