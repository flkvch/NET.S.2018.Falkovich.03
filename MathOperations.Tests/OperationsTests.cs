using System;
using NUnit.Framework;
using MathOperations;
using System.Diagnostics;

namespace MathOperations.Tests
{
    [TestFixture]
    class OperationsTests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public static void FindNthRoot_ValidCases(double number, int n, double accuracy, double expectedResult)
        {
            Assert.AreEqual(Operations.FindNthRoot(number, n, accuracy), expectedResult, accuracy);
        }

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindNthRoot_NotValidCases_Exception(double number, int n, double accuracy) =>
            Assert.Throws<ArgumentException>(() => Operations.FindNthRoot(number, n, accuracy));

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(9991, ExpectedResult = -1)]
        [TestCase(98765211, ExpectedResult = -1)]
        public static int FindNextBiggerNumber_ValidCases(int number)
        => Operations.FindNextBiggerNumber(number);

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(-15)]
        public static void FindNextBiggerNumber_NotValidCases(int number)
        => Assert.Throws<ArgumentException>(() => Operations.FindNextBiggerNumber(number));
    }
}
