using System;
using NUnit.Framework;

namespace MathOperations.Tests
{
    [TestFixture]
    public class OperationsTests
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        public static double FindNthRoot_RootFromOne(double number, int n, double accuracy)
        => Operations.FindNthRoot(1, 5, 0.0001);

        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        public static double FindNthRoot_IntegerAnswer(double number, int n, double accuracy)
            => Operations.FindNthRoot(8, 3, 0.0001);

        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        public static double FindNthRoot_1(double number, int n, double accuracy)
            => Operations.FindNthRoot(0.001, 3, 0.0001);

        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        public static double FindNthRoot_2(double number, int n, double accuracy)
            => Operations.FindNthRoot(0.04100625, 4, 0.0001);

        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        public static double FindNthRoot_BigPower(double number, int n, double accuracy)
            => Operations.FindNthRoot(0.0279936, 7, 0.0001);

        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        public static double FindNthRoot_3(double number, int n, double accuracy)
            => Operations.FindNthRoot(0.0081, 4, 0.1);

        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        public static double FindNthRoot_FromNegative(double number, int n, double accuracy)
            => Operations.FindNthRoot(-0.008, 3, 0.1);

        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public static double FindNthRoot_BigAccuracy(double number, int n, double accuracy)
            => Operations.FindNthRoot(0.004241979, 9, 0.00000001);

        [Test]
        public void FindNthRoot_NegativeNumberEvenPow_Exception() =>
            Assert.Throws<ArgumentException>(() => Operations.FindNthRoot(-0.001, 2, 0.0001));

        [Test]
        public void FindNthRoot_NegativePow_Exception() =>
    Assert.Throws<ArgumentException>(() => Operations.FindNthRoot(0.001, -2, 0.0001));
        [Test]
        public void FindNthRoot_UncorrectAccuracy_Exception() =>
    Assert.Throws<ArgumentException>(() => Operations.FindNthRoot(0.001, 2, -1));
    }
}
