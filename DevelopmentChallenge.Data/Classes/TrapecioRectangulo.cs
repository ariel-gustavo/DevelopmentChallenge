using DevelopmentChallenge.Data.Attributes;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    [TipoForma("Trapecio")]
    public class TrapecioRectangulo : IForma
    {
        double LadoBaseA { get; set; }
        double LadoBaseB { get; set; }
        double Cateto { get; set; }
        double Altura { get; set; }

        public TrapecioRectangulo(double ladoBaseA, double ladoBaseB, double cateto, double altura)
        {
            LadoBaseA = ladoBaseA;
            LadoBaseB = ladoBaseB;
            Cateto = cateto;
            Altura = altura;
        }

        public double CalcularArea()
        {
            return ((LadoBaseA + LadoBaseB) * Altura) / 2;
        }

        public double CalcularPerimetro()
        {
            return LadoBaseA + LadoBaseB + Cateto + Altura;
        }
    }
}
