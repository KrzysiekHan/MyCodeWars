using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
    public static class _7KYU
    {
        //You will be given a number and you will need to return it as a string in Expanded Form.For example:
        //Kata.ExpandedForm(12); # Should return "10 + 2"
        //Kata.ExpandedForm(42); # Should return "40 + 2"
        //Kata.ExpandedForm(70304); # Should return "70000 + 300 + 4"
        public static string ExpandedForm(long num)
        {
            string number = num.ToString();
            int len = number.Length;
            string result = "";
            string zeros = "";
            for (int i = len; i > 0; i--)
            {
                var item = number.Substring((number.Length - i), 1);
                if (item.Equals("0")) continue;
                for (int k = 1; k < i; k++)
                {
                    zeros += "0";
                }
                var temp = item + zeros +  " + " ;
                result += temp;
                zeros = "";
            }
            return result.Substring(0, result.Length - 3);
        }

        //You are given an array(which will have a length of at least 3, but could be very large) containing integers.
        //The array is either entirely comprised of odd integers or entirely comprised of even integers except for a 
        //single integer N. Write a method that takes the array as an argument and returns this "outlier" N.
        //Examples
        //[2, 4, 0, 100, 4, 11, 2602, 36]
        //Should return: 11 (the only odd number)
        //[160, 3, 1719, 19, 11, 13, -21]
        //Should return: 160 (the only even number)
        //  CLEVER  -----------------------------------------------
        //return integers.GroupBy(c=> c%2).First(c=>c.Count() == 1).First();
        public static int Find(int[] integers)
        {
            var evencount = integers.Where(x => x % 2 == 0).Count();
            var oddcount = integers.Where(x => x % 2 != 0).Count();
            var result = evencount > oddcount ? integers.Where(x => x % 2 != 0).Single() : integers.Where(x => x % 2 == 0).Single();
            return (int)result;
        }

        //Given two arrays of strings a1 and a2 return a sorted array r in lexicographical order of the strings of a1 which are substrings of strings of a2.
        //#Example 1: a1 = ["arp", "live", "strong"]
        //a2 = ["lively", "alive", "harp", "sharp", "armstrong"]
        //returns ["arp", "live", "st
        //  CLEVER  -----------------------------------------------
        //public static string[] inArray(string[] array1, string[] array2)
        //{
        //    return array1.Distinct()
        //                 .Where(s1 => array2.Any(s2 => s2.Contains(s1)))
        //                 .OrderBy(s => s)
        //                 .ToArray();
        //}
        public static string[] inArray(string[] array1, string[] array2)
        {

            List<string> result = new List<string>();

            foreach (var item in array1)
            {
                foreach (var itemx in array2)
                {
                    if ((itemx.IndexOf(item) != -1) && (!result.Contains(item)))
                    {
                        result.Add(item);
                    }
                }
            }
            result.Sort();
            return result.ToArray();
        }

        //MorseCodeDecoder.Decode(".... . -.--   .--- ..- -.. .")
        //should return "HEY JUDE"
        public static string Decode(string morseCode)
        {
            morseCode = morseCode.Trim();
           var wordlist = morseCode.Split(' ').ToList();
            string result = "";
            foreach (var item in wordlist)
            {
                if (item.Equals("...---...")) {
                    result += "SOS";
                    continue;
                }
                
                    if (string.IsNullOrEmpty(result))
                {
                    result += TranslateMorseChar(item);
                }
                else
                {
                    if (!(result[result.Length - 1] == ' ' && TranslateMorseChar(item) == " "))
                    {
                        result += TranslateMorseChar(item);
                    }
                }               
            }
            return result.ToUpper().Trim();

        }
        private static string TranslateMorseChar(string morseChar)
        {
             Dictionary<char, string> _morseAlphabetDictionary = new Dictionary<char, string>()
                                   {
                                       {'a', ".-"},
                                       {'b', "-..."},
                                       {'c', "-.-."},
                                       {'d', "-.."},
                                       {'e', "."},
                                       {'f', "..-."},
                                       {'g', "--."},
                                       {'h', "...."},
                                       {'i', ".."},
                                       {'j', ".---"},
                                       {'k', "-.-"},
                                       {'l', ".-.."},
                                       {'m', "--"},
                                       {'n', "-."},
                                       {'o', "---"},
                                       {'p', ".--."},
                                       {'q', "--.-"},
                                       {'r', ".-."},
                                       {'s', "..."},
                                       {'t', "-"},
                                       {'u', "..-"},
                                       {'v', "...-"},
                                       {'w', ".--"},
                                       {'x', "-..-"},
                                       {'y', "-.--"},
                                       {'z', "--.."},
                                       {'0', "-----"},
                                       {'1', ".----"},
                                       {'2', "..---"},
                                       {'3', "...--"},
                                       {'4', "....-"},
                                       {'5', "....."},
                                       {'6', "-...."},
                                       {'7', "--..."},
                                       {'8', "---.."},
                                       {'9', "----."},
                                       {'!',"-.-.--"}
                                   };
            if (!string.IsNullOrEmpty(morseChar))
            {
                var item = _morseAlphabetDictionary.Where(x => x.Value == morseChar).Single();
                return item.Key.ToString();
            }
            else return " ";              
        }

        //If a = 1, b = 2, c = 3... z = 26
        //Then l + o + v + e = 54
        //and f + r + i + e + n + d + s + h + i + p = 108
        //So friendship is twice stronger than love :-)
        //The input will always be in lowercase and never be empty.
        //  CLEVER  -----------------------------------------------
        //public static int WordsToMarks(string str) => str.Sum(v => v - 96);
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
