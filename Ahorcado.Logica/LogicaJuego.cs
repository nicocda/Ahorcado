using Ahorcado.Dominio;
using System;
using System.Text.RegularExpressions;

namespace Ahorcado.Logica
{
    public class LogicaJuego
    {
        public Juego Juego;

        public LogicaJuego()
        {
            Juego = new Juego();
        }


        public void IngresarPalabra(string v)
        {
            this.Juego.PalabraIngresada = v;
        }

        public int GetTamañoPalabra()
        {
            return this.Juego.PalabraAAdivinar.Length;
        }

        public void IngresarPalbraEnJuego(string pal)
        {
            this.Juego.PalabraAAdivinar = pal;
            this.Juego.PalabraModeloActual = "";
            for (int i = 0; i < this.GetTamañoPalabra(); i++)
            {
                this.Juego.PalabraModeloActual += "*";
            }
        }

        public bool ValidarPalabra()
        {
            return (this.Juego.PalabraIngresada == this.Juego.PalabraAAdivinar);
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

        public int cantLetEnPal(char letra)
        {
            return Regex.Matches(this.Juego.PalabraAAdivinar, letra.ToString()).Count; 
        }

        public String ComunicarTamPal()
        {
            var frase = "El tamaño de la palabra es " + this.GetTamañoPalabra().ToString();
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
            var frase = juego.PalabraModeloActual;
            return (frase);
        }

        //-----------------Seccion de Scoring --------------------------//

        public void AumentarScore(int aciertos)
        {
            this.Juego.Score += 100*aciertos;
        }

        public void DisminuirScore()
        {
            this.Juego.Score -= 50;
        }

    }
}
