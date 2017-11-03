using System;
using NUnit.Framework;
using JSTest;
using JSTest.ScriptLibraries;

namespace UnitTestCalcJS
{
    [TestFixture]
    public class NUnitTestCalcJS
    {
        private readonly TestScript _commonTestScript = new TestScript();

        [Test]
        public void CommonJavaScriptTests()
        {
            _commonTestScript.AppendFile(@"C:\Users\Student\Documents\WizDevCSharp\2017.11.03\CalculatorJS\Calculator.js");
            _commonTestScript.AppendBlock(new JsAssertLibrary());
        }

        public TestContext TestContext { get; set; }

        [Test]
        public void TestCalcPlus()
        {
            _commonTestScript.RunTest(@"assert.equal(4, Calc(2, 2, '+'));");
        }

        [Test]
        public void TestCalcMinus()
        {
            _commonTestScript.RunTest(@"assert.equal(8, Calc(10, 2, '-'));");
        }

        [Test]
        public void TestCalcDiv()
        {
            _commonTestScript.RunTest(@"assert.equal(5, Calc(10, 2, '/'));");
        }

        [Test]
        public void TestCalcMult()
        {
            _commonTestScript.RunTest(@"assert.equal(20, Calc(10, 2, '*'));");
        }
    }
}
