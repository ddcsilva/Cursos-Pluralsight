using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class GameState
    {
        public static readonly int DanoTerremoto = 25;
        public List<Jogador> Jogadores { get; set; } = new List<Jogador>();
        public Guid Id { get; } = Guid.NewGuid();

        public GameState()
        {
            CriarJogo();
        }        

        public void Earthquake()
        {
            foreach (var jogador in Jogadores)
            {
                jogador.LevarDano(DanoTerremoto);
            }
        }

        public void Reset()
        {
            Jogadores.Clear();
        }

        private void CriarJogo()
        {
            System.Threading.Thread.Sleep(2000);
        }
    }
}
