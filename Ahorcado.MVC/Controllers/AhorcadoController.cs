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

        public string InsertePalabraAAdivinar(string palabra)
        {

            logica.IngresarPalbraEnJuego(palabra);
            return logica.Juego.PalabraAAdivinar;
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
    }
}
