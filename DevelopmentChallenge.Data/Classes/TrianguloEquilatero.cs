using DevelopmentChallenge.Data.Attributes;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    [TipoForma("Triangulo")]
    public class TrianguloEquilatero : IForma
    {
        double Lado { get; set; }

        public TrianguloEquilatero(double lado)
        {
            Lado = lado;
        }

        public double CalcularArea()
        {
            return (Math.Sqrt(3) / 4) * Math.Pow(Lado, 2);
        }

        public double CalcularPerimetro()
        {
            return Lado * 3;
        }
    }
}
