using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    public static class Operations
    {
        #region API
        /// <summary>
        /// Initial approximation
        /// </summary>
        private const double X0 = 0.1;

        /// <summary>
        /// Finds root of n-th power of the number with the accuracy
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="n">
        /// The power
        /// </param>
        /// <param name="accuracy">
        /// The accuracy
        /// </param>
        /// <returns>
        /// The root
        /// </returns>
        public static double FindNthRoot(double number, int n, double accuracy)
        {
            if (!IsValid(number, n, accuracy))
            {
                throw new ArgumentException();
            }

            double root = NewtonCalc(number, n, accuracy);
            return Round(root, accuracy);
        }

       #endregion

        #region private

        /// <summary>
        /// Rounds double variable with the accuracy
        /// </summary>
        /// <param name="root">
        /// variable
        /// </param>
        /// <param name="accuracy">
        /// accuracy
        /// </param>
        /// <returns>
        /// Rounded variable
        /// </returns>
        private static double Round(double root, double accuracy)
        {
            int count = -1;
            while (accuracy < 10)
            {
                int digit = (int)accuracy;
                count++;
                accuracy *= 10;
            }

            return Math.Round(root, count);
        }

        /// <summary>
        /// Does the Newton Calculation of the root
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="n">
        /// The power
        /// </param>
        /// <param name="accuracy">
        /// The accuracy
        /// </param>
        /// <returns>
        /// The root
        /// </returns>
        private static double NewtonCalc(double number, int n, double accuracy)
        {
            double xk = X0, xkp1 = X0;
            for (;;)
            {
                xkp1 = 1.0 / n * ((n - 1) * xk + number / Math.Pow(xk, n - 1));
                if (Math.Abs(xkp1 - xk) > accuracy)
                {
                    xk = xkp1;
                }
                else
                {
                    break;
                }
            }

            return xkp1;
        }

        /// <summary>
        /// Checks parametrs to be valid
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="n">
        /// The power
        /// </param>
        /// <param name="accuracy">
        /// The accuracy
        /// </param>
        /// <returns>
        /// Validation
        /// </returns>
        private static bool IsValid(double number, int n, double accuracy)
        {
            if (n % 2 == 0)
            {
                if (number < 0)
                {
                    return false;
                }
            }

            if (n < 2)
            {
                    return false;
            }

            if (accuracy < 1 && accuracy > 0)
            {
                double temp = accuracy;
                while (temp < 10)
                {
                    int digit = (int)temp;
                    if (digit > 1)
                    {
                        return false;
                    }
                    else
                    {
                        temp *= 10;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}