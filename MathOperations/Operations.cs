using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    public static class Operations
    {
        /// <summary>
        /// Accracy of calculating
        /// </summary>
        private const double X0 = 0.1;

        public static double FindNthRoot(double number, int n, double accuracy)
        {
            if (!IsValid(number, n, accuracy))
            {
                throw new ArgumentException();
            }

            double root = NewtonCalc(number, n, accuracy);
            return Round(root, accuracy);
        }

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
    }
}