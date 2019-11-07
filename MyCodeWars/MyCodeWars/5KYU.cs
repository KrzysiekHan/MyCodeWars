using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MyCodeWars.Program;

namespace MyCodeWars
{
    public static class _5KYU
    {
        //Your task is to sort a given string. Each word in the string will contain a single number.This number is the position the word should have in the result.
        //Note: Numbers can be from 1 to 9. So 1 will be the first word (not 0).
        //If the input string is empty, return an empty string. The words in the input String will only contain valid consecutive numbers.
        //Examples
        //"is2 Thi1s T4est 3a"  -->  "Thi1s is2 3a T4est"
        //"4of Fo1r pe6ople g3ood th5e the2"  -->  "Fo1r the2 g3ood 4of th5e pe6ople"
        //""  -->  ""
        public static string Order(string words)
        {
            var wordlist = words.Split(' ');
            Dictionary<int,string> keyValuePairs = new Dictionary<int, string>();
            foreach (var item in wordlist)
            {
                keyValuePairs.Add(item.Where(x=>char.IsDigit(x));
            }
            throw new NotImplementedException();
        }

        //Some numbers have funny properties.For example:
        //89 --> 8¹ + 9² = 89 * 1
        //695 --> 6² + 9³ + 5⁴= 1390 = 695 * 2
        //46288 --> 4³ + 6⁴+ 2⁵ + 8⁶ + 8⁷ = 2360688 = 46288 * 51
        //Given a positive integer n written as abcd... (a, b, c, d... being digits) and a positive integer p
        //we want to find a positive integer k, if it exists, such as the sum of the digits of n taken to the successive powers of p is equal to k* n.
        //In other words:
        //Is there an integer k such as : (a ^ p + b ^ (p+1) + c ^(p+2) + d ^ (p+3) + ...) = n* k
        //If it is the case we will return k, if not return -1.
        //Note: n and p will always be given as strictly positive integers.
        //digPow(89, 1) should return 1 since 8¹ + 9² = 89 = 89 * 1
        //digPow(92, 1) should return -1 since there is no k such as 9¹ + 2² equals 92 * k
        //digPow(695, 2) should return 2 since 6² + 9³ + 5⁴= 1390 = 695 * 2
        //digPow(46288, 3) should return 51 since 4³ + 6⁴+ 2⁵ + 8⁶ + 8⁷ = 2360688 = 46288 * 51
        //  CLEVER  -----------------------------------------------
        //var sum = Convert.ToInt64(n.ToString().Select(s => Math.Pow(int.Parse(s.ToString()), p++)).Sum());
        //return sum % n == 0 ? sum / n : -1;
        public static long digPow(int n, int p)
        {
            // (a ^ p + b ^ (p+1) + c ^(p+2) + d ^ (p+3) + ...) = n*k
            string test = n.ToString();
            double sum = 0;
            for (int i = 0; i < test.Length; i++)
            {
                sum += Math.Pow(double.Parse(test[i].ToString()), p + i);
            }
            double result = sum / n;        
            bool isInteger = (result == Math.Truncate(result));
            if (isInteger)
            {
                return (long)result;
            }
            return -1;
        }

        //As the name may already reveal, it works basically like a Fibonacci, but summing the last 3 (instead of 2) numbers of the sequence to generate the next.And, worse part of it, regrettably I won't get to hear non-native Italian speakers trying to pronounce it :(
        //So, if we are to start our Tribonacci sequence with [1, 1, 1] as a starting input (AKA signature), we have this sequence:
        //[1, 1 ,1, 3, 5, 9, 17, 31, ...]
        //But what if we started with[0, 0, 1] as a signature? As starting with[0, 1] instead of[1, 1] basically shifts the common Fibonacci sequence by once place, you may be tempted to think that we would get the same sequence shifted by 2 places, but that is not the case and we would get:
        //[0, 0, 1, 1, 2, 4, 7, 13, 24, ...]
        //Well, you may have guessed it by now, but to be clear: you need to create a fibonacci function that given a signature array/list, returns the first n elements - signature included of the so seeded sequence.
        //Signature will always contain 3 numbers; n will always be a non-negative number; if n == 0, then return an empty array(except in C return NULL) and be ready for anything else which is not clearly specified ;)
        //NOT SOLVED
        public static double[] Tribonacci(double[] s, int n)
        {
            double[] res = new double[n];
            Array.Copy(s, res, Math.Min(3, n));

            for (int i = 3; i < n; i++)
                res[i] = res[i - 3] + res[i - 2] + res[i - 1];

            return n == 0 ? new double[] { 0 } : res;
        }

        //Count the number of Duplicates
        //Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more 
        //than once in the input string. The input string can be assumed to contain only alphabets(both uppercase and lowercase) and numeric digits.
        //Example
        //"abcde" -> 0 # no characters repeats more than once
        //"aabbcde" -> 2 # 'a' and 'b'
        //"aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)
        //"indivisibility" -> 1 # 'i' occurs six times
        //"Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
        //"aA11" -> 2 # 'a' and '1'
        //"ABBA" -> 2 # 'A' and 'B' each occur twice
        public static int DuplicateCount(string str)
        {

            var resp = str.ToLower().GroupBy(x => x).Where(d => d.Count() > 1).Count();
            return resp;
        }

        //You are going to be given an array of integers.Your job is to take that array and find an index N where the sum of the integers to the left of N is equal to the sum of the integers to the right of N. If there is no index that would make this happen, return -1.
        //For example:
        //Let's say you are given the array {1,2,3,4,3,2,1}:
        //Your function will return the index 3, because at the 3rd position of the array, the sum of left side of the index ({ 1,2,3}) and the sum of the right side of the index({ 3,2,1}) both equal 6.
        //Let's look at another one.
        //You are given the array {1,100,50,-51,1,1}:
        //Your function will return the index 1, because at the 1st position of the array, the sum of left side of the index({ 1}) and the sum of the right side of the index({ 50,-51,1,1}) both equal 1.
        //Last one:
        //You are given the array {20,10,-80,10,10,15,35}
        //At index 0 the left side is {}
        //The right side is {10,-80,10,10,15,35}
        //They both are equal to 0 when added. (Empty arrays are equal to 0 in this problem)
        //Index 0 is the place where the left side and right side are equal.
        //Note: Please remember that in most programming/scripting languages the index of an array starts at 0.
        //Input:
        //An integer array of length 0 < arr< 1000. The numbers in the array can be any integer positive or negative.
        //Output:
        //The lowest index N where the side to the left of N is equal to the side to the right of N.If you do not find an index that fits these rules, then you will return -1.
        //Note:
        //If you are given an array with multiple answers, return the lowest correct index.
        public static int FindEvenIndex(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int sumLeft = 0;
                int sumRight = 0;
                for (int k = 0; k < i; k++)
                {
                    sumLeft += arr[k];
                }
                for (int f = arr.Length-1; f > i; f--)
                {
                    sumRight += arr[f];
                }
                if (sumLeft == sumRight) return i;

            }
            return -1;
        }


        //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        //Finish the solution so that it returns the sum of all the multiples of 3 or 5 below the number passed in.
        //Note: If the number is a multiple of both 3 and 5, only count it once.
        //  CLEVER  -----------------------------------------------
        //return Enumerable.Range(0, n).Where(e => e % 3 == 0 || e % 5 == 0).Sum();
        public static int Solution(int value)
        {           
            int result = 0;
            for (int i = 0; i < value; i++)
            {
                if (i%3 == 0 && i%5 == 0)
                {
                    result += i;
                    continue;
                }
                if(i%3 == 0)
                {
                    result += i;
                }
                if (i%5 == 0)
                {
                    result += i;
                }
            }
            return result;

        }

        //Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence, which is the number 
        //of times you must multiply the digits in num until you reach a single digit.
        //For example:
        // persistence(39) == 3 // because 3*9 = 27, 2*7 = 14, 1*4=4
        //                      // and 4 has only one digit
        // persistence(999) == 4 // because 9*9*9 = 729, 7*2*9 = 126,
        //                       // 1*2*6 = 12, and finally 1*2 = 2
        // persistence(4) == 0 // because 4 is already a one-digit number
        //  CLEVER  -----------------------------------------------
        //int count = 0;
        //while (n > 9)
        //{
        //  count++;
        //  n = n.ToString().Select(digit => int.Parse(digit.ToString())).Aggregate((x, y) => x* y);
        //}
        //return count;
        public static int Persistence(long n)
        {
            int iterations = 0;
            while (n.ToString().Length > 1)
            {
                iterations++;
                long result = 1;
                foreach (var item in n.ToString())
                {
                    result = result * long.Parse(item.ToString());
                }
                n = result;
                  
            }
            return iterations;
            // your code
        }

        //Given an array, find the int that appears an odd number of times.
        //There will always be only one integer that appears an odd number of times.
        //  CLEVER  -----------------------------------------------
        //return seq.GroupBy(x => x).Single(g => g.Count() % 2 == 1).Key;
        public static int find_it(int[] seq)
        {
            foreach (var item in seq)
            {
                if(seq.Count(x => x == item)%2 == 1) return item;
            }
            return -1;   
        }
        //You have an amount of money a0 > 0 and you deposit it with a constant interest rate of p% > 0 per year on the 1st of January 2016. You want to have an amount a >= a0.
        //Task:
        //The function date_nb_days(or dateNbDays...) with parameters a0, a, p will return, as a string, the date on which you have just reached a.
        //Example:
        //date_nb_days(100, 101, 0.98) --> "2017-01-01" (366 days)
        //date_nb_days(100, 150, 2.00) --> "2035-12-26" (7299 days)
        //Notes:
        //The return format of the date is "YYYY-MM-DD"
        //The deposit is always on the "2016-01-01"
        //If p% is the rate for a year the rate for a day is p divided by 36000 since banks consider that there are 360 days in a year.
        //You have: a0 > 0, p% > 0, a >= a0
        //  CLEVER  -----------------------------------------------
        //public static string DateNbDays(double a0, double a, double p) => (new DateTime(2016, 1, 1) + TimeSpan.FromDays(Math.Log(a / a0, 1 + p / 36000) + 1)).ToString("yyyy-MM-dd");
        public static String DateNbDays(double a0, double a, double p)
        {
            int days = 0;
            while (a0<a)
            {
                a0 = a0 + a0 * (p / 36000);
                days++;
            }
            DateTime dt = new DateTime(2016, 1, 1);
            DateTime result =  dt.AddDays(days);
            return result.ToString("yyyy-MM-dd");
            // your code
        }

        //  Mexican Wave
        //  Task
        //  In this simple Kata your task is to create a function that turns a string into a Mexican Wave.You will be passed a string and you must return that string in an array where an uppercase letter is a person standing up.
        //  Rules
        //  1.  The input string will always be lower case but maybe empty.
        //  2.  If the character in the string is whitespace then pass over it as if it was an empty seat.
        //  Example
        //  wave("hello") => []string{"Hello", "hEllo", "heLlo", "helLo", "hellO"
        //  CLEVER  -----------------------------------------------
        //str
        //.Select((c, i) => str.Substring(0,i) + Char.ToUpper(c) + str.Substring(i+1))
        //.Where(x => x != str)
        //.ToList();
        public static List<string> wave(string str)
        {
            str = str.Trim();
            List<string> response = new List<string>();
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if(!str[i].Equals(' '))
                    {                    
                        str = str.ToLower();
                        str = str.Insert(i, char.ToUpper(str[i]).ToString()).Remove(i + 1, 1);
                        response.Add(str);
                    }
                }
            }
            return response;
        }


        //Huge factorial
        public static void factorial(int n)
            {
                int[] res = new int[500];
                res[0] = 1;
                int res_size = 1;
                for (int x = 2; x <= n; x++)
                    res_size = multiply(x, res,
                                        res_size);
                for (int i = res_size - 1; i >= 0; i--)
                    Console.Write(res[i]);
            }

            static int multiply(int x, int[] res,
                                int res_size)
            {
                int carry = 0; // Initialize carry 
                for (int i = 0; i < res_size; i++)
                {
                    int prod = res[i] * x + carry;
                    res[i] = prod % 10; // Store last digit of  
                                        // 'prod' in res[] 
                    carry = prod / 10; // Put rest in carry 
                }
                while (carry != 0)
                {
                    res[res_size] = carry % 10;
                    carry = carry / 10;
                    res_size++;
                }
                return res_size;
            }

        //You are given a binary tree:
        //public class Node
        //{
        //    public Node Left;
        //    public Node Right;
        //    public int Value;

        //    public Node(Node l, Node r, int v)
        //    {
        //        Left = l;
        //        Right = r;
        //        Value = v;
        //    }
        //}
        //Your task is to return the list with elements from tree sorted by levels, which means the root element 
        //goes first, then root children(from left to right) are second and third, and so on.
        //Return empty list if root is 'null'.
        //Example 1 - following tree:

        //         2
        //    8        9
        //  1  3     4   5
        //Should return following list:
        //       [2,8,9,1,3,4,5]
        //Example 2 - following tree:
        //                 1
        //            8        4
        //              3        5
        //                         7
        //Should return following list:
        //       [1,8,4,3,5,7]


        public static List<int> TreeByLevels(Node node)
        {
            List<int> response = new List<int>();

            return response;
        }
        //public static void DisplayTree(Node root, out List<int> response)
        //{
        //    if (root == null) return;
        //}
    

        //If we were to set up a Tic-Tac-Toe game, we would want to know whether the board's current state is solved, wouldn't we? 
        //Our goal is to create a function that will check that for us!
        //Assume that the board comes in the form of a 3x3 array, where the value is 0 if a spot is empty, 1 if it is an "X", or 2 if it is an "O", like so:
        //[[0, 0, 1],
        // [0, 1, 2],
        // [2, 1, 0]]
        //We want our function to return:
        //-1 if the board is not yet finished(there are empty spots),
        //1 if "X" won,
        //2 if "O" won,
        //0 if it's a cat's game(i.e.a draw).
        //You may assume that the board passed in is valid in the context of a game of Tic-Tac-Toe.
        public static int IsSolved(int[,] board)
        {
            List<results> resultsList = new List<results>();
            for (int i = 0; i <= 2; i++)
            {
                resultsList.Add(checkRow(getRowFromArray(board, i)));
                resultsList.Add(checkRow(getColumnFromArray(board, i)));
            }
            resultsList.Add(checkRow(getCross1FromArray(board)));
            resultsList.Add(checkRow(getCross2FromArray(board)));
            if (resultsList.Contains(results.X))
            {
                return 1;
            }
            if (resultsList.Contains(results.O))
            {
                return 2;
            }
            if (resultsList.All(s => s == results.Draw))
            {
                return 0;
            }
            return -1;
        }
        public enum results { UNKNOWN = 0,X,O,EmptySpots,Draw}

        private static results checkRow(int[] row)
        {
            results result = results.UNKNOWN;
            int first = row[0];
            if (row.All(s => int.Equals(first, s)))
            {
                if (first == 1) result = results.X;
                if (first == 2) result = results.O;
            }
            if (row.Contains(1) && row.Contains(2)) result = results.Draw;
            if (row.Count(s => s == 0) > 0) result = results.EmptySpots;
            return result;
        }

        private static int[] getRowFromArray(int[,] dim, int num)
        {
            int[] response = new int[3];
            response[0] = dim[num, 0];
            response[1] = dim[num, 1];
            response[2] = dim[num, 2];
            return response;
        }
        private static int[] getColumnFromArray(int[,] dim, int num)
        {
            int[] response = new int[3];
            response[0] = dim[0, num];
            response[1] = dim[1, num];
            response[2] = dim[2, num];
            return response;
        }

        private static int[] getCross1FromArray(int[,] dim)
        {
            int[] response = new int[3];
            response[0] = dim[0, 0];
            response[1] = dim[1, 1];
            response[2] = dim[2, 2];
            return response;
        }

        private static int[] getCross2FromArray(int[,] dim)
        {
            int[] response = new int[3];
            response[0] = dim[0,2];
            response[1] = dim[1,1];
            response[2] = dim[2,0];
            return response;
        }

        //In John's car the GPS records every s seconds the distance travelled from an origin 
        //(distances are measured in an arbitrary but consistent unit). For example, below is part of a record with s = 15:
        //x = [0.0, 0.19, 0.5, 0.75, 1.0, 1.25, 1.5, 1.75, 2.0, 2.25]
        //The sections are:
        //0.0-0.19, 0.19-0.5, 0.5-0.75, 0.75-1.0, 1.0-1.25, 1.25-1.50, 1.5-1.75, 1.75-2.0, 2.0-2.25
        //We can calculate John's average hourly speed on every section and we get:
        //[45.6, 74.4, 60.0, 60.0, 60.0, 60.0, 60.0, 60.0, 60.0]
        //Given s and x the task is to return as an integer the* floor* of the maximum average speed per 
        //hour obtained on the sections of x.If x length is less than or equal to 1 return 0 since the car didn't move.
        //with the above data your function gps(s, x)should return 74
        //With floats it can happen that results depends on the operations order.To calculate hourly speed you can use:
        //(3600 * delta_distance) / s.
        //  CLEVER  -----------------------------------------------
        //if(x.Length > 2)
        //{
        //  var averageSpeeds = x.Skip(1).Select((distance, index) => ((distance - x[index]) / s) * 3600);
        //  return Convert.ToInt32(Math.Floor(averageSpeeds.Max()));
        //}
        //return 0;

        public static int Gps(int s, double[] x)
        {
            if (x.Length == 0) return 0;
            int[] speed = new int[x.Length];
            for (int i = 1; i < x.Length; i++)
            {
                speed[i] = (int)Math.Floor((3600 * (x[i] - x[i - 1])) / s);
            }
            
            return speed.Max();
        }


    }
}
