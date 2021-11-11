using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class ZeroTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            string expectedErrorMessage = "Attempted to divide by zero.";


            var ex = Assert.ThrowsException<DivideByZeroException>(() => ExpressionCalculation.Calculator.Evaluate("10/0"));

            Assert.AreEqual(expectedErrorMessage, ex.Message);
        }
    }
}
