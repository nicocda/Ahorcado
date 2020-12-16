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
