using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class IdenTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => ExpressionCalculation.Calculator.Evaluate("a1"));
        }
    }
}
