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

        [Fact]
        public void IniciaComSaudePadrao()
        {
            Jogador sut = new Jogador();

            Assert.Equal(100, sut.Saude);
        }

        [Fact]
        public void IniciaComSaudePadrao_DiferenteZero()
        {
            Jogador sut = new Jogador();

            Assert.NotEqual(0, sut.Saude);
        }

        [Fact]
        public void AumentaSaudeDepoisDormir()
        {
            Jogador sut = new Jogador();

            sut.Dormir(); // Aguarda o aumento da Saude entre 1 a 100

            //Assert.True(sut.Saude >= 101 && sut.Saude <= 200);
            Assert.InRange(sut.Saude, 101, 200);
        }

        [Fact]
        public void NaoPossuiApelidoPorPadrao()
        {
            Jogador sut = new Jogador();

            Assert.Null(sut.Apelido);
        }

        [Fact]
        public void PossuiLongBow()
        {
            Jogador sut = new Jogador();

            Assert.Contains("Long Bow", sut.Armas);
        }

        [Fact]
        public void NaoPossuiStaffOfWonder()
        {
            Jogador sut = new Jogador();

            Assert.DoesNotContain("Staff Of Wonder", sut.Armas);
        }

        [Fact]
        public void PossuiPeloMenosUmTipoDeSword()
        {
            Jogador sut = new Jogador();

            Assert.Contains(sut.Armas, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void PossuiTodasAsArmas()
        {
            Jogador sut = new Jogador();

            var armasEsperadas = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(armasEsperadas, sut.Armas);
        }

        [Fact]
        public void PossuiArmasPorPadrao()
        {
            Jogador sut = new Jogador();

            Assert.All(sut.Armas, arma => Assert.False(string.IsNullOrWhiteSpace(arma)));
        }

        [Fact]
        public void JogadorDormiuEvent()
        {
            Jogador sut = new Jogador();

            Assert.Raises<EventArgs>(
                handler => sut.JogadorDormiu += handler,
                handler => sut.JogadorDormiu -= handler,
                () => sut.Dormir());
        }


        [Fact]
        public void RaisePropertyChangedEvent()
        {
            Jogador sut = new Jogador();

            Assert.PropertyChanged(sut, "Saude", () => sut.LevarDano(10));
        }
    }
}
