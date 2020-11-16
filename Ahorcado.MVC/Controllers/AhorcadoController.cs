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
            AhorcadoClass model = new AhorcadoClass();
            juego.logica.iniciarJuego();
            return View(juego);
        }

        public AhorcadoClass ArriesgarPalabra(string palAdiv, int score, int vidas, string pal)
        {
            AhorcadoClass treta = new AhorcadoClass();
            treta.logica.IngresarPalbraEnJuego(palAdiv);
            treta.logica.Juego.Score = score;
            treta.logica.Juego.Vidas = vidas;
            treta.logica.IngresarPalabra(pal);
            return treta;
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
