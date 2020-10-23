using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using TechTalk.SpecFlow;
using Ahorcado.Logica;

namespace Ahorcado.UIAutomation
{
    [Binding]
    public class AhorcadoTest
    {
        IWebDriver driver;
        String baseURL;
        LogicaJuego logicaJuego;

        [BeforeScenario]
        public void TestInitialize()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\Drivers";
            driver = new InternetExplorerDriver(path);
            baseURL = "http://localhost:39278/";
        }

        [Given(@"Ingrese con una palabra")]
        public void Probar_Palabra_Ingresada()
        {
            logicaJuego = new LogicaJuego();
            logicaJuego.IngresarPalabra("Ahorcado");

            driver.Navigate().GoToUrl(baseURL);
            var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
            txtPalabra.SendKeys("Ahorcado");
            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);
        }

        [When(@"I enter X as the typedLetter five times")]
        public void WhenIEnterXAsTheTypedLetterFiveTimes()
        {
            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
            for (int i = 0; i < 7; i++)
            {
                letterTyped.SendKeys("X");
                btnInsertLetter.SendKeys(Keys.Enter);
            }
        }

        [Then(@"I should be told that I lost")]
        public void ThenIShouldBeToldThatILost()
        {
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            var loss = Convert.ToInt32(chancesLeft.GetAttribute("value")) == 0;
            Assert.IsTrue(loss);
        }
        [AfterScenario]
        public void TestCleanUp()
        {
            driver.Quit();
        }

    }
}
