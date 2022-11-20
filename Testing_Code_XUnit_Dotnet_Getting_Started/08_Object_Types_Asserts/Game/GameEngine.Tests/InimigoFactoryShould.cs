﻿using System;
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
    }
}