using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
    public static class _7KYU
    {
        //In this kata, you must create a digital root function.
        //A digital root is the recursive sum of all the digits in a number. Given n, take the sum of the digits of n. If that value has more than one digit, continue reducing in this way until a single-digit number is produced.This is only applicable to the natural numbers.
        //digital_root(493193)
        //=> 4 + 9 + 3 + 1 + 9 + 3
        //=> 29 ...
        //=> 2 + 9
        //=> 11 ...
        //=> 1 + 1
        //=> 2
        public static int DigitalRoot(long n)
        {
            string result = "";
            result = n.ToString();

            while (result.Length > 1)
            {
               result = recursiveSum(result).ToString();
            }
            return int.Parse(result);
        }
        public static int recursiveSum (string inString)
        {       
            return inString.Select(m => int.Parse(m.ToString())).Sum();
        }
    }
}
