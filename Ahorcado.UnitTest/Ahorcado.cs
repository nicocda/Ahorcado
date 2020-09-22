﻿using System;
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

            bool contieneUnNumero = !juego.Palabra.Any(char.IsDigit);
            Assert.IsTrue(contieneUnNumero);
        }

        [TestMethod]
        public void Palabra_CantidadLetras8()
        {
            Juego juego = new Juego();

            Assert.AreEqual(juego.Palabra.Length, 8);
        }

        [TestMethod]
        public void Palabra_SinSimbolosRaros()
        {
            Juego juego = new Juego();

            bool todasLetras = juego.Palabra.All(char.IsLetter);
            Assert.IsTrue(todasLetras);
        }

        [TestMethod]
        public void Palabra_SinEspacios()
        {
            Juego juego = new Juego();

            bool conieneEspacios = juego.Palabra.Any(c=> c.Equals(" "));
            Assert.IsFalse(conieneEspacios);
        }



        [TestMethod]
        public void Usuario_NoNull()
        {
            Juego juego = new Juego();

            Assert.IsNotNull(juego.Usuario);
        }

        [TestMethod]
        public void Usuario_NoVacio()
        {
            Juego juego = new Juego();
            Assert.IsFalse(string.IsNullOrEmpty(juego.Usuario));
        }

        [TestMethod]
        public void Probar_Palabra_IngresadaIsLetter()
        {
            Juego juego = new Juego();
            juego.PalabraIngresada = "PalabraPorTeclado";
            bool todasLetras = juego.PalabraIngresada.All(char.IsLetter);
            Assert.IsTrue(todasLetras);
        }

        [TestMethod]
        public void PalbraIngresada_hasNotSpace()
        {
            Juego juego = new Juego();
            juego.PalabraIngresada = "PalabraPorTeclado";
            bool todasLetras = juego.PalabraIngresada.Contains(" ");
            Assert.IsFalse(todasLetras);
        }


        [TestMethod]
        public void Probar_Palabra_Ingresada()
        {
            Logica logica = new Logica();
            logica.IngresarPalabra("asadwerá");
            bool palabraEsIgual = logica.ValidarPalabra();
            Assert.IsTrue(palabraEsIgual);
        }

    }
}
