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

            if (this.Juego.LetrasIngresadas.Contains(letra))
                throw new ArgumentException("La letra ingresada ya existe");

            this.Juego.LetrasIngresadas.Add(letra);
        }

        public bool PertenecePalabra(string letra)
        {
            return this.Juego.Palabra.Contains(letra);
        }

        public int cantLetEnPal(char letra)
        {
            return Regex.Matches(this.Juego.Palabra, letra.ToString()).Count; 
        }

        public String ComunicarTamPal()
        {
            var frase = "El tamaño de la palabra es " + this.RetornarTamañodePalabra().ToString();
            return (frase);
        }

        public String ComunicarVictoria()
        {
            Dominio.Juego juego = new Dominio.Juego();
            var frase = "Felicitaciones" + juego.Usuario + "acertaste la palabra";
            return (frase);
        }
        public String ComunicarDerrota()
        {
            Dominio.Juego juego = new Dominio.Juego();
            var frase = "Palabra Erronea, mejor suerte la proxima" + juego.Usuario;
            return (frase);
        }
        public String ComunicarEstadoPalabra()
        {
            Dominio.Juego juego = new Dominio.Juego();
            var frase = "Palabra Erronea, mejor suerte la proxima" + juego.Usuario;
            return (frase);
        }
    }
}
