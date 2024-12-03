using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Codewars
{
    public static class HowManyNumbers
    {
        public static long lowestNumber;
        public static long highestNumber;
        public static int n;

        public static void Scan(int remainingSum, int remainingDigits, string currentStr)
        {
            if (remainingDigits == 0)
            {
                if (remainingSum == 0)
                {
                    n++;
                    long x = long.Parse(currentStr);
                    if (lowestNumber == 0) lowestNumber = x;
                    highestNumber = x;
                }
            }
            else
            {
                int i;
                if (currentStr.Length == 0) i = 0;
                else i = int.Parse(currentStr.Substring(currentStr.Length - 1)) - 1;

                while ((++i <= remainingSum / remainingDigits) && (i < 10))
                {
                    Scan(remainingSum - i, remainingDigits - 1, currentStr + i.ToString());
                }
            }
        }

        public static List<long> FindAll(int sumDigits, int numDigits)
        {
            lowestNumber = 0;
            highestNumber = 0;
            n = 0;

            Scan(sumDigits, numDigits, "");

            List<long> l = new List<long>();
            if (n > 0)
            {
                l.Add(n);
                l.Add(lowestNumber);
                l.Add(highestNumber);
            }
            return l;
        }
    }
}
