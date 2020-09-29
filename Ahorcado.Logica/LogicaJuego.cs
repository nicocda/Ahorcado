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
        public Juego Juego;

        public LogicaJuego()
        {
            Juego = new Dominio.Juego();
        }

        public void IngresarPalabra(string v)
        {
            this.Juego.PalabraIngresada = v;
        }

        public bool ValidarPalabra()
        {
            return (this.Juego.PalabraIngresada == this.Juego.Palabra);
        }

        public void IngresarLetra(string letra)
        {
            if (letra == null)
                throw new ArgumentException();
            if (letra.Length != 1)
                throw new ArgumentOutOfRangeException();

            this.Juego.Letras.Add(letra);
        }
    }
}
