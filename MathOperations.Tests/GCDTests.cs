using System;
using NUnit.Framework;
using MathOperations;

namespace MathOperations.Tests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(25, 50, ExpectedResult = 25)]
        [TestCase(50, 25, ExpectedResult = 25)]
        [TestCase(25, 1, ExpectedResult = 1)]
        [TestCase(120, 50, ExpectedResult = 10)]
        [TestCase(-25, 50, ExpectedResult = 25)]
        [TestCase(17, 7, ExpectedResult = 1)]
        [TestCase(0, 50, ExpectedResult = 50)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(55, 55, ExpectedResult = 55)]
        public static int FindGCD_TwoNumbers(int a, int b) => GCD.FindGCD(a, b);

        [TestCase(25, 50, 100, ExpectedResult = 25)]
        [TestCase(120, 50, 3, ExpectedResult = 1)]
        [TestCase(-25, 50, -100, ExpectedResult = 25)]
        [TestCase(25, 0, 50, ExpectedResult = 25)]
        [TestCase(47, 7, 3, ExpectedResult = 1)]
        public static int FindGCD_ThreeNumbers(params int[] array)
        => GCD.FindGCD(array);

        [TestCase(25, 50, ExpectedResult = 25)]
        [TestCase(50, 25, ExpectedResult = 25)]
        [TestCase(25, 1, ExpectedResult = 1)]
        [TestCase(120, 50, ExpectedResult = 10)]
        [TestCase(-25, 50, ExpectedResult = 25)]
        [TestCase(17, 7, ExpectedResult = 1)]
        [TestCase(0, 50, ExpectedResult = 50)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(55, 55, ExpectedResult = 55)]
        public static int FindGCDBinary_TwoNumbers(int a, int b) => GCD.FindGCDBinary(a, b);

        [TestCase(25, 50, 100, ExpectedResult = 25)]
        [TestCase(120, 50, 3, ExpectedResult = 1)]
        [TestCase(-25, 50, -100, ExpectedResult = 25)]
        [TestCase(25, 0, 50, ExpectedResult = 25)]
        [TestCase(47, 7, 3, ExpectedResult = 1)]
        public static int FindGCDBinary_ThreeNumbers(params int[] array)
        => GCD.FindGCDBinary(array);
    }
}
