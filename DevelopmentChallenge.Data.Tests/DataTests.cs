using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<IForma>(), Lenguaje.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<IForma>(), Lenguaje.Ingles));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrado = new List<IForma> {new Cuadrado(5)};

            var resumen = FormaGeometrica.Imprimir(cuadrado, Lenguaje.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IForma>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Lenguaje.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IForma>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75),
                new TrianguloEquilatero(4.2),
            };

            var resumen = FormaGeometrica.Imprimir(formas, Lenguaje.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 52,03 | Perimeter 36,13 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 115,73 Area 130,67",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IForma>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75),
                new TrianguloEquilatero(4.2),
            };

            var resumen = FormaGeometrica.Imprimir(formas, Lenguaje.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perímetro 28 <br/>2 Círculos | Area 52,03 | Perímetro 36,13 <br/>3 Triángulos | Area 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 115,73 Area 130,67",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<IForma>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75),
                new TrianguloEquilatero(4.2),
            };

            var resumen = FormaGeometrica.Imprimir(formas, Lenguaje.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto delle forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 52,03 | Perimetro 36,13 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 forme Perimetro 115,73 Area 130,67",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioEnIngles()
        {
            var trapecio = new List<IForma> { new TrapecioRectangulo(2, 6, 3, 10) };

            var resumen = FormaGeometrica.Imprimir(trapecio, Lenguaje.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>1 Trapezium | Area 40 | Perimeter 21 <br/>TOTAL:<br/>1 shapes Perimeter 21 Area 40", resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapeciosEnItaliano()
        {
            var formas = new List<IForma>
            {
                new TrapecioRectangulo(5, 3, 2, 3),
                new TrapecioRectangulo(2, 6, 3, 10)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Lenguaje.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto delle forme</h1>2 Trapezi | Area 52 | Perimetro 34 <br/>TOTAL:<br/>2 forme Perimetro 34 Area 52",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTodosLosTiposEnCastellano()
        {
            var formas = new List<IForma>
            {
                new Cuadrado(5),
                new Circulo(2.75),
                new TrianguloEquilatero(9),
                new TrapecioRectangulo(2, 6, 3, 10)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Lenguaje.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perímetro 20 <br/>1 Círculo | Area 23,76 | Perímetro 17,28 <br/>1 Triángulo | Area 35,07 | Perímetro 27 <br/>1 Trapecio | Area 40 | Perímetro 21 <br/>TOTAL:<br/>4 formas Perímetro 85,28 Area 123,83",
                resumen);
        }

        [TestCase]
        public void TestImpresionConErrorEnIngles()
        {
            var formas = new List<IForma>
            {
                new Cuadrado(5),
                new Circulo(2.75),
                new TrianguloEquilatero(9),
                new TrapecioRectangulo(2, 6, 3, 10),
                null
            };

            var ex = Assert.Throws<Exception>(() => FormaGeometrica.Imprimir(formas, Lenguaje.Ingles));
            Assert.AreEqual("Error while printing | Object reference not set to an instance of an object.", ex.Message);

        }

        [TestCase]
        public void TestImpresionConErrorEnItaliano()
        {
            var formas = new List<IForma>
            {
                new Cuadrado(5),
                null
            };

            var ex = Assert.Throws<Exception>(() => FormaGeometrica.Imprimir(formas, Lenguaje.Italiano));
            Assert.AreEqual("Errore di stampa | Object reference not set to an instance of an object.", ex.Message);

        }
    }
}
