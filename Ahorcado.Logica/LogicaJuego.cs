using Ahorcado.Dominio;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

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


            var cant = GetCantidadAparicionesEnPalabra(letra[0]);
            if (cant > 0)
            {
                this.AumentarScore(cant);
                ActualizarEstadoModelo(letra[0]);
            }
            else
                this.DisminuirScore();

        }

        public void ActualizarEstadoModelo(char letra)
        {
            if(GetCantidadAparicionesEnPalabra(letra) > 0)
            {
                int indx = this.Juego.PalabraAAdivinar.IndexOf(letra);
                while (indx >= 0){
                    StringBuilder sb = new StringBuilder(this.Juego.PalabraModeloActual);
                    sb[indx] = letra;
                    this.Juego.PalabraModeloActual = sb.ToString();

                    indx = this.Juego.PalabraAAdivinar.IndexOf(letra, indx);
                }
            }
        }


        public int GetCantidadAparicionesEnPalabra(char letra)
        {

            return Regex.Matches(this.Juego.PalabraAAdivinar.ToLower(), letra.ToString().ToLower()).Count; 
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
        public List<string> LetrasQueNoEstan()
        {
            Dominio.Juego juego = new Dominio.Juego();
            return (juego.LetrasIngresadas.Where(c => !juego.PalabraModeloActual.Contains(c)).ToList());
        }
        //-----------------Seccion de Scoring --------------------------//

        private void AumentarScore(int aciertos)
        {
            this.Juego.Score += 100*aciertos;
        }

        private void DisminuirScore()
        {
            if(this.Juego.Score > 50)
            {
                this.Juego.Score -= 50;
            } 
            else 
            {
                this.Juego.Score = 0;
            }
            
        }

        public int GetScore()
        {
            Dominio.Juego juego = new Dominio.Juego();
            var score = juego.Score;
            return score;
        }




    }
}
