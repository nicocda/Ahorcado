using Ahorcado.Dominio;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Ahorcado.Logica
{
    public class LogicaJuego
    {
        public Juego Juego;

        public LogicaJuego()
        {
            Juego = new Juego();
            Juego.estaVivo = true; 
        }
        public void PalabraAAdivinar(string v)
        {
            Juego.PalabraAAdivinar=v;
        }

        public List<string> LetrasIngresadas()
        {
            return Juego.LetrasIngresadas;
        }
        public String PalabraIngresada()
        {
            return Juego.PalabraIngresada;
        }
        public void IngresarPalabra(string v)
        {
            this.Juego.PalabraIngresada = v;
            this.ValidarPalabra();
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
            if(this.Juego.PalabraIngresada == this.Juego.PalabraAAdivinar)
            {
                this.AumentarScoreFijo(2000);
                return (this.Juego.PalabraIngresada == this.Juego.PalabraAAdivinar);
            } else
            {
                this.RestarVidas();
                this.DisminuirScoreFijo(500);
                this.detectarMuerte();            
                return (this.Juego.PalabraIngresada == this.Juego.PalabraAAdivinar);
            }
            
        }

        public void IngresarLetra(string letra)
        {
            if (string.IsNullOrEmpty(letra))
                throw new ArgumentNullException("Ingrese una letra");
            if (letra.Length != 1)
                throw new ArgumentOutOfRangeException("La letra debe contener solo un caracter");
            var letrasIngresadas = this.LetrasIngresadas();
            if(letrasIngresadas == null || letrasIngresadas.Count() == 0)
            {
                //this.Juego.LetrasIngresadas.Add(letra);
                letrasIngresadas = new List<string>();
                letrasIngresadas.Add(letra);
            }
            else
            {
                if (letrasIngresadas.Contains(letra))
                {
                    this.DisminuirScore();
                    this.RestarVidas();
                    this.detectarMuerte();
                }
            }

            var cant = GetCantidadAparicionesEnPalabra(letra[0]);
            if (cant > 0)
            {
                this.AumentarScore(cant);
                ActualizarEstadoModelo(letra[0]);
            }
            else
            {
                this.DisminuirScore();
                this.RestarVidas();
                this.detectarMuerte();
            }
            this.Juego.LetrasIngresadas = letrasIngresadas;
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

                    indx = this.Juego.PalabraAAdivinar.IndexOf(letra, indx+1);
                }
            }
        }


        public int GetCantidadAparicionesEnPalabra(char letra)
        {
            return Regex.Matches(this.Juego.PalabraAAdivinar.ToLower(), letra.ToString().ToLower()).Count; 
        }

        public String ComunicarTamPal()
        {
            var frase = "Tamaño de palabra: " + this.GetTamañoPalabra().ToString()+" letras";
            return (frase);
        }

        public String ComunicarVictoria()
        {
            var frase = "Felicitaciones" + Juego.Usuario + "acertaste la palabra";
            return (frase);
        }
        public String ComunicarDerrota()
        {
            var frase = "Palabra Erronea, mejor suerte la proxima" + Juego.Usuario;
            return (frase);
        }

        public String ComunicarEstadoPalabra()
        {
            var frase = Juego.PalabraModeloActual;
            return (frase);
        }
        public List<string> LetrasQueNoEstan()
        {
            return (Juego.LetrasIngresadas.Where(c => !Juego.PalabraModeloActual.Contains(c)).ToList());
        }
        //-----------------Seccion de Scoring --------------------------//

        private void AumentarScore(int aciertos)
        {
            this.Juego.Score += 100*aciertos;
        }

        private void AumentarScoreFijo(int num)
        {
            this.Juego.Score += num;
        }

        private void DisminuirScoreFijo(int num)
        {
            if (this.Juego.Score - num > 0)
            {
                this.Juego.Score -= num;
            }
            else
            {
                this.Juego.Score = 0;
            }

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
            var score = Juego.Score;
            return score;
        }

        //--------------------------Seccion de vidas----------------------//


        public void detectarMuerte()
        {
            if(this.detectar0vidas())
            {
                this.Juego.estaVivo = false; 
            } 
        }

        public bool detectar0vidas()
        {
            if(this.Juego.Vidas == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCantidadDeVidas()
        {
            return this.Juego.Vidas; 
        }

        public void parametrizarVidas(int vidas) {
            this.Juego.Vidas = vidas;
        }

        public void RestarVidas() {
            getPalabraRandom();
            this.Juego.Vidas = this.Juego.Vidas - 1;
        }

        //public string ObtenerPalabraTXT()
        //{
        //    Dominio.Juego juego = new Juego();
        //    string usuario = juego.Usuario;
        //    int score = GetScore();
        //}

        /*public string getPalabraRandom()
        {
            var random = new Random();
            string filename = "animales.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Palabras\", filename);
            var logFile = File.ReadAllLines("C:\\Users\\ciber\\source\\repos\\Ahorcado\\Ahorcado.Logica\\Palabras\\animales.txt");
            var logList = new List<string>(logFile);
            int index = random.Next(logList.Count);
            return logList[index];
            
        }*/


        public void iniciarJuego()
        {
            this.IngresarPalbraEnJuego(getPalabraRandom());
            this.Juego.Score = 0;
            this.Juego.Vidas = 3;
        }

        public string getPalabraRandom()
        {
            var random = new Random();
            List<string> listOfAnimals = new List<string>()
            {
                "oso","gato","hormiga","mono","zorro","leopardo","cangrejo","aguila","ballena","castor",
                "perro","murcielago","abeja","castor","vaca","leon","tigre","lagarto","oveja","cerdo",
                "conejo"
            };
            int index = random.Next(listOfAnimals.Count);
            return listOfAnimals[index];
        }
    }
}
