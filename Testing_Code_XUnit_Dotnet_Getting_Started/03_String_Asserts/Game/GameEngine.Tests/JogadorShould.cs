using System;
using Xunit;

namespace GameEngine.Tests
{
    public class JogadorShould
    {
        [Fact]
        public void TornarInexperienteSeNovo()
        {
            Jogador sut = new Jogador();

            Assert.True(sut.Iniciante);
        }

        [Fact]
        public void CalcularNomeCompleto()
        {
            Jogador sut = new Jogador();

            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.Equal("Sarah Smith", sut.NomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void PossuiNomeCompletoIniciandoPeloPrimeiroNome()
        {
            Jogador sut = new Jogador();

            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.StartsWith("Sarah", sut.NomeCompleto);
        }

        [Fact]
        public void PossuiNomeCompletoIniciandoTerminandoPeloSegundoNome()
        {
            Jogador sut = new Jogador();

            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.EndsWith("Smith", sut.NomeCompleto);
        }

        [Fact]
        public void CalcularNomeCompleto_IgnorandoCase()
        {
            Jogador sut = new Jogador();

            sut.PrimeiroNome = "SARAH";
            sut.SegundoNome = "SMITH";

            Assert.Equal("Sarah Smith", sut.NomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void CalcularNomeCompleto_ExemploSubstring()
        {
            Jogador sut = new Jogador();

            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.Contains("ah Sm", sut.NomeCompleto);
        }


        [Fact]
        public void CalcularNomeCompletoComExpressaoRegular()
        {
            Jogador sut = new Jogador();

            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.NomeCompleto);
        }
    }
}
