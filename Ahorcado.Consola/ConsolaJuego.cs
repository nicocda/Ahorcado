using Ahorcado.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado.Consola
{
    public static class ConsolaJuego
    {
        public static String ComunicarTamPal()
        {
            LogicaJuego logica = new LogicaJuego();
            var frase = "El tamaño de la palabra es " + logica.RetornarTamañodePalabra().ToString();
            Console.WriteLine(frase);
            return (frase);
        }

        public String ComunicarVictoria()
        {
            LogicaJuego logica = new LogicaJuego();
            var frase = "Victoria";
            Console.WriteLine(frase);
            return (frase);
        }

    }
}
