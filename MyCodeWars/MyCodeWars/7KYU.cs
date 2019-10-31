using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
    public static class _7KYU
    {
        //If a = 1, b = 2, c = 3... z = 26
        //Then l + o + v + e = 54
        //and f + r + i + e + n + d + s + h + i + p = 108
        //So friendship is twice stronger than love :-)
        //The input will always be in lowercase and never be empty.
        public static int WordsToMarks(string str)
        {
            int suma = 0;
            foreach (char item in str)
            {
                suma += charToNumber(item);
            }
            return suma;
        }

        private static int charToNumber(char c)
        {
            char temp = c.ToString().ToUpper().ToCharArray().Single();
            int resp = (int)temp - 64;
            return resp;
        }
        // LOL!!! same could be wrote as   public static int WordsToMarks(string str) => str.Sum(v => v - 96);

        //The new "Avengers" movie has just been released! There are a lot of people at the cinema box office standing in a huge line.Each of them has a single 100, 50 or 25 dollar bill.An "Avengers" ticket costs 25 dollars.
        //Vasya is currently working as a clerk. He wants to sell a ticket to every single person in this line.
        //Can Vasya sell a ticket to every person and give change if he initially has no money and sells the tickets strictly in the order people queue?
        //Return YES, if Vasya can sell a ticket to every person and give change with the bills he has at hand at that moment.Otherwise return NO.
        //Line.Tickets(int[] {25, 25, 50}) // => YES 
        //Line.Tickets(new int[] {25, 100}) // => NO. Vasya will not have enough money to give change to 100 dollars
        //Line.Tickets(new int[] {25, 25, 50, 50, 100}) // => NO. Vasya will not have the right bills to give 75 dollars of change (you can't make two bills of 25 from one of 50)
        public static string Tickets(int[] peopleInLine)
        {
            int bill25count = 0;
            int bill50count = 0;
            int bill100count = 0;

            string result = "YES";
            foreach (var item in peopleInLine)
            {
                if (result.Equals("NO")) break;
                if (item == 25) {
                    bill25count++;
                } 
                if (item == 50)
                {
                    if (bill25count > 0)
                    {
                        bill25count--;
                        bill50count++;
                    }
                    else
                    {
                        result = "NO";
                    }
                }
                if (item == 100)
                {
                    if(bill25count>0 && bill50count>0)
                    {
                        bill25count--;
                        bill50count--;
                    }
                    else
                    {
                        result = "NO";
                    }
                }
            }


            return result;
        }

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
