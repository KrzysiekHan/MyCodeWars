using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
    public static class _8KYU
    {



        /*Write a function that takes in a string of one or more words, and returns the same string, but with all five or more 
         letter words reversed (Just like the name of this Kata). 
         Strings passed in will consist of only letters and spaces. Spaces will be included only when more than one word is present.*/
        public static string SpinWords(string sentence)
        {
            string[] words = { };
            words = sentence.Split(new char[0]);

            string response = "";
            int i = 0;
            foreach (var item in words)
            {
                if (item.Length > 4)
                {
                    char[] newWord = item.ToCharArray();
                    Array.Reverse(newWord);
                    response += new string(newWord);
                }
                else
                {
                    response += item;
                }
                i++;
                if (i < words.Length)
                {
                    response = response + " ";
                }
                else
                {
                    response += "";
                }
            }
            return response;
        }


        /*In mathematics, the factorial of a non-negative integer n, denoted by n!, is the product of all positive integers less than or equal to n. 
         For example: 5! = 5 * 4 * 3 * 2 * 1 = 120. By convention the value of 0! is 1.
         Write a function to calculate factorial for a given input. If input is below 0 or above 12 throw an exception of type ArgumentOutOfRangeException (C#) */
        public static int Factorial(int n)
        {
            int response = n;
            if (n < 0 || n > 12) throw new ArgumentOutOfRangeException();
            if (n == 0) return 1;
            for (int i = n - 1; i > 0; i--)
            {
                response = response * i;
            }
            return response;
        }


        //In this little assignment you are given a string of space separated numbers, and have to return the highest and lowest number.
        public static string HighAndLow(string numbers)
        {
            List<int> lista = new List<int>();
            foreach (string item in numbers.Split(new char[0]))
            {
                lista.Add(Int32.Parse(item));
            }
            return lista.Max().ToString() + " " + lista.Min().ToString();
        }
    }
}
