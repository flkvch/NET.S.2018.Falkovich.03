using System;
using NUnit.Framework;
using static MathOperations.GCD;

namespace MathOperations.Tests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(25, 50, 100, 25, 25)]
        [TestCase(50, 25, 0, 25, 25)]
        [TestCase(25, 1, 0 , 1, 1)]
        [TestCase(120, 50, 3, 10, 1)]
        [TestCase(-25, 50, -100, 25, 25)]
        [TestCase(17, 7, 7, 1, 1)]
        [TestCase(0, 50, 27, 50, 1)]
        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(55, 55, 55, 55, 55)]
        [TestCase(1_000_000, 3_333_333, 2_222_222, 1, 1)]
        public static void FindGCD(int a, int b, int c, int expected2, int expected3)
        {
            if (FindGCDEuclidian(a,b) != expected2 || FindGCDEuclidian(a, b, c) != expected3 || FindGCDEuclidian(a, b, out _) != expected2 || FindGCDEuclidian(a, b, c, out _) != expected3)
            {
                Assert.Fail();
            }

            if (FindGCDBinary(a, b) != expected2 || FindGCDBinary(a, b, c) != expected3 || FindGCDBinary(a, b, out _) != expected2 || FindGCDBinary(a, b, c, out _) != expected3)
            {
                Assert.Fail();
            }
        }

        [TestCase(25, 50, 100, 1000, 25)]
        [TestCase(1, 120, 50, 3, 7)]
        [TestCase(25, -25, 50, -100, -25)]
        [TestCase(25, 0, 50, 0, 25)]
        [TestCase(1, 47, 7, 3, 51)]
        [TestCase(1, 1_000_000, 3_333_333, 2_222_222, 7_777_777)]
        public static void FindGCD_Array(int expected, params int[] array)
        {
            if (FindGCDEuclidian(array) != expected || FindGCDEuclidian(out _, array) != expected)
            {
                Assert.Fail();
            }

            if (FindGCDBinary(array) != expected || FindGCDBinary(out _, array) != expected)
            {
                Assert.Fail();
            }
        }

        public static void FindGCD_MaxValueArray(int expected, params int[] array)
        {
            if (FindGCDEuclidian(GenArray(int.MaxValue / 100_000)) != 1)
            {
                Assert.Fail();
            }

            if (FindGCDBinary(GenArray(int.MaxValue / 1000_000)) != 1)
            {
                Assert.Fail();
            }
        }

        [TestCase(15)]
        public static void FindGCD_OneNumber(params int[] array)
        => Assert.Throws<ArgumentException>(() => FindGCDEuclidian(array));

        #region Private
        private static int[] GenArray(int length)
        {
            int[] a = new int[length];
            for (int i = 1; i < a.Length; i++)
            {
                a[i] = i;
            }

            return a;
        }
        #endregion
    }
}