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
        String baseURL = "https://localhost:44348/";
        public  AhorcadoClass _Ahorcado;
        public static int score = 0;
        public static int vidas = 0;

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
            var path = "C:\\Users\\ciber\\Source\\Repos\\Ahorcado\\Ahorcado.SpecFlowATDD\\Drivers\\";
            driver = new ChromeDriver(path);
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



        [When(@"la palabra en juego es agragada en el campo de palabra")]
        public void WhenLaPalabraEnJuegoEsAgragadaEnElCampoDePalabra()
        {
            driver.Navigate().GoToUrl(baseURL);
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

        [Then(@"se deberia motrar un mensaje de victoria")]
        public void ThenSeDeberiaMotrarUnMensajeDeVictoria()
        {
            var menVictoria = driver.FindElement(By.Id("labelVictoria"));
            var MenvictoriaVal = menVictoria.GetAttribute("innerHTML").ToString().ToLower();
            var vict = MenvictoriaVal.Contains("correcto");
            vict.Should().BeTrue();
        }

        [When(@"la primer letra de la palabra es ingresada")]
        public void WhenLaPrimerLetraDeLaPalabraEsIngresada()
        {
            driver.Navigate().GoToUrl(baseURL);
            score = int.Parse(driver.FindElement(By.Id("scoreTotL")).GetAttribute("value").ToString().ToLower());
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


        [Then(@"se deberia aumentar el score")]
        public void ThenSeDeberiaAumentarElScore()
        {
           var scoreact = int.Parse(driver.FindElement(By.Id("scoreTotL")).GetAttribute("value").ToString().ToLower());
            scoreact.Should().BeGreaterThan(score);
        }


        [When(@"la palabra distinta a la en juego es agragada en el campo de palabra")]
        public void WhenLaPalabraDistintaALaEnJuegoEsAgragadaEnElCampoDePalabra()
        {
            driver.Navigate().GoToUrl(baseURL);
            var palEnJuegoC = driver.FindElement(By.Id("palAAdivP"));
            var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString().Reverse().ToString();
            var txtPalabra = driver.FindElement(By.Id("palIngresada"));
            txtPalabra.SendKeys(palEnJuegoVal);
        }

        [Then(@"se deberia bajar el contador de vidas")]
        public void ThenSeDeberiaBajarElContadorDeVidas()
        {
            var vidasAct = int.Parse(driver.FindElement(By.Id("vidasP")).GetAttribute("value").ToString());
            vidasAct.Should().BeLessThan(vidas);
        }

        [When(@"la una letra erronea es ingresada")]
        public void WhenLaUnaLetraErroneaEsIngresada()
        {
            driver.Navigate().GoToUrl(baseURL);
            score = int.Parse(driver.FindElement(By.Id("scoreTotL")).GetAttribute("value").ToString().ToLower());
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
            driver.Navigate().GoToUrl(baseURL);
            for (int i = 0; i < 5; i++)
            {
                var palEnJuegoC = driver.FindElement(By.Id("palAAdivP"));
                var palEnJuegoVal = palEnJuegoC.GetAttribute("value").ToString().Reverse().ToString();
                var txtPalabra = driver.FindElement(By.Id("palIngresada"));
                txtPalabra.SendKeys(palEnJuegoVal);
                WhenElBotonArriesgarEsApretado();
            }
        }

        [Then(@"el contador de vidas deveria ser cero")]
        public void ThenElContadorDeVidasDeveriaSer()
        {
            var vidasAct = int.Parse(driver.FindElement(By.Id("vidas")).GetAttribute("value").ToString());
            vidasAct.Should().Be(0);
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
