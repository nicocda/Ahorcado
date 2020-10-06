using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado.Dominio
{
    public class Juego
    {
        public string Palabra = "asadwerá";
        public string Usuario = "John Cena";
        public string PalabraIngresada;
        public int Score;
        public List<string> LetrasIngresadas = new List<string>();
    }
}
