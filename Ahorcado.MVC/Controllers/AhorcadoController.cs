using Ahorcado.Logica;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ahorcado.MVC.Models;

namespace Ahorcado.MVC.Controllers
{
    public class AhorcadoController : Controller
    {


        public ActionResult AhorcadoView()
        {
            AhorcadoClass juego = new AhorcadoClass();
            juego.iniciarJuego();
            ViewBag.letrasIngresadas = "";
            return View(juego);
        }


        [HttpGet]
        public ActionResult siguienteRonda(int score)
        {
            AhorcadoClass juego = new AhorcadoClass();
            juego.iniciarJuego();
            juego.Juego.Score = score;
            ViewBag.letrasIngresadas = "";
            return View("AhorcadoView", juego);
        }

        [HttpPost]
        public ActionResult ArriesgarPalabra(string palAAdiv, int vidas, int scoreTot, string palabra, List<string> letIngresadas, string palModAct)
        {
            AhorcadoClass model;

            if (letIngresadas != null)
            {
                 model = new AhorcadoClass(palAAdiv, vidas, scoreTot, letIngresadas, palModAct);
            }
            else
            {
                 model = new AhorcadoClass(palAAdiv, vidas, scoreTot, palModAct);
            }

            string letras = "";

            model.IngresarPalabra(palabra);
            if (letIngresadas != null)
            {
                letras = string.Join(",", model.Juego.LetrasIngresadas.ToArray());
            }

            if (model.Juego.PalabraAAdivinar != palAAdiv)
            {
                model.Juego.PalabraAAdivinar = palAAdiv;
                return View("VictoriaView", model);
            }
            if(model.Juego.estaVivo == false)
            {
                return View("DerrotaView", model);
            } else
            {
                ViewBag.letrasIngresadas = letras;
                return View("AhorcadoView", model);
            }
        }

        [HttpPost]
        public ActionResult ArriesgarLetra(string palAAdiv, int vidas, int scoreTot, string letra, List<string> letIngresadas, string palModAct)
        {
            string letras = "";

            if (letIngresadas == null)
            {
                letIngresadas = new List<string>();
            }
            AhorcadoClass model = new AhorcadoClass(palAAdiv, vidas, scoreTot, letIngresadas, palModAct);
            model.IngresarLetra(letra);
            if (letIngresadas != null)
            {
                letras = string.Join(",", model.Juego.LetrasIngresadas.ToArray());
            }
            if (palAAdiv == model.Juego.PalabraModeloActual)
            {
                model.Juego.PalabraAAdivinar = palAAdiv;
                return View("VictoriaView", model);
            }
            else
            {
                if (model.Juego.estaVivo == false)
                {
                    return View("DerrotaView", model);
                }
                else
                {
                    ViewBag.letrasIngresadas = letras;
                    return View("AhorcadoView", model);
                }
            }
        }


        //[HttpGet]
        //public ActionResult _Derrota()
        //{
        //    VidaMuerteViewModel vm = new VidaMuerteViewModel();
        //    vm.Palabra = logica.Juego.PalabraAAdivinar;
        //    vm.Mensaje = "Lo siento, te quedaste sin vidas, mejor suerte la proxima";
        //    if(logica.Juego.Score > 0)
        //        return View("Error404");
        //    return View();
        //}
    }
}
