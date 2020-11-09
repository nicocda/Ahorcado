using Ahorcado.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            LogicaJuego logica = new LogicaJuego();
            Console.WriteLine("Bienvenidos al programa de mierda que hicimos para el ahorcado :)");
            Console.WriteLine(ConsolaJuego.ComunicarPalabraTXT());
            //Console.WriteLine(logica.ComunicarTamPal());
            Console.WriteLine("Ingrese una letra");

            logica.IngresarLetra(Console.ReadLine());

            Console.ReadKey();

        }
    }
}
