using Microsoft.VisualStudio.TestTools.UnitTesting;
using Практическая_работа_4_Кузнецов_Кузьмин;
using System;

namespace UnitTestProject
{
    /// <summary>
    /// Модульные тесты для страницы Page2 (функция g).
    /// </summary>
    [TestClass]
    public class Page2Tests
    {
        private Page2 _page;

        [TestInitialize]
        public void Setup()
        {
            _page = new Page2();
        }

        [TestMethod]
        public void CalculateG_FirstBranch_Sh_ReturnsCorrect()
        {
            double x = 1, b = 2;
            string func = "sh";
            double f = Math.Sinh(x);
            double expected = Math.Exp(f - Math.Abs(b));
            double actual = _page.CalculateG(x, b, func);
            Assert.AreEqual(expected, actual, 1e-6);
        }

        [TestMethod]
        public void CalculateG_FirstBranch_Square_ReturnsCorrect()
        {
            double x = 1.5, b = 0.6;
            string func = "square";
            double f = x * x;
            double expected = Math.Exp(f - Math.Abs(b));
            double actual = _page.CalculateG(x, b, func);
            Assert.AreEqual(expected, actual, 1e-6);
        }

        [TestMethod]
        public void CalculateG_SecondBranch_Exp_ReturnsCorrect()
        {
            double x = 0.2, b = 1;
            string func = "exp";
            double f = Math.Exp(x);
            double expected = Math.Sqrt(Math.Abs(f) + Math.Abs(b));
            double actual = _page.CalculateG(x, b, func);
            Assert.AreEqual(expected, actual, 1e-6);
        }

        [TestMethod]
        public void CalculateG_ElseBranch_Sh_ReturnsCorrect()
        {
            double x = 0.05, b = 2;
            string func = "sh";
            double f = Math.Sinh(x);
            double expected = 2 * f * f;
            double actual = _page.CalculateG(x, b, func);
            Assert.AreEqual(expected, actual, 1e-6);
        }

        [TestMethod]
        public void CalculateG_BoundaryXbEqualsHalf_GoesToElse()
        {
            double x = 1, b = 0.5;
            string func = "square";
            double f = x * x;
            double expected = 2 * f * f;
            double actual = _page.CalculateG(x, b, func);
            Assert.AreEqual(expected, actual, 1e-6);
        }
    }
}