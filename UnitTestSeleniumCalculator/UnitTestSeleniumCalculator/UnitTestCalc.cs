using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;

namespace UnitTestSeleniumCalculator
{
    [TestClass]
    public class UnitTestCalc
    {
        string baseURL = @"C:\Users\Student\Documents\WizDevCSharp\2017.11.03\CalculatorJS\CalculatorJS.html";
        private RemoteWebDriver driver;
        public TestContext TestContext { get; set; }
       

        [TestMethod]
        [TestCategory("Selenium")]
        [Owner("Chrome")]
        public void TestMethod_5Plus1()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl(this.baseURL);
            driver.FindElementById("a").SendKeys("5");
            driver.FindElementById("b").SendKeys("1");
            driver.FindElementById("op").SendKeys("+");
            driver.FindElementById("btnRes").Click();
            string exp = driver.FindElementById("res").GetAttribute("value");
            Assert.AreEqual("6", exp);
        }

        [TestMethod]
        [TestCategory("Selenium")]
        [Owner("Chrome")]
        public void TestMethod_5Mult10()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl(this.baseURL);
            driver.FindElementById("a").SendKeys("5");
            driver.FindElementById("b").SendKeys("10");
            driver.FindElementById("op").SendKeys("*");
            driver.FindElementById("btnRes").Click();
            string exp = driver.FindElementById("res").GetAttribute("value");
            Assert.AreEqual("50", exp);
        }

        [TestMethod]
        [TestCategory("Selenium")]
        [Owner("Chrome")]
        public void TestMethod_15Minus6()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl(this.baseURL);
            driver.FindElementById("a").SendKeys("15");
            driver.FindElementById("b").SendKeys("6");
            driver.FindElementById("op").SendKeys("-");
            driver.FindElementById("btnRes").Click();
            string exp = driver.FindElementById("res").GetAttribute("value");
            Assert.AreEqual("9", exp);
        }

        [TestMethod]
        [TestCategory("Selenium")]
        [Owner("Chrome")]
        public void TestMethod_20Div4()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl(this.baseURL);
            driver.FindElementById("a").SendKeys("20");
            driver.FindElementById("b").SendKeys("4");
            driver.FindElementById("op").SendKeys("/");
            driver.FindElementById("btnRes").Click();
            string exp = driver.FindElementById("res").GetAttribute("value");
            Assert.AreEqual("5", exp);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
        }
    }
}
