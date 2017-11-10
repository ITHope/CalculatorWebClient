using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using UnitTestSeleniumCalculator;

namespace UnitTestSeleniumCalculator
{
    //[TestClass]
    //public class NUnitTestSafari : UnitTest1
    //{
    //    internal override IWebDriver MakeDriver()
    //    {
    //        return new SafariDriver();
    //    }
    //}
    [TestClass]
    public class NUnitTestChrome : UnitTest1
    {


        internal override IWebDriver MakeDriver()
        {
            return new ChromeDriver();
        }
    }
    //[TestClass]
    //public class NUnitTestOpera : UnitTest1
    //{
    //    internal override IWebDriver MakeDriver()
    //    {
    //        OperaOptions srv = new OperaOptions();
    //        srv.BinaryLocation = @"C:\Program Files\Opera\launcher.exe";
    //        return new OperaDriver();
    //    }
    //}
    //[TestClass]
    //public class NUnitTestFirefox : UnitTest1
    //{
    //    internal override IWebDriver MakeDriver()
    //    {
    //        FirefoxOptions options = new FirefoxOptions();
    //        FirefoxProfile firefoxProfile = new FirefoxProfile();
    //        firefoxProfile.AcceptUntrustedCertificates = true;
    //        firefoxProfile.AssumeUntrustedCertificateIssuer = false;
    //        options.BrowserExecutableLocation = "C:/Program Files/Mozilla Firefox/firefox.exe";
    //        return new FirefoxDriver();
    //    }
    //}

    //[TestClass]
    //public class NUnitTestPhantomJS : UnitTest1
    //{
    //    internal override IWebDriver MakeDriver()
    //    {
    //        return new PhantomJSDriver();
    //    }
    //}

    [TestClass]
    public abstract class UnitTest1
    {
        public /*static*/ IWebDriver driver = null;
        POM obj;
        internal abstract IWebDriver MakeDriver();

        public UnitTest1()
        {
            //if (driver == null)
                driver = MakeDriver();
            obj = new POM(driver);
            driver.Navigate().GoToUrl(@"../../../CalcJSBtns.html");
        }

        //~UnitTest1()
        //{
        //    driver.Quit();
        //    driver = null;
        //}

        [ClassInitialize]
        public static void ClassSetUp(TestContext t)
        {


            //Chrome
            //driver = new ChromeDriver();

            //Opera
            //OperaOptions srv = new OperaOptions();
            //srv.BinaryLocation = @"C:\Program Files\Opera\launcher.exe";
            //driver = new OperaDriver(srv);

            //Firefox
            //FirefoxOptions options = new FirefoxOptions();
            //FirefoxProfile firefoxProfile = new FirefoxProfile();
            //firefoxProfile.AcceptUntrustedCertificates = true;
            //firefoxProfile.AssumeUntrustedCertificateIssuer = false;
            //options.BrowserExecutableLocation = "C:/Program Files/Mozilla Firefox/firefox.exe";
            //driver = new FirefoxDriver();

            //PhantomJS
            //driver = new PhantomJSDriver();

            //InternetExplorer
            //driver = new InternetExplorerDriver();

            //Safari
            //driver = new SafariDriver();

            //driver.Navigate().GoToUrl(@"E:\CSharpDev\Projects\Calculator\CalculatorJS\CalcJSBtns.html");
        }

        //[ClassCleanup]
        //public static void ClassTearDown()
        //{
        //    driver.Quit();
        //}

        [TestCleanup]
        public void TestTearDown()
        {
            driver.Quit();
            
        }

        [TestInitialize]
        public void SetUp()
        {
            driver.Navigate().Refresh();
        }

        [DataTestMethod]
        [DataRow("tbCalc", "")]
        [DataRow("btn0", "0")]
        [DataRow("btn1", "1")]
        [DataRow("btn2", "2")]
        [DataRow("btn3", "3")]
        [DataRow("btn4", "4")]
        [DataRow("btn5", "5")]
        [DataRow("btn6", "6")]
        [DataRow("btn7", "7")]
        [DataRow("btn8", "8")]
        [DataRow("btn9", "9")]
        [DataRow("btnPlus", "+")]
        [DataRow("btnMinus", "-")]
        [DataRow("btnDiv", "/")]
        [DataRow("btnMult", "*")]
        [DataRow("btnRes", "=")]
        public void TestGetAllElem(string id, string exp)
        {
            string res = obj.GetButton(id).GetAttribute("value");
            Assert.AreEqual(exp, res);
        }

        [DataTestMethod]
        [DataRow("btn0", "0")]
        [DataRow("btn1", "1")]
        [DataRow("btn2", "2")]
        [DataRow("btn3", "3")]
        [DataRow("btn4", "4")]
        [DataRow("btn5", "5")]
        [DataRow("btn6", "6")]
        [DataRow("btn7", "7")]
        [DataRow("btn8", "8")]
        [DataRow("btn9", "9")]
        [DataRow("btnPlus", "")]
        [DataRow("btnMinus", "")]
        [DataRow("btnDiv", "")]
        [DataRow("btnMult", "")]
        [DataRow("btnRes", "0")]
        public void TestUseAllElem(string id, string exp)
        {
            obj.GetButton(id).Click();
            string res = obj.GetTextBox("tbCalc").GetAttribute("value");
            Assert.AreEqual(exp, res);
        }


        [DataTestMethod]
        [DataRow(new string[] { "btn1", "btn2", "btn3" }, "123")]
        [DataRow(new string[] { "btn4", "btn5", "btn6" }, "456")]
        [DataRow(new string[] { "btn7", "btn8" }, "78")]
        [DataRow(new string[] { "btn9", "btn0" }, "90")]
        public void TestComplexUseElem(string[] id, string exp)
        {
            foreach (string str in id)
            {
                obj.GetButton(str).Click();
            }
            string res = obj.GetTextBox("tbCalc").GetAttribute("value");
            Assert.AreEqual(exp, res);
        }

        [DataTestMethod]
        [DataRow(new string[] { "btn1", "btnPlus", "btn3" }, "4")]
        [DataRow(new string[] { "btn4", "btnPlus", "btn6" }, "10")]
        [DataRow(new string[] { "btn7", "btn8", "btnPlus", "btn2" }, "80")]
        [DataRow(new string[] { "btn9", "btn0", "btnPlus", "btn3" }, "93")]
        public void TestRealJobPlus(string[] id, string exp)
        {
            foreach (string str in id)
            {
                obj.GetButton(str).Click();
            }
            obj.GetButton("btnRes").Click();
            string res = obj.GetTextBox("tbCalc").GetAttribute("value");
            Assert.AreEqual(exp, res);
        }

        [DataTestMethod]
        [DataRow(new string[] { "btn1", "btnMinus", "btn3" }, "-2")]
        [DataRow(new string[] { "btn4", "btnMinus", "btn6" }, "-2")]
        [DataRow(new string[] { "btn7", "btn8", "btnMinus", "btn2" }, "76")]
        [DataRow(new string[] { "btn9", "btn0", "btnMinus", "btn3" }, "87")]
        public void TestRealJobMinus(string[] id, string exp)
        {
            foreach (string str in id)
            {
                obj.GetButton(str).Click();
            }
            obj.GetButton("btnRes").Click();
            string res = obj.GetTextBox("tbCalc").GetAttribute("value");
            Assert.AreEqual(exp, res);
        }

        [DataTestMethod]
        [DataRow(new string[] { "btn1", "btnMult", "btn3" }, "3")]
        [DataRow(new string[] { "btn4", "btnMult", "btn6" }, "24")]
        [DataRow(new string[] { "btn7", "btn8", "btnMult", "btn2" }, "156")]
        [DataRow(new string[] { "btn9", "btn0", "btnMult", "btn3" }, "270")]
        public void TestRealJobMult(string[] id, string exp)
        {
            foreach (string str in id)
            {
                obj.GetButton(str).Click();
            }
            obj.GetButton("btnRes").Click();
            string res = obj.GetTextBox("tbCalc").GetAttribute("value");
            Assert.AreEqual(exp, res);
        }

        [DataTestMethod]
        [DataRow(new string[] { "btn3", "btnDiv", "btn1" }, "3")]
        [DataRow(new string[] { "btn6", "btnDiv", "btn6" }, "1")]
        [DataRow(new string[] { "btn7", "btn8", "btnDiv", "btn2" }, "39")]
        [DataRow(new string[] { "btn9", "btn0", "btnDiv", "btn3" }, "30")]
        public void TestRealJobDiv(string[] id, string exp)
        {
            foreach (string str in id)
            {
                obj.GetButton(str).Click();
            }
            obj.GetButton("btnRes").Click();
            string res = obj.GetTextBox("tbCalc").GetAttribute("value");
            Assert.AreEqual(exp, res);
        }

	}
}
