using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Threading;

namespace NUnitTestAptimeaLappolainen
{
    public class Tests
    {
        // интерфейс для взаимодействия с браузером.
        IWebDriver driver;
        //переменная для хранения URL-адреса тестируемого сайта.
        String test_url = "https://marenkova21.thkit.ee/phpLeht/PHPleht/index.php";
        private readonly Random _random = new Random();

        [SetUp]
        // атрибут, указывающий на метод, который будет выполняться перед каждым тестом. Метод
        //создает экземпляр браузера и максимизирует окно браузера.
        public void start_browser()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        // атрибут, указывающий на метод, который представляет собой тестовый сценарий. 
        [Test]

        //Метод test_page1 выполняет тестирование на сайте.
        public void test_page1()
        {
         //Открывается URL-адрес сайта.
         //            driver.Url = test_url;
            driver.Navigate().GoToUrl("https://marenkova21.thkit.ee/phpLeht/PHPleht/index.php");

            //Производится попытка закрыть всплывающее окно cookie (если оно есть).
            try { IWebElement sButton2 = driver.FindElement(By.XPath("//button[@class='agree-button eu-cookie-compliance-secondary-button']")); sButton2.Click(); } catch (Exception) { }

            for (int a = 0; a < 1; a++)
            {
                Thread.Sleep(5500);
                var sRadio = driver.FindElements(By.XPath("//div[@class='fieldset-wrapper']"));
                for (int i = 0; i < sRadio.Count; i++)
                {
                    var els = sRadio[i].FindElements(By.XPath(".//input[@type='radio']"));
                    if (els.Count >= 2)
                    {
                        try { els[_random.Next(0, els.Count)].Click(); } catch (Exception) { }
                    }
                }
                var sText = driver.FindElements(By.XPath("//input[@type='text']"));
                for (int i = 0; i < sText.Count; i++)
                {
                    try { sText[i].Click(); sText[i].SendKeys("Lappolainen"); } catch (Exception) { }
                }
                var sTextArea = driver.FindElements(By.XPath("//textarea"));
                for (int i = 0; i < sTextArea.Count; i++)
                {
                    try { sTextArea[i].Click(); sTextArea[i].SendKeys("LappolainenMartin"); } catch (Exception) { }
                }
                var sNum = driver.FindElements(By.XPath("//input[@type='number']"));
                for (int i = 0; i < sNum.Count; i++)
                {
                    try { sNum[i].Click(); sNum[i].SendKeys("1"); } catch (Exception) { }
                }
                var sSelect = driver.FindElements(By.XPath("//select"));
                for (int i = 0; i < sNum.Count; i++)
                {
                    try { sSelect[i].Click(); sSelect[i].FindElements(By.XPath(".//*"))[2].Click(); } catch (Exception) { }
                }

                IWebElement sButtonE = driver.FindElement(By.XPath("//*[@value='Sauvegarder brouillon']"));
                try { sButtonE.Click(); } catch (Exception) { }
                Thread.Sleep(2500);
                IWebElement sButton = driver.FindElement(By.XPath("//*[@value='Suivant']"));
                try { sButton.Click(); } catch (Exception) { }
            }
            Thread.Sleep(2500);

            IWebElement sButton3 = driver.FindElement(By.XPath("//*[@value='Finaliser']"));
            try { sButton3.Click(); } catch (Exception) { }

            Thread.Sleep(2500);

            IWebElement sButton4 = driver.FindElement(By.XPath("//a[@href='/user/login']"));
            try { sButton4.Click(); } catch (Exception) { }

            Thread.Sleep(2500);

            IWebElement sButton5 = driver.FindElement(By.XPath("//*[@value='Se connecter']"));
            try { sButton5.Click(); } catch (Exception) { }
            Thread.Sleep(8000);
        }
        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}
