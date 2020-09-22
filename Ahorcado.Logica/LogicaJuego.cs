using Ahorcado.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado.Logica
{
    public class LogicaJuego
    {
        private Juego Juego;

        public LogicaJuego()
        {
            Juego = new Dominio.Juego();
        }

        public void IngresarPalabra(string v)
        {
            throw new NotImplementedException();
        }

        public bool ValidarPalabra()
        {
            return Juego.Palabra == "asadwerá";
        }
    }
}
