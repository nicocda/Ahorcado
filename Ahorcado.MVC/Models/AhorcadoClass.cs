using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Ahorcado.Logica;

namespace Ahorcado.MVC.Models
{
    public class AhorcadoClass
    {
        public LogicaJuego logica;

        public AhorcadoClass()
        {
            this.logica = new LogicaJuego();
        }



    }
}