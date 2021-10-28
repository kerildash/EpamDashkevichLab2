using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EpamDashkevichLab2
{
    public static class MyMath
    {
        public static double DemoApproximation(int rootBase, double number)
        {
            //x0 = 1
            return 1 / (double)rootBase * (rootBase - 1 + number);
        }
        public static double FindRootNewton(int rootBase, double number, double approximation, int precisionPow)
        {
            double precision = Math.Pow(10, precisionPow);
            return FindRootNewton(rootBase, number, approximation, precision);
        }
        private static double FindRootNewton(int rootBase, double number, double x0, double precision)
        {
            double x1 = (1 / (double)rootBase) * ((rootBase - 1) * x0 + number / Math.Pow(x0, rootBase - 1));
            if (Math.Abs(x1 - x0) < precision)
            {
                return x1;
            }
            else
            {
                x0 = x1;
            }
            return FindRootNewton(rootBase, number, x0, precision);
        }
        
    }
}
