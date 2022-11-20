using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameEngine
{
    public class Jogador : INotifyPropertyChanged
    {
        private int _saude = 100;

        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string NomeCompleto => $"{PrimeiroNome} {SegundoNome}";
        public string Apelido { get; set; }
        public int Saude
        {
            get => _saude;
            set
            {
                _saude = value;
                OnPropertyChanged();
            }
        }
        public bool Iniciante { get; set; }
        public List<string> Armas { get; set; }

        public event EventHandler<EventArgs> JogadorDormiu;

        public Jogador()
        {
            PrimeiroNome = GerarPrimeiroNomeAleatorio();

            Iniciante = true;

            CriarArmasIniciais();
        }

        public void Dormir()
        {
            var saudeAumentada = CalcularSaudeAumentada();

            Saude += saudeAumentada;

            EnquantoJogadorEstiverDormindo(EventArgs.Empty);
        }

        private int CalcularSaudeAumentada()
        {
            var randon = new Random();

            return randon.Next(1, 101);
        }


        protected virtual void EnquantoJogadorEstiverDormindo(EventArgs e)
        {
            JogadorDormiu?.Invoke(this, e);
        }

        public void LevarDano(int dano)
        {
            Saude = Math.Max(1, Saude -= dano);
        }

        private string GerarPrimeiroNomeAleatorio()
        {
            var possivelNomeAleatorioInicial = new[]
            {
                "Danieth",
                "Derick",
                "Shalnorr",
                "G'Toth'lop",
                "Boldrakteethtop"
            };

            return possivelNomeAleatorioInicial[
                new Random().Next(0, possivelNomeAleatorioInicial.Length)];
        }

        private void CriarArmasIniciais()
        {
            Armas = new List<string>
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}