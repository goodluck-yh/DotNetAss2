using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace SalaryCalculateTestPro
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void AnnualSalaryTest ()
        {
            //arrange
            SalaryCalculator sc = new SalaryCalculator();
            //act
            decimal annual = sc.GetAnnual(50);
            //assert
            Assert.AreEqual(104000, annual);
        }
    }
}
