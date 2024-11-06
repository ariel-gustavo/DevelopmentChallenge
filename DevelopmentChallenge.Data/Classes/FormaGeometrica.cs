/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Attributes;
using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {

        public static string Imprimir(List<IForma> formas, Lenguaje lenguaje)
        {
            var languageManager = new LanguageManager();

            try
            {
                
                languageManager.SetLanguage(lenguaje);

                var sb = new StringBuilder();

                if (!formas.Any())
                {
                    sb.Append($"<h1>{languageManager.GetString("ListaVacia")}</h1>");
                }
                else
                {
                    // Hay por lo menos una forma
                    // HEADER
                    sb.Append($"<h1>{languageManager.GetString("Header")}</h1>");

                    double sumaAreas = 0;
                    double sumaPerimetros = 0;

                    double sumaAreasTotal = 0;
                    double sumaPerimetrosTotal = 0;

                    double cantidadFormasTotal = 0;

                    var cantidadPorTipo = formas.GroupBy(forma => ObtenerTipoForma(forma))
                                            .Select(group => new
                                            {
                                                Tipo = group.Key,
                                                Cantidad = group.Count()
                                            });

                    foreach (var grupo in cantidadPorTipo)
                    {
                        sumaAreas = 0;
                        sumaPerimetros = 0;

                        foreach (var forma in formas.Where(f => ObtenerTipoForma(f) == grupo.Tipo))
                        {
                            sumaAreas += forma.CalcularArea();
                            sumaPerimetros += forma.CalcularPerimetro();
                        }

                        cantidadFormasTotal += grupo.Cantidad;
                        sumaAreasTotal += sumaAreas;
                        sumaPerimetrosTotal += sumaPerimetros;

                        var nombreTipo = languageManager.GetString(grupo.Tipo, grupo.Cantidad > 1);

                        sb.Append($"{grupo.Cantidad} {nombreTipo} | {languageManager.GetString("Area")} {sumaAreas.ToString("#.##")} | {languageManager.GetString("Perimetro")} {sumaPerimetros.ToString("#.##")} <br/>");
                    }

                    // FOOTER
                    sb.Append($"{languageManager.GetString("Total")}:<br/>");
                    sb.Append(cantidadFormasTotal + $" {languageManager.GetString("Formas")} ");
                    sb.Append($"{languageManager.GetString("Perimetro")} {sumaPerimetrosTotal.ToString("#.##")} ");
                    sb.Append($"{languageManager.GetString("Area")} {sumaAreasTotal.ToString("#.##")}");
                }

                return sb.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception($"{languageManager.GetString("Error")} | {ex.Message}");
            }
        }

        private static string ObtenerTipoForma(IForma forma)
        {
            var attribute = forma.GetType().GetCustomAttribute<TipoFormaAttribute>();
            return attribute?.TipoForma;
        }
    }
}