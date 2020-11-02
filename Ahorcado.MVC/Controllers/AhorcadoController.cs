using Ahorcado.Logica;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ahorcado.MVC.Models;

namespace Ahorcado.MVC.Controllers
{
    public class AhorcadoController : Controller
    {
        LogicaJuego logica = new LogicaJuego();

        public ActionResult AhorcadoView()
        {
            AhorcadoClass model = new AhorcadoClass();
            return View(model);
        }

        public ActionResult InsertePalabraAAdivinar(string palabra)
        {

            logica.IngresarPalbraEnJuego(palabra);
            AhorcadoClass model = new AhorcadoClass();
            model.PalabraModeloActual = logica.Juego.PalabraModeloActual;
            model.Score = logica.Juego.Score;
            model.Vidas = logica.Juego.Vidas;
            model.PalabraAAdivinar = logica.Juego.PalabraAAdivinar;

            return View("AhorcadoView", model);
        }



        [HttpGet]
        public ActionResult _Victoria()
        {
            VidaMuerteViewModel vm = new VidaMuerteViewModel();
            vm.Palabra = logica.Juego.PalabraAAdivinar;
            vm.Score = logica.Juego.Score;
            vm.Mensaje = "Felicitaciones Campepeón!!";
            return View();
        }


        [HttpGet]
        public ActionResult _Derrota()
        {
            VidaMuerteViewModel vm = new VidaMuerteViewModel();
            vm.Palabra = logica.Juego.PalabraAAdivinar;
            vm.Mensaje = "Lo siento, te quedaste sin vidas, mejor suerte la proxima";
            if(logica.Juego.Score > 0)
                return View("Error404");
            return View();
        }
    }
}
