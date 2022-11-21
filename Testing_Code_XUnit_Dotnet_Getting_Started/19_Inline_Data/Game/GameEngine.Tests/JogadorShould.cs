using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class JogadorShould : IDisposable
    {
        private readonly Jogador sut;
        private readonly ITestOutputHelper output;

        public JogadorShould(ITestOutputHelper output)
        {
            this.output = output;

            this.output.WriteLine("Criando um novo Jogador");
            this.sut = new Jogador();
        }

        public void Dispose()
        {
            this.output.WriteLine($"Fazendo Dispose do Jogador {this.sut.NomeCompleto}");
        }

        [Fact]
        public void TornarInexperienteSeNovo()
        {
            Assert.True(sut.Iniciante);
        }

        [Fact]
        public void CalcularNomeCompleto()
        {
            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.Equal("Sarah Smith", sut.NomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void PossuiNomeCompletoIniciandoPeloPrimeiroNome()
        {
            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.StartsWith("Sarah", sut.NomeCompleto);
        }

        [Fact]
        public void PossuiNomeCompletoIniciandoTerminandoPeloSegundoNome()
        {
            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.EndsWith("Smith", sut.NomeCompleto);
        }

        [Fact]
        public void CalcularNomeCompleto_IgnorandoCase()
        {
            sut.PrimeiroNome = "SARAH";
            sut.SegundoNome = "SMITH";

            Assert.Equal("Sarah Smith", sut.NomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void CalcularNomeCompleto_ExemploSubstring()
        {
            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.Contains("ah Sm", sut.NomeCompleto);
        }


        [Fact]
        public void CalcularNomeCompletoComExpressaoRegular()
        {
            sut.PrimeiroNome = "Sarah";
            sut.SegundoNome = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.NomeCompleto);
        }

        [Fact]
        public void IniciaComSaudePadrao()
        {
            Assert.Equal(100, sut.Saude);
        }

        [Fact]
        public void IniciaComSaudePadrao_DiferenteZero()
        {
            Assert.NotEqual(0, sut.Saude);
        }

        [Fact]
        public void AumentaSaudeDepoisDormir()
        {
            sut.Dormir(); // Aguarda o aumento da Saude entre 1 a 100

            //Assert.True(sut.Saude >= 101 && sut.Saude <= 200);
            Assert.InRange(sut.Saude, 101, 200);
        }

        [Fact]
        public void NaoPossuiApelidoPorPadrao()
        {
            Assert.Null(sut.Apelido);
        }

        [Fact]
        public void PossuiLongBow()
        {
            Assert.Contains("Long Bow", sut.Armas);
        }

        [Fact]
        public void NaoPossuiStaffOfWonder()
        {
            Assert.DoesNotContain("Staff Of Wonder", sut.Armas);
        }

        [Fact]
        public void PossuiPeloMenosUmTipoDeSword()
        {
            Assert.Contains(sut.Armas, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void PossuiTodasAsArmas()
        {
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
            Assert.All(sut.Armas, arma => Assert.False(string.IsNullOrWhiteSpace(arma)));
        }

        [Fact]
        public void JogadorDormiuEvent()
        {
            Assert.Raises<EventArgs>(
                handler => sut.JogadorDormiu += handler,
                handler => sut.JogadorDormiu -= handler,
                () => sut.Dormir());
        }


        [Fact]
        public void RaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(sut, "Saude", () => sut.LevarDano(10));
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, 99)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]
        public void TakeDamage(int dano, int saudeEsperada)
        {
            sut.LevarDano(dano);

            Assert.Equal(saudeEsperada, sut.Saude);
        }
    }
}
