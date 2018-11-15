using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMICalculator;
using System;

namespace BMICalculatorTests.UnitTests
{
    [TestClass]
    public class BMICalculatorTest
    {
        [TestMethod]
        public void TestMethod_BMICalc_Calculates_CorrectValue()
        {
            //Arrange **********************************************************************
            BMI MyCalc = new BMI
            {
                WeightStones = 5,
                WeightPounds = 2,
                HeightFeet = 5,
                HeightInches = 3
            };

            double totalWeightInPounds = (MyCalc.WeightStones * 14) + MyCalc.WeightPounds;
            double totalHeightInInches = (MyCalc.HeightFeet * 12) + MyCalc.HeightInches;

            /* do conversions to metric 
            to see that test works, needs to change not a value, but calculation,
            because we are checking is calculation correct. This can be done if any of 
            converting ratios would be changed.*/
            //TODO: uncomment the line below to check if test is failing
            //const double PoundsToKgs = 0.454;
            //TODO: uncomment the line below to see: test is passing
            const double PoundsToKgs = 0.453592;
            const double InchestoMetres = 0.0254;

            double totalWeightInKgs = totalWeightInPounds * PoundsToKgs;
            double totalHeightInMetres = totalHeightInInches * InchestoMetres;
            double expectedValue = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));

            // Act - This calls actual calculation of BMICalculator with *********************
            double actual = MyCalc.BMIValue;
            // Assert ************************************************************************
            Assert.AreEqual(expectedValue, actual);
        }
    }
}
