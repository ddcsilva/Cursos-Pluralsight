using System;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Categoria", "Inimigo")]
    public class InimigoFactoryShould
    {
        [Fact]
        public void CriaInimigoNormalPorPadrao()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo = sut.Create("Zombie");

            Assert.IsType<InimigoNormal>(inimigo);
        }

        [Fact(Skip = "Não preciso executar isto")]
        public void CriaInimigoNormalPorPadrao_TipoIncorreto()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(inimigo);
        }

        [Fact]
        public void CriaBoss()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo = sut.Create("Rei Zombie", true);

            Assert.IsType<Boss>(inimigo);
        }

        [Fact]
        public void CriaBoss_CastReturnedTypeExample()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo = sut.Create("Rei Zombie", true);

            // Faz o assert e pega o retorno do Cast
            Boss boss = Assert.IsType<Boss>(inimigo);

            // Assert adicional com o tipo do Objeto
            Assert.Equal("Rei Zombie", boss.Nome);
        }

        [Fact]
        public void CriaBoss_AssertTiposDerivados()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo = sut.Create("Rei Zombie", true);

            //Assert.IsType<Inimigo>(inimigo);
            Assert.IsAssignableFrom<Inimigo>(inimigo);
        }

        [Fact]
        public void CriaInstanciasSeparadas()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo1 = sut.Create("Zombie");
            Inimigo inimigo2 = sut.Create("Zombie");

            Assert.NotSame(inimigo1, inimigo2);
        }

        [Fact]
        public void NaoAceitaNomeNulo()
        {
            InimigoFactory sut = new InimigoFactory();

            // Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            Assert.Throws<ArgumentNullException>("nome", () => sut.Create(null));
        }

        [Fact]
        public void AceitaApenasReiOuRainhaInimigosBoss()
        {
            InimigoFactory sut = new InimigoFactory();

            CreateInimigoException ex = Assert.Throws<CreateInimigoException>(() => sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedNomeInimigo);
        }
    }
}
