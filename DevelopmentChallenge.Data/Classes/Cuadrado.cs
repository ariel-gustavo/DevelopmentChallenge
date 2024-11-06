using DevelopmentChallenge.Data.Attributes;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    [TipoForma("Cuadrado")]
    public class Cuadrado : IForma
    {
        double Lado { get; set; }

        public Cuadrado(double lado)
        {
            Lado = lado;
        }

        public double CalcularArea()
        {
            return Math.Pow(Lado, 2);
        }

        public double CalcularPerimetro()
        {
            return Lado * 4;
        }
    }
}
