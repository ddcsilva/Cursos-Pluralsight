using Xunit.Abstractions;
using Xunit;

namespace GameEngine.Tests
{
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture gameStateFixture;
        private readonly ITestOutputHelper output;

        public GameStateShould(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            this.gameStateFixture = gameStateFixture;

            this.output = output;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            output.WriteLine($"GameState ID = {gameStateFixture.State.Id}");

            var jogador1 = new Jogador();
            var jogador2 = new Jogador();

            gameStateFixture.State.Jogadores.Add(jogador1);
            gameStateFixture.State.Jogadores.Add(jogador2);

            var saudeAposTerremoto = jogador1.Saude - GameState.DanoTerremoto;

            gameStateFixture.State.Earthquake();

            Assert.Equal(saudeAposTerremoto, jogador1.Saude);
            Assert.Equal(saudeAposTerremoto, jogador2.Saude);
        }

        [Fact]
        public void Reset()
        {
            output.WriteLine($"GameState ID = {gameStateFixture.State.Id}");

            var jogador1 = new Jogador();
            var jogador2 = new Jogador();

            gameStateFixture.State.Jogadores.Add(jogador1);
            gameStateFixture.State.Jogadores.Add(jogador2);

            gameStateFixture.State.Reset();

            Assert.Empty(gameStateFixture.State.Jogadores);
        }
    }
}
