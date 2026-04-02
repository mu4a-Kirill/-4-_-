using Microsoft.VisualStudio.TestTools.UnitTesting;
using Практическая_работа_4_Кузнецов_Кузьмин;
using System;

namespace UnitTestProject
{
    /// <summary>
    /// Модульные тесты для страницы Page1 (функция β).
    /// </summary>
    [TestClass]
    public class Page1Tests
    {
        private Page1 _page;

        [TestInitialize]
        public void Setup()
        {
            _page = new Page1();
        }

        /// <summary>
        /// Проверяет, что метод CalculateBeta возвращает конечное число для допустимых входных данных.
        /// </summary>
        [TestMethod]
        public void CalculateBeta_ValidInput_ReturnsFiniteValue()
        {
            double x = 10, y = 9, z = 0.9;
            double result = _page.CalculateBeta(x, y, z);
            Assert.IsFalse(double.IsNaN(result) || double.IsInfinity(result), "Результат не должен быть NaN или бесконечностью");
        }

        /// <summary>
        /// Проверяет, что при z вне диапазона [-1,1] выбрасывается ArgumentOutOfRangeException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateBeta_ZOutOfRange_ThrowsException()
        {
            _page.CalculateBeta(1, 1, 2);
        }

        /// <summary>
        /// Проверяет, что при отрицательном подкоренном выражении выбрасывается InvalidOperationException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CalculateBeta_NegativeUnderSqrt_ThrowsException()
        {
            double x = 5, y = 10, z = 0.1; 
            _page.CalculateBeta(x, y, z);
        }

        /// <summary>
        /// Проверяет равенство результата с эталонным вычислением для известных значений.
        /// </summary>
        [TestMethod]
        public void CalculateBeta_KnownValues_ReturnsExpected()
        {
            double x = 2, y = 1, z = 0.9;
            double expected = Math.Sqrt(10 * (Math.Pow(x, 1.0 / 3.0) + Math.Pow(x, y + 2)) * (Math.Pow(Math.Asin(z), 2) - Math.Abs(x - y)));
            double actual = _page.CalculateBeta(x, y, z);
            Assert.AreEqual(expected, actual, 1e-6);
        }
    }
}