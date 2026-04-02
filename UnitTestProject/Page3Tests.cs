using Microsoft.VisualStudio.TestTools.UnitTesting;
using Практическая_работа_4_Кузнецов_Кузьмин;
using System;

namespace UnitTestProject
{
    /// <summary>
    /// Модульные тесты для страницы Page3 (функция y = x² + tan(5x + d/x)).
    /// </summary>
    [TestClass]
    public class Page3Tests
    {
        private Page3 _page;

        [TestInitialize]
        public void Setup()
        {
            _page = new Page3();
        }

        [TestMethod]
        public void CalculateY_ValidInput_ReturnsValue()
        {
            double x = 1, d = 1;
            double expected = 1 * 1 + Math.Tan(5 * 1 + 1 / 1.0);
            double actual = _page.CalculateY(x, d);
            Assert.AreEqual(expected, actual, 1e-6);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void CalculateY_XEqualsZero_ThrowsException()
        {
            _page.CalculateY(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void CalculateY_OverflowY_ThrowsException()
        {
            double x = 2000, d = 0.1;
            _page.CalculateY(x, d);
        }

        [TestMethod]
        public void CalculateY_SmallX_ReturnsFinite()
        {
            double x = 1e-5, d = 1;
            double result = _page.CalculateY(x, d);
            Assert.IsFalse(double.IsNaN(result) || double.IsInfinity(result));
        }
    }
}