using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado.Dominio
{
    public class Juego
    {

        //private String _PalabraAAdivinar;

        //[DisplayName("Palabra a adivinar")]
        //public String PalabraAAdivinar
        //{
        //    get { return _PalabraAAdivinar; }
        //    set { _PalabraAAdivinar = value; }
        //}

        //private String _PalabraModeloActual;

        //[DisplayName("Palabra actual")]
        //public String PalabraModeloActual
        //{
        //    get { return _PalabraModeloActual; }
        //    set { _PalabraModeloActual = value; }
        //}

        //private String _Usuario;

        //[DisplayName("Nombre usuario")]
        //public String Usuario
        //{
        //    get { return _Usuario; }
        //    set { _Usuario = value; }
        //}

        //private String _PalabraIngresada;

        //[DisplayName("Palbra Ingresada")]
        //public String PalabraIngresada
        //{
        //    get { return _PalabraIngresada; }
        //    set { _PalabraIngresada = value; }
        //}

        //private int _Score;



        //[DisplayName("Puntuacion")]
        //public int Score
        //{
        //    get { return _Score; }
        //    set { _Score = value; }
        //}

        //private List<string> _LetrasIngresadas;

        //[DisplayName("Letras Ingresadas")]
        //public List<string> LetrasIngresadas
        //{
        //    get { return _LetrasIngresadas; }
        //    set { _LetrasIngresadas = value; }
        //}

        //private int _Vidas;


        //[DisplayName("Vidas")]
        //public int Vidas
        //{
        //    get { return _Vidas; }
        //    set { _Vidas = value; }
        //}

        //private bool _estaVivo;


        //[DisplayName("¿Esta vivo amigo?")]
        //public bool estaVivo
        //{
        //    get { return _estaVivo; }
        //    set { _estaVivo = value; }
        //}

        public string PalabraAAdivinar = "asadwerá";
        public string PalabraModeloActual = "********";
        public string Usuario = "John Cena";
        public string PalabraIngresada;
        public int Score { get; set; }
        public List<string> LetrasIngresadas = new List<string>();
        public int Vidas { get; set; }
        public bool estaVivo { get; set; }


    }
}
