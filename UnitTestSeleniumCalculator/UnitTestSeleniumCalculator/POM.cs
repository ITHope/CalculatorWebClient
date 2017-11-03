using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;



namespace UnitTestSeleniumCalculator
{
   
    [TestClass]
    public class POM
    {

        string btn1 = "btn1";
        string btn2 = "btn2";
        string btn3 = "btn3";
        string btn4 = "btn4";
        string btn5 = "btn5";
        string btn6 = "btn6";
        string btn7 = "btn7";
        string btn8 = "btn8";
        string btn9 = "btn9";
        string btn0 = "btn0";
        string btnPlus = "btnPlus";
        string btnMinus = "btnMinus";
        string btnMult = "btnMult";
        string btnDiv = "btnDiv";
        string btnRes = "btnRes";
        string tbCalc = "tbCalc";

        IWebDriver driver;
        public POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public POM()
        {
            
        }


        public IWebElement GetButton(string id)
        {
            IWebElement flag = null;
            if (id == nameof(btn1))
                flag = driver.FindElement(By.Id(btn1));
            else if (id == nameof(btn2))
                flag = driver.FindElement(By.Id(btn2));
            else if (id == nameof(btn3))
                flag = driver.FindElement(By.Id(btn3));
            else if (id == nameof(btn4))
                flag = driver.FindElement(By.Id(btn4));
            else if (id == nameof(btn5))
                flag = driver.FindElement(By.Id(btn5));
            else if (id == nameof(btn6))
                flag = driver.FindElement(By.Id(btn6));
            else if (id == nameof(btn7))
                flag = driver.FindElement(By.Id(btn7));
            else if (id == nameof(btn8))
                flag = driver.FindElement(By.Id(btn8));
            else if (id == nameof(btn9))
                flag = driver.FindElement(By.Id(btn9));
            else if (id == nameof(btn0))
                flag = driver.FindElement(By.Id(btn0));
            else if (id == nameof(btnMinus))
                flag = driver.FindElement(By.Id(btnMinus));
            else if (id == nameof(btnPlus))
                flag = driver.FindElement(By.Id(btnPlus));
            else if (id == nameof(btnDiv))
                flag = driver.FindElement(By.Id(btnDiv));
            else if (id == nameof(btnRes))
                flag = driver.FindElement(By.Id(btnRes));
            else if (id == nameof(btnMult))
                flag = flag = driver.FindElement(By.Id(btnMult));
            else if (id == nameof(tbCalc))
                flag = flag = driver.FindElement(By.Id(tbCalc));
            return flag;
        }

        public IWebElement GetTextBox(string s)
        {
            IWebElement flag = null;
            if (s == nameof(tbCalc))
                flag = driver.FindElement(By.Id(tbCalc));
            return flag;
        }
    }
}
