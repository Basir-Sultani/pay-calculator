using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OO_programming;

namespace PayCalculatorTest
{
    [TestClass]
    public class PayCalculatorTests
    {
        private double hourlyRate = 25;
        private double hoursWorked = 5;
        private double superRate = 0.1;
        double expected;
        double actual;

        [TestMethod]
        public void grossPay()
        {
            // Gross pay expected is hourlyRate * hoursWorked, 25 * 5 in this case which is 125
            expected = 125;

            // Creating a pay Calculator instance and Calling the gross pay calculator method.
            PayCalculator pc = new PayCalculator(hourlyRate, hoursWorked, superRate);
            actual = pc.calculateGrossPay();

            // Actual testing
            Assert.AreEqual(expected, actual, 0, "Expected Gross pay is not equal to Calculated one..X");
        }

        [TestMethod]
        // Tests the tax when tax free threshold is claimed
        public void calculateTaxWithThreshold()
        {
            //For a weekly income of $80 the tax rates A = 0, B = 0,
            // the expected tax should be ((a*x) - b) ((0 * 500) - 0) which is 0 
            var taxRateA = 0;
            var taxRateB = 0;
            hoursWorked = 3.2; // 3.2 * 25 = 80
            expected = 0;

            // Creating a pay Calculator instance and Calling its tax calculator method.
            PayCalculator calculator = new PayCalculator(hourlyRate, hoursWorked, superRate);
            calculator.setRates(taxRateA, taxRateB);
            actual = calculator.calculateTax();

            Assert.AreEqual(expected, actual, 0.0001, "Expected Tax is not equal to Calculated one.." );
        }

        [TestMethod]
        // Tests the tax when tax free threshold is not claimed
        public void calculateTaxNoThreshold()
        {
            //For a weekly income of $80 the tax rates A = 0.1900, B = 0.1900,
            // the expected tax should be ((a*x) - b) ((0.1900*80) - 0.1900) which is 15.01 
            var taxRateA = 0.1900;
            var taxRateB = 0.1900;
            hoursWorked = 3.2; // 3.2 * 25 = 80
            expected = 15.01;

            // Creating a pay Calculator instance and Calling its tax calculator method.
            PayCalculator pc = new PayCalculator(hourlyRate, hoursWorked, superRate);
            pc.setRates(taxRateA, taxRateB);
            actual = pc.calculateTax();

            Assert.AreEqual(expected, actual, 0.0001, "Expected Tax is not equal to Calculated one.." );
        }
        
        [TestMethod]
        // Tests the net pay when tax free threshold is not claimed
        public void calculateNetPayNoThreshold()
        {
            //For a weekly income of $80 the tax rates A = 0.1900, B = 0.1900,
            // the expected tax should be ((gross - tax) - superannuation) which is 15.01 
            var taxRateA = 0.1900;
            var taxRateB = 0.1900;
            hoursWorked = 3.2; // 3.2 * 25 = 80
            var super = 80 * superRate;
            expected = (80 - (15.01 + super));

            // Creating a pay Calculator instance and Calling its tax calculator method.
            PayCalculator pc = new PayCalculator(hourlyRate, hoursWorked, superRate);
            pc.setRates(taxRateA, taxRateB);
            actual = pc.calculateNetPay();

            Assert.AreEqual(expected, actual, 0.0001, "Expected Tax is not equal to Calculated one.." );
        }

    }
}
