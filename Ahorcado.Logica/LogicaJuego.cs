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
            this.Juego.PalabraIngresada = v;
        }

        public int RetornarTamañodePalabra()
        {
            return this.Juego.Palabra.Length;
        }


        public bool ValidarPalabra()
        {
            return (this.Juego.PalabraIngresada == this.Juego.Palabra);
        }
    }
}
