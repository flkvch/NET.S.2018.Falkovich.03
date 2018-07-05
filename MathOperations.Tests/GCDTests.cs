using System;
using NUnit.Framework;
using MathOperations;
using System.Diagnostics;

namespace MathOperations.Tests
{
    [TestFixture]
    public class GCDTests
    {
        #region Euclidian's method
        [TestCase(25, 50, ExpectedResult = 25)]
        [TestCase(50, 25, ExpectedResult = 25)]
        [TestCase(25, 1, ExpectedResult = 1)]
        [TestCase(120, 50, ExpectedResult = 10)]
        [TestCase(-25, 50, ExpectedResult = 25)]
        [TestCase(17, 7, ExpectedResult = 1)]
        [TestCase(0, 50, ExpectedResult = 50)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(55, 55, ExpectedResult = 55)]
        [TestCase(1_000_000, 3_333_333, ExpectedResult = 1)]
        public static int FindGCD_TwoNumbers(int a, int b) => GCD.FindGCD(a, b);

        [TestCase(25, 50, 100, ExpectedResult = 25)]
        [TestCase(120, 50, 3, ExpectedResult = 1)]
        [TestCase(-25, 50, -100, ExpectedResult = 25)]
        [TestCase(25, 0, 50, ExpectedResult = 25)]
        [TestCase(47, 7, 3, ExpectedResult = 1)]
        [TestCase(1_000_000, 3_333_333, 2_222_222, ExpectedResult = 1)]
        public static int FindGCD_ThreeNumbers(int a, int b, int c)
        => GCD.FindGCD(a,b,c);


        [TestCase(25, 50, 100, 1000, ExpectedResult = 25)]
        [TestCase(120, 50, 3, 7, ExpectedResult = 1)]
        [TestCase(-25, 50, -100, -25, ExpectedResult = 25)]
        [TestCase(25, 0, 50, 0, ExpectedResult = 25)]
        [TestCase(47, 7, 3, 51, ExpectedResult = 1)]
        [TestCase(1_000_000, 3_333_333, 2_222_222, 7_777_777, ExpectedResult = 1)]
        public static int FindGCD_Array(params int[] array)
        => GCD.FindGCD(array);

        [TestCase]
        public static void FindGCD_BigArray(params int[] array)
        => Assert.AreEqual( GCD.FindGCD(GenArray(int.MaxValue / 10_000)), 1);
        
        [TestCase(15)]
        public static void FindGCD_OneNumber(params int[] array)
        => Assert.Throws<ArgumentException>(() => GCD.FindGCD(array));
        #endregion

        #region Stein's method
        [TestCase(25, 50, ExpectedResult = 25)]
        [TestCase(50, 25, ExpectedResult = 25)]
        [TestCase(25, 1, ExpectedResult = 1)]
        [TestCase(120, 50, ExpectedResult = 10)]
        [TestCase(-25, 50, ExpectedResult = 25)]
        [TestCase(17, 7, ExpectedResult = 1)]
        [TestCase(0, 50, ExpectedResult = 50)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(55, 55, ExpectedResult = 55)]
        [TestCase(1_000_000, 3_333_333, ExpectedResult = 1)]
        public static int FindGCDBinary_TwoNumbers(int a, int b) 
            => GCD.FindGCDBinary(a, b);

        [TestCase(25, 50, 100, ExpectedResult = 25)]
        [TestCase(120, 50, 3, ExpectedResult = 1)]
        [TestCase(-25, 50, -100, ExpectedResult = 25)]
        [TestCase(25, 0, 50, ExpectedResult = 25)]
        [TestCase(47, 7, 3, ExpectedResult = 1)]
        [TestCase(1_000_000, 3_333_333, 2_222_222, ExpectedResult = 1)]
        public static int FindGCDBinary_ThreeNumbers(int a, int b, int c)
        => GCD.FindGCD(a, b, c);

        [TestCase(25, 50, 100, 1000, ExpectedResult = 25)]
        [TestCase(120, 50, 3, 7, ExpectedResult = 1)]
        [TestCase(-25, 50, -100, -25, ExpectedResult = 25)]
        [TestCase(25, 0, 50, 0, ExpectedResult = 25)]
        [TestCase(47, 7, 3, 51, ExpectedResult = 1)]
        public static int FindGCDBinary_Array(params int[] array)
        => GCD.FindGCD(array);

        [TestCase]
        public static void FindGCDBinary_BigArray(params int[] array)
        => Assert.AreEqual(GCD.FindGCDBinary(GenArray(int.MaxValue / 10_000)), 1);
        #endregion

        [TestCase(0, 25, 50, 100, ExpectedResult = 25)]
        [TestCase(0, 120, 50, 3, ExpectedResult = 1)]
        [TestCase(0, -25, 50, -100, ExpectedResult = 25)]
        [TestCase(0, 25, 0, 50, ExpectedResult = 25)]
        [TestCase(0, 47, 7, 3, ExpectedResult = 1)]
        public static int FindGCD_ArrayOutTime(out int time, params int[] array)
        {
            int a = GCD.FindGCD(out time, array);
            Console.WriteLine(time);
            return a;
        }

        [TestCase(0, 25, 50, 100, ExpectedResult = 25)]
        [TestCase(0, 120, 50, 3, ExpectedResult = 1)]
        [TestCase(0, -25, 50, -100, ExpectedResult = 25)]
        [TestCase(0, 25, 0, 50, ExpectedResult = 25)]
        [TestCase(0, 47, 7, 3, ExpectedResult = 1)]
        public static int FindGCDBinary_ThreeNumbersOutTime(out int time, params int[] array)
        {
            int a = GCD.FindGCDBinary(out time, array);
            Console.WriteLine(time);
            return a;
        }

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
