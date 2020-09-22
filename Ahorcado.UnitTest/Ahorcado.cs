using System;
using System.Linq;
using Ahorcado.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ahorcado.UnitTest
{
    [TestClass]
    public class Ahorcado
    {
        [TestMethod]
        public void Palabra_SinNumeros()
        {
            Juego juego = new Juego();

            bool contieneUnNumero = juego.Palabra.Any(char.IsDigit);
            Assert.IsTrue(contieneUnNumero);
        }

        [TestMethod]
        public void Palabra_CantidadLetras8()
        {
            Juego juego = new Juego();

            Assert.AreEqual(juego.Palabra.Length, 8);
        }
    }
}
