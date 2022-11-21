namespace GameEngine
{
    public abstract class Inimigo
    {
        public string Nome { get; set; }
        public abstract double PoderEspecialTotal { get; }
        public abstract double PoderEspecialUsado { get; }
        public double AtaquePoderEspecialTotal => PoderEspecialTotal / PoderEspecialUsado;
    }
}