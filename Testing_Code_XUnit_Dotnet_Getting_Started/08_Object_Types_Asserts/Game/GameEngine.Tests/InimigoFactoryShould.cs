using System;
using Xunit;

namespace GameEngine.Tests
{
    public class InimigoFactoryShould
    {
        [Fact]
        public void CriaInimigoNormalPorPadrao()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo = sut.Create("Zombie");

            Assert.IsType<InimigoNormal>(inimigo);
        }

        [Fact]
        public void CriaInimigoNormalPorPadrao_TipoIncorreto()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo = sut.Create("Zombie");

            Assert.IsType<DateTime>(inimigo);
        }

        [Fact]
        public void CriaBoss()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo = sut.Create("Zombie King", true);

            Assert.IsType<Boss>(inimigo);
        }

        [Fact]
        public void CriaBoss_CastReturnedTypeExample()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo = sut.Create("Zombie King", true);

            // Faz o assert e pega o retorno do Cast
            Boss boss = Assert.IsType<Boss>(inimigo);

            // Assert adicional com o tipo do Objeto
            Assert.Equal("Zombie King", boss.Nome);
        }

        [Fact]
        public void CriaBoss_AssertTiposDerivados()
        {
            InimigoFactory sut = new InimigoFactory();

            Inimigo inimigo = sut.Create("Zombie King", true);

            //Assert.IsType<Inimigo>(inimigo);
            Assert.IsAssignableFrom<Inimigo>(inimigo);
        }
    }
}
