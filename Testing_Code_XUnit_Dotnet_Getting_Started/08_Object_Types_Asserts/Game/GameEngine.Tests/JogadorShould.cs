using System;
using Xunit;

namespace GameEngine.Tests
{
    public class JogadorShould
    {
        [Fact]
        public void TornarInexperienteSeNovo()
        {
            InimigoFactory sut = new InimigoFactory();

            Assert.True(sut.Iniciante);
        }

        [Fact]
        public void CalcularNomeCompleto()
        {
            InimigoFactory sut = new InimigoFactory();

            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.Equal("Sarah Smith", sut.NomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void PossuiNomeCompletoIniciandoPeloPrimeiroNome()
        {
            InimigoFactory sut = new InimigoFactory();

            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.StartsWith("Sarah", sut.NomeCompleto);
        }

        [Fact]
        public void PossuiNomeCompletoIniciandoTerminandoPeloSegundoNome()
        {
            InimigoFactory sut = new InimigoFactory();

            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.EndsWith("Smith", sut.NomeCompleto);
        }

        [Fact]
        public void CalcularNomeCompleto_IgnorandoCase()
        {
            InimigoFactory sut = new InimigoFactory();

            sut.PrimeiroNome = "SARAH";
            sut.SegundoNome = "SMITH";

            Assert.Equal("Sarah Smith", sut.NomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void CalcularNomeCompleto_ExemploSubstring()
        {
            InimigoFactory sut = new InimigoFactory();

            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.Contains("ah Sm", sut.NomeCompleto);
        }


        [Fact]
        public void CalcularNomeCompletoComExpressaoRegular()
        {
            InimigoFactory sut = new InimigoFactory();

            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.NomeCompleto);
        }

        [Fact]
        public void IniciaComSaudePadrao()
        {
            InimigoFactory sut = new InimigoFactory();

            Assert.Equal(100, sut.Saude);
        }

        [Fact]
        public void IniciaComSaudePadrao_DiferenteZero()
        {
            InimigoFactory sut = new InimigoFactory();

            Assert.NotEqual(0, sut.Saude);
        }

        [Fact]
        public void AumentaSaudeDepoisDormir()
        {
            InimigoFactory sut = new InimigoFactory();

            sut.Dormir(); // Aguarda o aumento da Saude entre 1 a 100

            //Assert.True(sut.Saude >= 101 && sut.Saude <= 200);
            Assert.InRange(sut.Saude, 101, 200);
        }

        [Fact]
        public void NaoPossuiApelidoPorPadrao()
        {
            InimigoFactory sut = new InimigoFactory();

            Assert.Null(sut.Apelido);
        }

        [Fact]
        public void PossuiLongBow()
        {
            InimigoFactory sut = new InimigoFactory();

            Assert.Contains("Long Bow", sut.Armas);
        }

        [Fact]
        public void NaoPossuiStaffOfWonder()
        {
            InimigoFactory sut = new InimigoFactory();

            Assert.DoesNotContain("Staff Of Wonder", sut.Armas);
        }

        [Fact]
        public void PossuiPeloMenosUmTipoDeSword()
        {
            InimigoFactory sut = new InimigoFactory();

            Assert.Contains(sut.Armas, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void PossuiTodasAsArmas()
        {
            InimigoFactory sut = new InimigoFactory();

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
            InimigoFactory sut = new InimigoFactory();

            Assert.All(sut.Armas, arma => Assert.False(string.IsNullOrWhiteSpace(arma)));
        }
    }
}
