using System;

namespace Test
{
    class Converter
    {
        public static string IntToBinary(int number)
        {
            string binary = "";
            return IntToBinary(number, binary);
        }
        private static string IntToBinary(int number, string binary)
        {
            int binaryDigit = number % 2;
            number = number / 2;
            binary = binaryDigit + binary;
            if (number > 0)
            {
                return IntToBinary(number, binary);
            }
            return binary;
        }
    }
    class Program
    {
        public static double FindRootNewton(int rootBase, double number, int approximation, int precisionPow)
        {
            double precision = Math.Pow(10, precisionPow);
            double x0 = approximation;
            double x1;
            while (true)
            {
                x1 = (1 /(double)rootBase) * ((double)(rootBase - 1) * x0 + number / Math.Pow(x0, rootBase - 1));
                if (Math.Abs(x1 - x0) < precision)
                {
                    break;
                }
                else
                {
                    x0 = x1;
                }
            }
            return x1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Converter.IntToBinary(6));
        }
    }
}
