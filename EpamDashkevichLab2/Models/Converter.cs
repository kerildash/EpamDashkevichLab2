using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamDashkevichLab2
{
    public static class Converter
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
            else
            {
                return binary;
            }
        }
    }
}
