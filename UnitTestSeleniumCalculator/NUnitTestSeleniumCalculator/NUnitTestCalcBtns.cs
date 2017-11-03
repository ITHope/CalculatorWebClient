using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using NUnit.Framework;



namespace NUnitTestSeleniumCalculator
{
    //[TestFixture]
    //public class UnitTestSafari : UnitTest1
    //{
    //    internal override IWebDriver MakeDriver()
    //    {
    //        return new SafariDriver();
    //    }
    //}
    [TestFixture]
    public class UnitTestChrome : UnitTest1
    {
        internal override IWebDriver MakeDriver()
        {
            return new ChromeDriver();
        }
    }
    //[TestFixture]
    //public class UnitTestOpera : UnitTest1
    //{
    //    internal override IWebDriver MakeDriver()
    //    {
    //        OperaOptions srv = new OperaOptions();
    //        srv.BinaryLocation = @"C:\Program Files\Opera\launcher.exe";
    //        return new OperaDriver();
    //    }
    //}
    //[TestFixture]
    //public class UnitTestFirefox : UnitTest1
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

    //[TestFixture]
    //public class UnitTestPhantomJS : UnitTest1
    //{
    //    internal override IWebDriver MakeDriver()
    //    {
    //        return new PhantomJSDriver();
    //    }
    //}


    [TestFixture]
    public abstract class UnitTest1
    {
        internal abstract IWebDriver MakeDriver();

        //public static IWebDriver driver;

        public UnitTest1()
        {
            driver = MakeDriver();
            obj = new POM(driver);
            driver.Navigate().GoToUrl(@"E:\CSharpDev\Projects\Calculator\CalculatorJS\CalcJSBtns.html");

        }

        public IWebDriver driver;
        POM obj;

        [OneTimeSetUp]
        public static void ClassSetUp()
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


            //driver.Navigate().GoToUrl("file:///E:/CSharpDev/Projects/Calculator/CalculatorJS/CalcJSBtns.html");
        }

        [TearDown]
        public void ClassTearDown()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
           driver.Navigate().Refresh();
        }

        
        [TestCase("tbCalc", "")]
        [TestCase("btn0", "0")]
        [TestCase("btn1", "1")]
        [TestCase("btn2", "2")]
        [TestCase("btn3", "3")]
        [TestCase("btn4", "4")]
        [TestCase("btn5", "5")]
        [TestCase("btn6", "6")]
        [TestCase("btn7", "7")]
        [TestCase("btn8", "8")]
        [TestCase("btn9", "9")]
        [TestCase("btnPlus", "+")]
        [TestCase("btnMinus", "-")]
        [TestCase("btnDiv", "/")]
        [TestCase("btnMult", "*")]
        [TestCase("btnRes", "=")]
        public void TestGetAllElem(string id, string exp)
        {
            string res = obj.GetButton(id).GetAttribute("value");
            Assert.AreEqual(exp, res);
        }

        
        [TestCase("btn0", "0")]
        [TestCase("btn1", "1")]
        [TestCase("btn2", "2")]
        [TestCase("btn3", "3")]
        [TestCase("btn4", "4")]
        [TestCase("btn5", "5")]
        [TestCase("btn6", "6")]
        [TestCase("btn7", "7")]
        [TestCase("btn8", "8")]
        [TestCase("btn9", "9")]
        [TestCase("btnPlus", "")]
        [TestCase("btnMinus", "")]
        [TestCase("btnDiv", "")]
        [TestCase("btnMult", "")]
        [TestCase("btnRes", "0")]
        public void TestUseAllElem(string id, string exp)
        {
            obj.GetButton(id).Click();
            string res = obj.GetTextBox("tbCalc").GetAttribute("value");
            Assert.AreEqual(exp, res);
        }


        
        [TestCase(new string[] { "btn1", "btn2", "btn3" }, "123")]
        [TestCase(new string[] { "btn4", "btn5", "btn6" }, "456")]
        [TestCase(new string[] { "btn7", "btn8" }, "78")]
        [TestCase(new string[] { "btn9", "btn0" }, "90")]
        public void TestComplexUseElem(string[] id, string exp)
        {
            foreach (string str in id)
            {
                obj.GetButton(str).Click();
            }
            string res = obj.GetTextBox("tbCalc").GetAttribute("value");
            Assert.AreEqual(exp, res);
        }

        
        [TestCase(new string[] { "btn1", "btnPlus", "btn3" }, "4")]
        [TestCase(new string[] { "btn4", "btnPlus", "btn6" }, "10")]
        [TestCase(new string[] { "btn7", "btn8", "btnPlus", "btn2" }, "80")]
        [TestCase(new string[] { "btn9", "btn0", "btnPlus", "btn3" }, "93")]
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

        
        [TestCase(new string[] { "btn1", "btnMinus", "btn3" }, "-2")]
        [TestCase(new string[] { "btn4", "btnMinus", "btn6" }, "-2")]
        [TestCase(new string[] { "btn7", "btn8", "btnMinus", "btn2" }, "76")]
        [TestCase(new string[] { "btn9", "btn0", "btnMinus", "btn3" }, "87")]
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

        
        [TestCase(new string[] { "btn1", "btnMult", "btn3" }, "3")]
        [TestCase(new string[] { "btn4", "btnMult", "btn6" }, "24")]
        [TestCase(new string[] { "btn7", "btn8", "btnMult", "btn2" }, "156")]
        [TestCase(new string[] { "btn9", "btn0", "btnMult", "btn3" }, "270")]
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

        
        [TestCase(new string[] { "btn3", "btnDiv", "btn1" }, "3")]
        [TestCase(new string[] { "btn6", "btnDiv", "btn6" }, "1")]
        [TestCase(new string[] { "btn7", "btn8", "btnDiv", "btn2" }, "39")]
        [TestCase(new string[] { "btn9", "btn0", "btnDiv", "btn3" }, "30")]
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