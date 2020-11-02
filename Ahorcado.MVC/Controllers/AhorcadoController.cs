using Ahorcado.Logica;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ahorcado.MVC.Models;

namespace Ahorcado.MVC.Controllers
{
    public class AhorcadoController : Controller
    {
        public static LogicaJuego LJuego { get; set; }

        // GET: Hangman
        public ActionResult AhorcadoView()
        {
            return View(new Ahorcado.MVC.Models.AhorcadoClass());
        }

        [HttpPost]
        public JsonResult InsertePalabraAAdivinar(Models.AhorcadoClass model)
        {
            //LJuego = new LogicaJuego();
            //LJuego.IngresarPalbraEnJuego(model.palabraAAdivinar);
            //model.ChancesLeft = Juego.ChancesRestantes;
            return Json(model);
        }


        //[HttpPost]
        //public JsonResult InsertWordToGuess(Models.Ahorcado model)
        //{
        //    LJuego = new LogicaJuego();
        //    LJuego.IngresarPalbraEnJuego(model.WordToGuess);
        //    //model.ChancesLeft = Juego.ChancesRestantes;
        //    return Json(model);
        //}

        //[HttpPost]
        //public JsonResult TryLetter(Models.Ahorcado model)
        //{
        //    LJuego.IngresarLetra(model.LetterTyped);
        //    model.Win = LJuego.ValidarPalabra();
        //    //model.ChancesLeft = LJuego.ChancesRestantes;
        //    model.WrongLetters = string.Empty;
        //    List<string> letrasErradas = LJuego.LetrasQueNoEstan();
        //    foreach (var wLetter in letrasErradas)
        //    {
        //        model.WrongLetters += wLetter + ",";
        //    }
        //    model.GuessingWord = string.Empty;
        //    string pal=LJuego.PalabraIngresada();
        //    char[] palabra = pal.ToArray();
        //    foreach (var rLetter in palabra)
        //    {
        //        model.GuessingWord += rLetter + " ";
        //    }
        //    model.LetterTyped = string.Empty;
        //    return Json(model);


        [HttpGet]
        public ActionResult _Victoria()
        {
            VidaMuerteViewModel vm = new VidaMuerteViewModel();
            vm.Palabra = LJuego.Juego.PalabraAAdivinar;
            vm.Score = LJuego.Juego.Score;
            vm.Mensaje = "Felicitaciones Campepeón!!";
            return View();
        }


        [HttpGet]
        public ActionResult _Derrota()
        {
            VidaMuerteViewModel vm = new VidaMuerteViewModel();
            vm.Palabra = LJuego.Juego.PalabraAAdivinar;
            vm.Mensaje = "Lo siento, te quedaste sin vidas, mejor suerte la proxima";
            if(LJuego.Juego.Score > 0)
                return View("Error404");
            return View();
        }
    }
}
