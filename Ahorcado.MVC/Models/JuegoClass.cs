﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahorcado.MVC.Models
{
    public class JuegoClass
    {
        public string PalabraAAdivinar;
        public string PalabraModeloActual; 
        public string Usuario = "John Cena";
        public string PalabraIngresada;
        public int Score { get; set; }
        public List<string> LetrasIngresadas = new List<string>();
        public int Vidas { get; set; }
        public bool estaVivo { get; set; }


    }
}