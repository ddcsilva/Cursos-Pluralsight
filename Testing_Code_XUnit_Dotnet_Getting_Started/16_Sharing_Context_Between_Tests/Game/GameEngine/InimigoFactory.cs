using System;

namespace GameEngine
{
    public class InimigoFactory
    {
        public Inimigo Create(string nome, bool isBoss = false)
        {
            if (nome is null)
            {
                throw new ArgumentNullException(nameof(nome));
            }

            if (isBoss)
            {
                if (!IsNomeBossValido(nome))
                {
                    throw new CreateInimigoException($"{nome} o nome não é válido para o tipo Boss, este inimigo deve iniciar com 'Rei' ou 'Rainha'", nome);
                }

                return new Boss { Nome = nome };
            }

            return new InimigoNormal { Nome = nome };
        }

        private bool IsNomeBossValido(string nome) => nome.StartsWith("Rei") || nome.StartsWith("Rainha");
    }
}
