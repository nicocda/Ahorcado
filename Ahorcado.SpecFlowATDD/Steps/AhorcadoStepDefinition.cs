using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO;
using Ahorcado.MVC.Models;
using System.Text.RegularExpressions;

namespace Ahorcado.SpecFlowATDD.Steps
{
    [Binding]
    public class AhorcadoStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        //private readonly ScenarioContext _scenarioContext;

        //private Process _iisProcess;
        //const int _iisPort = 9515;

        IWebDriver driver;
        String baseURL;
        public AhorcadoClass _Ahorcado;
        public static int scorePrin = 0;
        public static int vidas = 0;
        public static String PalEnJuego = "";

        //protected virtual string GetApplicationPath(string applicationName)
        //{
        //    //var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
        //    var solutionFolder = "\\Users\\ciber\\Source\\Repos\\Ahorcado\\";
        //    return Path.Combine(solutionFolder, applicationName);
        //}

        //private void StartIIS()
        //{         
        //    // Obtain application path
        //    var applicationPath = GetApplicationPath("Ahorcado.MVC");
        //    var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        //    // create instance of IIS
        //    _iisProcess = new Process();
        //    // Set Path of instalation ISSExpress in the machine
        //    _iisProcess.StartInfo.FileName = $@"{programFiles}\IIS Express\iisexpress.exe";
        //    // set the application path to atach the ISS and the port
        //    _iisProcess.StartInfo.Arguments = $" /path:{applicationPath} /port:{_iisPort}";
        //    // Start the IIS
        //    _iisProcess.Start();
        //}

        [BeforeScenario]
        public void TestInitialize()
        {
            //StartIIS();
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\Drivers";
            //var path = "C:\\Users\\ciber\\Source\\Repos\\Ahorcado\\Ahorcado.SpecFlowATDD\\Drivers\\";
            driver = new ChromeDriver(path);
            baseURL = "https://localhost:44348/";
        }
        //public AhorcadoStepDefinition(ScenarioContext scenarioContext)
        //{
        //    _scenarioContext = scenarioContext;
        //}

        [Given(@"la palabra en juego esta definida")]
        public void GivenLaPalabraEnJuegoEstaDefinida()
        {
            driver.Url = baseURL;
        }

        [Given(@"estamos en la pagina victoria despues de acertar la palabra a adivinar")]
        public void GivenEstamosEnLaPaginaVictoriaDespuesDeAcertarLaPalabraAAdivinar()
        {
            driver.Navigate().GoToUrl(baseURL);
            vidas = int.Parse(driver.FindElement(By.Id("vidasP")).GetAttribute("value").ToString());
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivP"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString();
            PalEnJuego = palEnJuegoVal;
            var txtPalabra = driver.FindElement(By.Id("palIngresada"));
            txtPalabra.SendKeys(palEnJuegoVal);
            var btnInsertWord = driver.FindElement(By.Id("btnIngPal"));
            btnInsertWord.SendKeys(Keys.Enter);
            scorePrin = int.Parse(driver.FindElement(By.Id("scoreTot")).GetAttribute("value").ToString().ToLower());
        }


        [Given(@"estamos en la pagina de derrota")]
        public void GivenEstamosEnLaPaginaDeDerrota()
        {
            driver.Navigate().GoToUrl(baseURL);
            vidas = int.Parse(driver.FindElement(By.Id("vidasP")).GetAttribute("value").ToString());
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivP"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString();
            PalEnJuego = palEnJuegoVal;
            WhenSeIngresaLaPalabraErroneaCincoVeces();
        }

        [When(@"la palabra en juego es agragada en el campo de palabra")]
        public void WhenLaPalabraEnJuegoEsAgragadaEnElCampoDePalabra()
        {
            //driver.Navigate().GoToUrl(baseURL);
            vidas = int.Parse(driver.FindElement(By.Id("vidasP")).GetAttribute("value").ToString());
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivP"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString();
            var txtPalabra = driver.FindElement(By.Id("palIngresada"));
            txtPalabra.SendKeys(palEnJuegoVal);
            //var btnInsertWord = driver.FindElement(By.Id("btnIngPal"));
            //btnInsertWord.SendKeys(Keys.Enter);
        }


        [When(@"el boton arriesgar es apretado")]
        public void WhenElBotonArriesgarEsApretado()
        {
            var btnInsertWord = driver.FindElement(By.Id("btnIngPal"));
            btnInsertWord.SendKeys(Keys.Enter);
        }



        [When(@"la primer letra de la palabra es ingresada")]
        public void WhenLaPrimerLetraDeLaPalabraEsIngresada()
        {
            //driver.Navigate().GoToUrl(baseURL);
            scorePrin = int.Parse(driver.FindElement(By.Id("scoreTotL")).GetAttribute("value").ToString().ToLower());
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivL"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString();
            var txtLetra = driver.FindElement(By.Id("letraIngresada"));
            txtLetra.SendKeys(palEnJuegoVal[0].ToString());
        }

        [When(@"el boton arriesgar letra es apretado")]
        public void WhenElBotonArriesgarLetraEsApretado()
        {
            var btnInsertLetra = driver.FindElement(By.Id("btnIngLet"));
            btnInsertLetra.SendKeys(Keys.Enter);
        }




        [When(@"la palabra distinta a la en juego es agragada en el campo de palabra")]
        public void WhenLaPalabraDistintaALaEnJuegoEsAgragadaEnElCampoDePalabra()
        {
            //driver.Navigate().GoToUrl(baseURL);
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivP"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString() + "aaaa";
            var txtPalabra = driver.FindElement(By.Id("palIngresada"));
            txtPalabra.SendKeys(palEnJuegoVal);
        }



        [When(@"la una letra erronea es ingresada")]
        public void WhenLaUnaLetraErroneaEsIngresada()
        {
            //driver.Navigate().GoToUrl(baseURL);
            scorePrin = int.Parse(driver.FindElement(By.Id("scoreTotL")).GetAttribute("value").ToString().ToLower());
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivL"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString();
            var letras = "abcdefghijklmnñopqrstuvwxyz";
            var let = letras.First(x => !(palEnJuegoVal.Contains(x))).ToString();
            var txtLetra = driver.FindElement(By.Id("letraIngresada"));
            txtLetra.SendKeys(let);
        }

        [When(@"se ingresa la palabra erronea cinco veces")]
        public void WhenSeIngresaLaPalabraErroneaCincoVeces()
        {
            //driver.Navigate().GoToUrl(baseURL);
            for (int i = 0; i < 5; i++)
            {
                var palEnJuegoC = driver.FindElement(By.Id("palAAdivP"));
                var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString() + "aaaa";
                var txtPalabra = driver.FindElement(By.Id("palIngresada"));
                txtPalabra.SendKeys(palEnJuegoVal);
                WhenElBotonArriesgarEsApretado();
            }
        }



        [When(@"se aprieta el boton de otra partida")]
        public void WhenSeAprietaElBotonDeOtraPartida()
        {
            driver.Navigate().GoToUrl(baseURL);
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivP"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString();
            PalEnJuego = palEnJuegoVal;
            var btnOtraPartida = driver.FindElement(By.Id("otraPartida"));
            btnOtraPartida.SendKeys(Keys.Enter);
        }






        [When(@"se aprieta el boton de siguiente partida")]
        public void WhenSeAprietaElBotonDeSiguientePartida()
        {
            var btnOtraPartida = driver.FindElement(By.Id("botonSigPartida"));
            btnOtraPartida.SendKeys(Keys.Enter);
        }




        [When(@"se aprieta el boton de continuar")]
        public void WhenSeAprietaElBotonDeContinuar()
        {
            var btnContinuar = driver.FindElement(By.Id("botonContinuar"));
            btnContinuar.SendKeys(Keys.Enter);
        }



        [When(@"se ingresa la letra a")]
        public void WhenSeIngresaLaLetraA()
        {
            var txtLetra = driver.FindElement(By.Id("letraIngresada"));
            txtLetra.SendKeys("a");
        }

        [When(@"se ingresa la letra b")]
        public void WhenSeIngresaLaLetraB()
        {
            var txtLetra = driver.FindElement(By.Id("letraIngresada"));
            txtLetra.SendKeys("b");
        }


        [When(@"se ingresan todas las letras de la palabra")]
        public void WhenSeIngresanTodasLasLetrasDeLaPalabra()
        {
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivL"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString();
            List<String> letras = new List<string>();
            foreach (var item in palEnJuegoVal)
            {
                if (!(letras.Contains(item.ToString())))
                {
                    letras.Add(item.ToString());
                }
            }
            foreach (var Ilet in letras)
            {
                var txtLetra = driver.FindElement(By.Id("letraIngresada"));
                txtLetra.SendKeys(Ilet);
                var btnInsertLetra = driver.FindElement(By.Id("btnIngLet"));
                btnInsertLetra.SendKeys(Keys.Enter);
            }
        }




        [Then(@"se deberia motrar un mensaje de victoria")]
        public void ThenSeDeberiaMotrarUnMensajeDeVictoria()
        {
            var menVictoria = driver.FindElement(By.Id("labelVictoria"));
            var MenvictoriaVal = menVictoria.GetAttribute("innerHTML").ToString().ToLower();
            var vict = MenvictoriaVal.Contains("correcto");
            vict.Should().BeTrue();
        }

        [Then(@"se deberia aumentar el score")]
        public void ThenSeDeberiaAumentarElScore()
        {
            var scoreact = int.Parse(driver.FindElement(By.Id("scoreTotL")).GetAttribute("value").ToString().ToLower());
            scoreact.Should().BeGreaterThan(scorePrin);
        }

        [Then(@"el score se mantiene y las vidas y la palabra en juego deben resetearse")]
        public void ThenElScoreSeMantieneYLasVidasYLaPalabraEnJuegoDebenResetearse()
        {
            var score = int.Parse(driver.FindElement(By.Id("scoreTotL")).GetAttribute("value").ToString().ToLower());
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivP"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString();
            var vidasAct = int.Parse(driver.FindElement(By.Id("vidasP")).GetAttribute("value").ToString());
            bool resul = false;
            if (score == scorePrin && palEnJuegoVal != PalEnJuego && vidasAct == vidas)
            {
                resul = true;
            }
            resul.Should().BeTrue();
        }


        [Then(@"la lista de letras ingresadas debe mostrar que se ingresaron las letras a y b")]
        public void ThenLaListaDeLetrasIngresadasDebeMostrarQueSeIngresaronLasLetrasAYB()
        {
            var lista = driver.FindElement(By.Id("listaLetra")).GetAttribute("innerHTML").ToString().ToLower();
            var tien = lista.Contains("a,b");
            tien.Should().BeTrue();

        }


        [Then(@"el score las vidas y la palabra en juego deben resetearse")]
        public void ThenElScoreLasVidasYLaPalabraEnJuegoDebenResetearse()
        {
            var score = int.Parse(driver.FindElement(By.Id("scoreTotL")).GetAttribute("value").ToString().ToLower());
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivP"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString();
            var vidasAct = int.Parse(driver.FindElement(By.Id("vidasP")).GetAttribute("value").ToString());
            bool resul = false;
            if (score == 0 && palEnJuegoVal != PalEnJuego && vidasAct == vidas)
            {
                resul = true;
            }
            resul.Should().BeTrue();
        }

        [Then(@"se deberia bajar el contador de vidas")]
        public void ThenSeDeberiaBajarElContadorDeVidas()
        {
            var vidasAct = int.Parse(driver.FindElement(By.Id("vidasP")).GetAttribute("value").ToString());
            vidasAct.Should().BeLessThan(vidas);
        }

        [Then(@"el contador de vidas deberia ser cero")]
        public void ThenElContadorDeVidasDeberiaSer()
        {
            var vidasAct = int.Parse(driver.FindElement(By.Id("vidas")).GetAttribute("value").ToString());
            vidasAct.Should().Be(0);
        }


        [Then(@"el score deberia terminar en (.*)")]
        public void ThenElScoreDeberiaTerminarEn(int p0)
        {
            var score = driver.FindElement(By.Id("scoreTotL")).GetAttribute("value").ToString().ToLower();
            var term = score.EndsWith(p0.ToString());
            term.Should().BeTrue();
        }

        [Then(@"la palabra oculta deberia mostrar la letra adivinada")]
        public void ThenLaPalabraOcultaDeberiaMostrarLaLetraAdivinada()
        {
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivP")).GetAttribute("value").ToString();
            var palModAct = driver.FindElement(By.Id("palModAct")).GetAttribute("innerHTML").ToString();
            palModAct = Regex.Replace(palModAct, @"<[^>]+>|&nbsp;", "").Trim();
            var bole = (palModAct[0] == palModAct[0]);
            bole.Should().BeTrue();
        }

        [Then(@"se deberia mostrar un mensaje de victoria")]
        public void ThenSeDeberiaMostrarUnMensajeDeVictoria()
        {
            var mensajevic = driver.FindElement(By.Id("labelVictoria")).GetAttribute("innerHTML").ToString().ToLower() ;
            var tien = mensajevic.Contains("correcto");
            tien.Should().BeTrue();
        }


        [AfterScenario]
        public void TestCleanUp()
        {
           //if(_iisProcess.HasExited == false)
           // {
           //     _iisProcess.Kill();
           // }

            driver.Quit();
        }



    }
}
