using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class BossShould
    {
        private readonly ITestOutputHelper output;

        public BossShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        [Trait("Categoria", "Boss")]
        public void HaveCorrectPower()
        {
            this.output.WriteLine("Criando um Boss!");

            Boss sut = new Boss();

            Assert.Equal(166.667, sut.AtaquePoderEspecialTotal, 3);
        }
    }
}
