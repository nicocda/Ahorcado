﻿using System;
using System.Linq;
using Ahorcado.Dominio;
using Ahorcado.Logica;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ahorcado.UnitTest
{
    [TestClass]
    public class Ahorcado
    {
        [TestMethod]
        public void Palabra_SinNumeros()
        {
            Dominio.Juego juego = new Dominio.Juego();

            bool contieneUnNumero = !juego.Palabra.Any(char.IsDigit);
            Assert.IsTrue(contieneUnNumero);
        }

        [TestMethod]
        public void Palabra_CantidadLetras8()
        {
            Dominio.Juego juego = new Dominio.Juego();

            Assert.AreEqual(juego.Palabra.Length, 8);
        }

        [TestMethod]
        public void Palabra_SinSimbolosRaros()
        {
            Dominio.Juego juego = new Dominio.Juego();

            bool todasLetras = juego.Palabra.All(char.IsLetter);
            Assert.IsTrue(todasLetras);
        }

        [TestMethod]
        public void Palabra_SinEspacios()
        {
            Dominio.Juego juego = new Dominio.Juego();

            bool conieneEspacios = juego.Palabra.Any(c=> c.Equals(" "));
            Assert.IsFalse(conieneEspacios);
        }



        [TestMethod]
        public void Usuario_NoNull()
        {
            Dominio.Juego juego = new Dominio.Juego();

            Assert.IsNotNull(juego.Usuario);
        }

        [TestMethod]
        public void Usuario_NoVacio()
        {
            Dominio.Juego juego = new Dominio.Juego();
            Assert.IsFalse(string.IsNullOrEmpty(juego.Usuario));
        }

        [TestMethod]
        public void Probar_Palabra_IngresadaIsLetter()
        {
            Dominio.Juego juego = new Dominio.Juego();
            juego.PalabraIngresada = "PalabraPorTeclado";
            bool todasLetras = juego.PalabraIngresada.All(char.IsLetter);
            Assert.IsTrue(todasLetras);
        }

        [TestMethod]
        public void PalbraIngresada_hasNotSpace()
        {
            Dominio.Juego juego = new Dominio.Juego();
            juego.PalabraIngresada = "PalabraPorTeclado";
            bool todasLetras = juego.PalabraIngresada.Contains(" ");
            Assert.IsFalse(todasLetras);
        }


        [TestMethod]
        public void Probar_Palabra_Ingresada()
        {
            LogicaJuego logica = new LogicaJuego();
            logica.IngresarPalabra("asadwerá");
            bool palabraEsIgual = logica.ValidarPalabra();
            Assert.IsTrue(palabraEsIgual);
        }

        [TestMethod]
        public void Probar_Palabra_Ingresada_Sea_Igual()
        {
            var logica = new LogicaJuego();
            logica.IngresarPalabra("asadwerá");
            bool palabraEsIgual = logica.ValidarPalabra();
            Assert.IsTrue(palabraEsIgual);
        }

        [TestMethod]
        public void Ingresar_Una_Letra_Inexistente()
        {
            var logica = new LogicaJuego();
            logica.IngresarLetra("p");

            
            Assert.IsTrue(logica.Juego.Letras.Contains("p"));
        }

        [TestMethod]
        public void Ingresar_Un_Simbolo()
        {
            var logica = new LogicaJuego();
            logica.IngresarLetra("_");
            Assert.IsTrue(logica.Juego.Letras.Contains("_"));
        }


        [TestMethod]
        public void Ingresar_Una_Letra_Existente()
        {
            var logica = new LogicaJuego();
            logica.IngresarLetra("a");
            Assert.IsTrue(logica.Juego.Letras.Contains("a"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ingresar_Varias_Letras()
        {
            var logica = new LogicaJuego();
            logica.IngresarLetra("aasd");
            Assert.IsFalse(logica.Juego.Letras.Contains("aasd"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ingresar_Letra_Null()
        {
            var logica = new LogicaJuego();
            logica.IngresarLetra(null);
            Assert.IsFalse(logica.Juego.Letras.Contains(null));
        }


        [TestMethod]
        public void retornar_tamaño_palabra()
        {
            var logica = new LogicaJuego();
            Assert.AreEqual(logica.Juego.Palabra.Length, logica.RetornarTamañodePalabra());
        }

        [TestMethod]
        public void retornar_tamaño_palabra_es_Numero()
        {
            var logica = new LogicaJuego();
            var num = logica.RetornarTamañodePalabra();
            var tipo = num.GetType();
            Assert.IsTrue(tipo.Equals(typeof(int)));
        }


        [TestMethod]
        public void IngresarPalabra()
        {
            var logica = new LogicaJuego();
            var pal = "Hornitorrinco";
            logica.IngresarPalbraEnJuego(pal);
            Assert.AreEqual(pal, logica.Juego.Palabra);
        }



    }
}
