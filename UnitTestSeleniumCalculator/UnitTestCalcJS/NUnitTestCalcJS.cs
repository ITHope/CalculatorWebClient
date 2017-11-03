using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSTest;
using JSTest.ScriptLibraries;

namespace UnitTestCalcJS
{
    [TestClass]
    public class UnitTestCalcJS
    {
        private readonly TestScript _commonTestScript = new TestScript();

        [TestInitialize]
        public void CommonJavaScriptTests()
        {
            _commonTestScript.AppendFile("E:\\CSharpDev\\Projects\\Calculator\\CalculatorJS\\Calculator.js");
            _commonTestScript.AppendBlock(new JsAssertLibrary());
        }

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestCalcPlus()
        {
            _commonTestScript.RunTest(@"assert.equal(4, Calc(2, 2, '+'));");
        }

        [TestMethod]
        public void TestCalcMinus()
        {
            _commonTestScript.RunTest(@"assert.equal(8, Calc(10, 2, '-'));");
        }

        [TestMethod]
        public void TestCalcDiv()
        {
            _commonTestScript.RunTest(@"assert.equal(5, Calc(10, 2, '/'));");
        }

        [TestMethod]
        public void TestCalcMult()
        {
            _commonTestScript.RunTest(@"assert.equal(20, Calc(10, 2, '*'));");
        }
    }
}
