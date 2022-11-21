using Xunit;

namespace GameEngine.Tests
{
    public class BossShould
    {
        [Fact]
        [Trait("Categoria", "Boss")]
        public void HaveCorrectPower()
        {
            Boss sut = new Boss();

            Assert.Equal(166.667, sut.AtaquePoderEspecialTotal, 3);
        }
    }
}
