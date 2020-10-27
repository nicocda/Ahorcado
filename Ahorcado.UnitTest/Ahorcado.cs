using System;
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

            bool contieneUnNumero = !juego.PalabraAAdivinar.Any(char.IsDigit);
            Assert.IsTrue(contieneUnNumero);
        }

        [TestMethod]
        public void Palabra_CantidadLetras8()
        {
            Dominio.Juego juego = new Dominio.Juego();

            Assert.AreEqual(juego.PalabraAAdivinar.Length, 8);
        }

        [TestMethod]
        public void Palabra_SinSimbolosRaros()
        {
            Dominio.Juego juego = new Dominio.Juego();

            bool todasLetras = juego.PalabraAAdivinar.All(char.IsLetter);
            Assert.IsTrue(todasLetras);
        }

        [TestMethod]
        public void Palabra_SinEspacios()
        {
            Dominio.Juego juego = new Dominio.Juego();

            bool conieneEspacios = juego.PalabraAAdivinar.Any(c=> c.Equals(" "));
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
        public void Ingresar_Una_Letra_Que_No_Forme_Parte_De_La_Palabra()
        {
            var logica = new LogicaJuego();
            logica.IngresarLetra("p");
            
            //Hacerlo en dos test
            //Hacer test muy simples y muchos
            Assert.IsTrue(logica.Juego.LetrasIngresadas.Contains("p"));
            //Assert.IsFalse(logica.PertenecePalabra("p"));
               
        }

        [TestMethod]
        public void Ingresar_Un_Simbolo()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.IngresarPalbraEnJuego("Palabra");

            //Act
            logica.IngresarLetra("_");

            //Assert
            Assert.IsTrue(logica.Juego.LetrasIngresadas.Contains("_"));
            //Assert.IsFalse(logica.PertenecePalabra("_"));
        }

        [TestMethod]
        public void Ingresar_Una_Letra_Existente()
        {
            var logica = new LogicaJuego();
            logica.IngresarPalabra("asawedá");
            logica.IngresarLetra("a");
            //Assert.IsTrue(logica.Juego.LetrasIngresadas.Contains("a"));
            Assert.IsTrue(logica.GetCantidadAparicionesEnPalabra('a') > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ingresar_Varias_Letras()
        {
            var logica = new LogicaJuego();
            logica.IngresarLetra("aasd");
            Assert.IsFalse(logica.Juego.LetrasIngresadas.Contains("aasd"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ingresar_Letra_Null()
        {
            var logica = new LogicaJuego();
            logica.IngresarLetra(null);
            Assert.IsFalse(logica.Juego.LetrasIngresadas.Contains(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ingresar_Letra_Empty()
        {
            var logica = new LogicaJuego();
            logica.IngresarLetra("");
            Assert.IsFalse(logica.Juego.LetrasIngresadas.Contains(""));
        }

        [TestMethod]
        public void retornar_tamaño_palabra()
        {
            var logica = new LogicaJuego();
            Assert.AreEqual(logica.Juego.PalabraAAdivinar.Length, logica.GetTamañoPalabra());
        }

        [TestMethod]
        public void retornar_tamaño_palabra_es_Numero()
        {
            var logica = new LogicaJuego();
            var num = logica.GetTamañoPalabra();
            var tipo = num.GetType();
            Assert.IsTrue(tipo.Equals(typeof(int)));
        }

        [TestMethod]
        public void VictoriaNotificada()
        {
            Dominio.Juego juego = new Dominio.Juego();
            var logica = new LogicaJuego();
            var esperado = "Felicitaciones" + juego.Usuario + "acertaste la palabra";
            var pal = logica.ComunicarVictoria();
            Assert.AreEqual(esperado, pal);
        }
        [TestMethod]
        public void DerrotaNotificada()
        {
            Dominio.Juego juego = new Dominio.Juego();
            var logica = new LogicaJuego();
            var esperado = "Palabra Erronea, mejor suerte la proxima" + juego.Usuario;
            var pal = logica.ComunicarDerrota();
            Assert.AreEqual(esperado, pal);
        }
        [TestMethod]
        public void EstadoPalabra()
        {
            Dominio.Juego juego = new Dominio.Juego();
            var logica = new LogicaJuego();
            var esperado = juego.PalabraModeloActual;
            var pal = logica.ComunicarEstadoPalabra();
            Assert.AreEqual(esperado, pal);
        }
        [TestMethod]
        public void EstadoPalabraLetrasErroneas()
        {
            Dominio.Juego juego = new Dominio.Juego();
            var logica = new LogicaJuego();
            var esperado = juego.PalabraModeloActual;
            var pal = logica.ComunicarEstadoPalabra();
            Assert.AreEqual(esperado, pal);
        }
        public void ComunicarLetrasErroneas()
        {
            Dominio.Juego juego = new Dominio.Juego();
            var logica = new LogicaJuego();
            var esperado = juego.LetrasIngresadas.Where(c => !juego.PalabraModeloActual.Contains(c)).ToList();
            var pal = logica.LetrasQueNoEstan();
            Assert.AreEqual(esperado, pal);
        }
        [TestMethod]
        public void MostrarConsolaPorPalabra()
        {
            var logica = new LogicaJuego();
            var esperado = "El tamaño de la palabra es 8";
            var pal = logica.ComunicarTamPal();
            Assert.AreEqual(esperado, pal);
        }


        [TestMethod]
        public void IngresarPalabra()
        {
            var logica = new LogicaJuego();
            var pal = "Ornitorrinco";
            logica.IngresarPalbraEnJuego(pal);
            Assert.AreEqual(pal, logica.Juego.PalabraAAdivinar);
        }

        [TestMethod]
        public void ComprobarVecesQueApareceLetra()
        {
            var logica = new LogicaJuego();
            var pal = "Ornitorrinco";
            logica.IngresarPalbraEnJuego(pal);
            Assert.AreEqual(3, logica.GetCantidadAparicionesEnPalabra('o'));
        }

        [TestMethod]
        public void Comparar()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.IngresarPalbraEnJuego("ornitorrinco");
            
            
            //Act
            logica.IngresarLetra("o");

            //Assert
            Assert.AreEqual("o****o*****o", logica.Juego.PalabraModeloActual);
        }


        [TestMethod]
        public void ProbarPalabraErronea()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.IngresarPalbraEnJuego("ornitorrinco");
            logica.IngresarPalabra("Pato");
            //Act
            bool result = logica.ValidarPalabra();

            //Assert
            Assert.IsFalse(result);
        }

        //---------------Tests de ingreso de usuario-----------//

        [TestMethod]
        public void RevisarQueLetraNoPerteneceALaPalabra()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            //Act
            int cant = logica.GetCantidadAparicionesEnPalabra('u');
            //Assert
            Assert.AreEqual(0, cant);
        }


        //---------------Tests de scoring ----------------//

        [TestMethod]
        public void AumentarScorePorLetrasIngresadas()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            //Act
            logica.IngresarLetra("o");
            //Assert
            Assert.AreEqual(300, logica.Juego.Score);
        }

        [TestMethod]
        public void DisminuirScorePorLetrasIngresadaErronea()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            logica.Juego.Score = 500;
            var score = logica.Juego.Score;
            //Act

            logica.IngresarLetra("u");
            //Assert
            Assert.AreEqual((score-50), logica.Juego.Score);
        }

        [TestMethod]
        public void AsegurarQueElScoreNoBajaDeCero()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            logica.Juego.Score = 30;
            var score = logica.Juego.Score;
            //Act
            logica.IngresarLetra("u");

            //Assert
            Assert.AreEqual(0, logica.Juego.Score);
        }

        [TestMethod]
        public void AumentarScorePorPalabraIngresada()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            //Act
            logica.IngresarPalabra("Ornitorrinco");
            //Assert
            Assert.AreEqual(2000, logica.Juego.Score);
        }

        [TestMethod]
        public void DisminuirScorePorPalabraIngresadaErronea()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.Juego.Score = 5000;
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            //Act
            logica.IngresarPalabra("Pato");
            //Assert
            Assert.AreEqual(4500, logica.Juego.Score);
        }



        //--------------------------Seccion de vidas----------------------//

        [TestMethod]
        public void ObtenerVidasEnJuegoCuandoEstasSonCinco()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.parametrizarVidas(5);
            int vidas = 0;
            //Act
            vidas = logica.GetCantidadDeVidas();
            //Assert
            Assert.AreEqual(vidas, 5);
        }


        [TestMethod]
        public void Parametrizar5VidasEnJuego()
        {
            //Arrange
            var logica = new LogicaJuego();
            //Act
            logica.parametrizarVidas(5);

            //Assert
            Assert.AreEqual(logica.Juego.Vidas, 5);
        }

        [TestMethod]
        public void detectarMuerte()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.parametrizarVidas(3);
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            //Act
            logica.IngresarPalabra("Pato");
            logica.IngresarPalabra("Pato");
            logica.IngresarPalabra("Pato");
            //Assert
            Assert.AreEqual(0, logica.GetCantidadDeVidas());
        }

        [TestMethod]
        public void restarUnaVidaPorPalabraErronea()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.parametrizarVidas(5);
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            //Act
            logica.IngresarPalabra("Pato");
            //Assert
            Assert.AreEqual(logica.Juego.Vidas, 4);
        }

        [TestMethod]
        public void restarUnaVidaPorLetraErronea()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.parametrizarVidas(5);
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            //Act
            logica.IngresarLetra("a");
            //Assert
            Assert.AreEqual(logica.Juego.Vidas, 4);
        }

        [TestMethod]
        public void DetectarMuerteAlLlegarA0Vidas()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.parametrizarVidas(2);
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            logica.IngresarLetra("a");
            logica.IngresarPalabra("Pato");
            logica.ValidarPalabra();
            //Act
            logica.detectarMuerte();
            //Assert
            Assert.AreEqual(logica.Juego.estaVivo, false);
        }

        [TestMethod]
        public void DetectarMuerteAlErrarPalabra()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.parametrizarVidas(1);
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            logica.IngresarPalabra("Pato");
            //Act
            logica.ValidarPalabra();
            //Assert
            Assert.AreEqual(logica.Juego.estaVivo, false);
        }

        [TestMethod]
        public void DetectarMuerteAlErrarLetra()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.parametrizarVidas(1);
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            //Act
            logica.IngresarLetra("a");
            //Assert
            Assert.AreEqual(logica.Juego.estaVivo, false);
        }

        [TestMethod]
        public void ValidarLetraExistente()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.parametrizarVidas(5);
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            //Act
            logica.IngresarLetra("o");
            //Assert
            Assert.AreEqual(logica.Juego.LetrasIngresadas.Contains("o"),true);
        }

        [TestMethod]
        public void RestarVidaPorLetraExistente()
        {
            //Arrange
            var logica = new LogicaJuego();
            logica.parametrizarVidas(5);
            logica.IngresarPalbraEnJuego("Ornitorrinco");
            //Act
            logica.IngresarLetra("o");
            logica.IngresarLetra("o");
            //Assert
            Assert.AreEqual(logica.Juego.Vidas, 4);
        }
    }
}
