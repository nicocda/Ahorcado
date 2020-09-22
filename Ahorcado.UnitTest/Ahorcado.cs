using System;
using Ahorcado.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ahorcado.UnitTest
{
    [TestClass]
    public class Ahorcado
    {
        [TestMethod]
        public void Palabra_CantidadLetras8()
        {
            Juego juego = new Juego();

            Assert.AreEqual(juego.Palabra.Length, 8);
        }
    }
}
