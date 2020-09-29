using Ahorcado.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

        public int RetornarTamañodePalabra()
        {
            return this.Juego.Palabra.Length;
        }

        public void IngresarPalbraEnJuego(string pal)
        {
            this.Juego.Palabra = pal;
        }


        public bool ValidarPalabra()
        {
            return (this.Juego.PalabraIngresada == this.Juego.Palabra);
        }

        public void IngresarLetra(string letra)
        {
            if (string.IsNullOrEmpty(letra))
                throw new ArgumentNullException("Ingrese una letra");
            if (letra.Length != 1)
                throw new ArgumentOutOfRangeException("La letra debe contener solo un caracter");

            if (this.Juego.Letras.Contains(letra))
                throw new ArgumentException("La letra ingresada ya existe");

            this.Juego.Letras.Add(letra);
        }

        public int cantLetEnPal(char letra)
        {
            return Regex.Matches(this.Juego.Palabra, letra.ToString()).Count; 
        }

    }
}
