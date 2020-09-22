﻿using Ahorcado.Dominio;
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

        public bool ValidarPalabra()
        {
           if(this.Juego.PalabraIngresada == this.Juego.Palabra)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
