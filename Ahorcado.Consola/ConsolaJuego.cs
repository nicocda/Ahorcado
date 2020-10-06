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
            var frase = "El tamaño de la palabra es " + logica.GetTamañoPalabra().ToString();
            Console.WriteLine(frase);
            return (frase);
        }

        public static String ComunicarVictoria()
        {
            LogicaJuego logica = new LogicaJuego();
            var frase = logica.ComunicarVictoria();
            Console.WriteLine(frase);
            return (frase);
        }
        public static String ComunicarDerrota()
        {
            LogicaJuego logica = new LogicaJuego();
            var frase = logica.ComunicarDerrota();
            Console.WriteLine(frase);
            return (frase);
        }
        public static String ComunicarEstadoPalabra()
        {
            LogicaJuego logica = new LogicaJuego();
            var pal = logica.ComunicarEstadoPalabra();
            Console.WriteLine(pal);
            return (pal);
        }
    }
}
