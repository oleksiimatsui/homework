using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            double actual;
            double expected;

            actual = ExpressionCalculation.Calculator.Evaluate("(1/2+2*3<22)+not(33*1/11-2)");
            expected = 1;
            Assert.AreEqual(expected, actual, "Calculator not worked correctly");

        }
    }
}
