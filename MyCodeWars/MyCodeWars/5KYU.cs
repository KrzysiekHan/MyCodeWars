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
        //Unique In Order
        //Implement the function unique_in_order which takes as argument a sequence and returns a list of items without 
        //any elements with the same value next to each other and preserving the original order of elements.
        //For example:
        //uniqueInOrder("AAAABBBCCDAABBB") == {'A', 'B', 'C', 'D', 'A', 'B'}
        //uniqueInOrder("ABBCcAD")         == {'A', 'B', 'C', 'c', 'A', 'D'}
        //uniqueInOrder([1,2,2,3,3])       == {1,2,3}
        //  CLEVER  -----------------------------------------------
        //T previous = default(T);
        //foreach (T current in iterable)
        //{
        //    if (!current.Equals(previous))
        //    {
        //        previous = current;
        //        yield return current;
        //    }
        //}

        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            var list = iterable.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (i + 1 == list.Count) break;
                if (list[i].Equals(list[i + 1]))
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            return list;
        }
        //Welcome.
        //In this kata you are required to, given a string, replace every letter with its position in the alphabet.
        //If anything in the text isn't a letter, ignore it and don't return it.
        //"a" = 1, "b" = 2, etc.
        //Example
        //Kata.AlphabetPosition("The sunset sets at twelve o' clock.")
        //Should return "20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11" (as a string)
        public static string AlphabetPosition(string text)
        {
            var arr = text.Replace(" ", "").ToLower().ToCharArray();
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if((int)arr[i]>=97 && (int)arr[i] <= 122)
                {
                    result += ((int)arr[i] - 96) + " ";
                }             
            }
            return result;
        }

        //Directions Reduction
        //The directions given to the man are, for example, the following (depending on the language):
        //["NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"].
        //You can immediatly see that going "NORTH" and then "SOUTH" is not reasonable, better stay to the same place! So the task is to give 
        // to the man a simplified version of the plan.A better plan in this case is simply:
        //   ["WEST"]
        //    Other examples:
        //In["NORTH", "SOUTH", "EAST", "WEST"], the direction "NORTH" + "SOUTH" is going north and coming back right away.What a waste of time! Better to do nothing.
        //The path becomes["EAST", "WEST"], now "EAST" and "WEST" annihilate each other, therefore, the final result is [] (nil in Clojure).
        //In["NORTH", "EAST", "WEST", "SOUTH", "WEST", "WEST"], "NORTH" and "SOUTH" are not directly opposite but they become directly opposite after the reduction of "EAST" and "WEST" so the whole path is reducible to["WEST", "WEST"].
        //Task
        //Write a function dirReduc which will take an array of strings and returns an array of strings with the needless directions removed(W<->E or S<->N side by side).
        //Not all paths can be made simpler.The path["NORTH", "WEST", "SOUTH", "EAST"] is not reducible. "NORTH" and "WEST", "WEST" and "SOUTH", "SOUTH" 
        //and "EAST" are not directly opposite of each other and can't become such. Hence the result path is itself : ["NORTH", "WEST", "SOUTH", "EAST"].
        public static string[] dirReduc(String[] arr)
        {
            List<string> tempList = new List<string>();
            tempList = arr.ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList.Count == (i+1)) break;
                if (IsOpposite(tempList[i], tempList[i + 1]))
                {
                    tempList.RemoveAt(i);
                    tempList.RemoveAt(i);
                    i = -1;
                }
            }           
            return tempList.ToArray();
        }
        private static bool IsOpposite( string a, string b)
        {
            if (a.Equals("EAST") && b.Equals("WEST"))return true;
            if (a.Equals("WEST") && b.Equals("EAST")) return true;
            if (a.Equals("NORTH") && b.Equals("SOUTH")) return true;
            if (a.Equals("SOUTH") && b.Equals("NORTH")) return true;
            return false;
        }

        //Bob is preparing to pass IQ test.The most frequent task in this test is to find out which one of the given numbers 
        //differs from the others.Bob observed that one number usually differs from the others in evenness.Help Bob — to check 
        //his answers, he needs a program that among the given numbers finds one that is different in evenness, and return a position of this number.
        //Keep in mind that your task is to help Bob solve a real IQ test, which means indexes of the elements start from 1 (not 0)
        //##Examples :
        //IQ.Test("2 4 7 8 10") => 3 // Third number is odd, while the rest of the numbers are even
        //IQ.Test("1 2 1 1") => 2 // Second number is even, while the rest of the numbers are odd
        //  CLEVER  -----------------------------------------------
        //var ints = numbers.Split(' ').Select(int.Parse).ToList();
        //var unique = ints.GroupBy(n => n % 2).OrderBy(c => c.Count()).First().First();
        //return ints.FindIndex(c => c == unique) + 1;
        public static int Test(string numbers)
        {
            var table = numbers.Split(' ').ToArray();
            var even = table.Where(x => int.Parse(x) % 2 == 0).ToList();
            var odd = table.Where(x => int.Parse(x) % 2 != 0).ToList();
            if (even.Count > 1){
                return Array.IndexOf(table,odd[0])+1;
            }
            else
            {
                return Array.IndexOf(table, even[0]) + 1;
            }
        }

        //For example, a song with words "I AM X" can transform into a dubstep remix as "WUBWUBIWUBAMWUBWUBX" and cannot transform into "WUBWUBIAMWUBX".
        //Recently, Jonny has heard Polycarpus's new dubstep track, but since he isn't into modern music, he decided to 
        //find out what was the initial song that Polycarpus remixed.Help Jonny restore the original song.
        //Input
        //The input consists of a single non-empty string, consisting only of uppercase English letters, the string's length doesn't exceed 200 characters
        //Output
        //Return the words of the initial song that Polycarpus used to make a dubsteb remix.Separate the words with a space.
        //Examples
        //songDecoder("WUBWEWUBAREWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB")
        // =>  WE ARE THE CHAMPIONS MY FRIEND
        //  CLEVER  -----------------------------------------------
        //return Regex.Replace(input, "(WUB)+", " " ).Trim();
        public static string SongDecoder(string input)
        {
            var result = input.Replace("WUB", " ").ToString();
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            result = regex.Replace(result, " ");
            result = result.Trim();
            return result;
        }

        //You probably know the "like" system from Facebook and other pages.People can "like" blog posts, pictures or other items. We want to create 
        //the text that should be displayed next to such an item.
        //Implement a function likes :: [String] -> String, which must take in input array, containing the names of people who like an item.It must 
        //return the display text as shown in the examples:
        //Kata.Likes(new string[0]) => "no one likes this"
        //Kata.Likes(new string[] {"Peter"}) => "Peter likes this"
        //Kata.Likes(new string[] {"Jacob", "Alex"}) => "Jacob and Alex like this"
        //Kata.Likes(new string[] {"Max", "John", "Mark"}) => "Max, John and Mark like this"
        //Kata.Likes(new string[] {"Alex", "Jacob", "Mark", "Max"}) => "Alex, Jacob and 2 others like this"
        //For 4 or more names, the number in and 2 others simply increases.
        public static string Likes(string[] name)
        {
            switch (name.Length)
            {
                case 0:
                    return "no one likes this";
                case 1:
                    return name[0] + " likes this";
                case 2:
                    return name[0] + " and " + name[1] + " like this";
                case 3:
                    return name[0] + ", " + name[1] + " and " + name[2] + " like this";
                default:
                    return name[0] + ", " + name[1] + " and " + (name.Length - 2).ToString() + " others like this";
            };
            return "";
        }
        

        //Snail Sort
        //Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.
        //array = [[1,2,3],
        //         [4,5,6],
        //         [7,8,9]]
        //snail(array) #=> [1,2,3,6,9,8,7,4,5]
        //For better understanding, please follow the numbers of the next array consecutively:
        //array = [[1,2,3],
        //         [8,9,4],
        //         [7,6,5]]
        //snail(array) #=> [1,2,3,4,5,6,7,8,9]
        //This image will illustrate things more clearly:
        //NOTE: The idea is not sort the elements from the lowest value to the highest; the idea is to traverse the 2-d array in a clockwise snailshell pattern.
        //NOTE 2: The 0x0 (empty matrix) is represented as en empty array inside an array [[]].
        //  CLEVER  -----------------------------------------------
        //public static int[] Snail(int[][] array)
        //{
        //    int l = array[0].Length;
        //    int[] sorted = new int[l * l];
        //    Snail(array, -1, 0, 1, 0, l, 0, sorted);
        //    return sorted;
        //}
        //public static void Snail(int[][] array, int x, int y, int dx, int dy, int l, int i, int[] sorted)
        //{
        //    if (l == 0)
        //        return;
        //    for (int j = 0; j < l; j++)
        //    {
        //        x += dx;
        //        y += dy;
        //        sorted[i++] = array[y][x];
        //    }
        //    Snail(array, x, y, -dy, dx, dy == 0 ? l - 1 : l, i, sorted);
        //}

        public static int[] Snail(int[][] array)
        {
            if (array.Length == 1 && array[0].Length==0) return new int[] { };
            int m = array.GetLength(0);
            int n = m;
            var board = array;

            List<int> result = new List<int>() ;
            var dir = "right";
            var imin = 0;
            var imax = m - 1;
            var jmin = 0;
            var jmax = n - 1;
            var i = imin;
            var j = jmin;
            var done = false;

            while (!done)
            {

                switch (dir)
                {
                    case "right":
                        i = imin;
                        for (j = jmin; j <= jmax; j++)
                            result.Add(board[i][j]);
                        dir = "down";
                        imin++;
                        break;
                    case "left":
                        i = imax;                     
                        for (j = jmax; j >= jmin; j--)
                            result.Add(board[i][j]);
                        dir = "up";
                        imax--;
                        break;
                    case "down":
                      
                        j = jmax;
                        for (i = imin; i <= imax; i++)
                            result.Add(board[i][j]);
                        dir = "left";
                        jmax--;
                        break;
                    case "up":
                        
                        j = jmin;
                        for (i = imax; i >= imin; i--)
                            result.Add(board[i][j]);

                        dir = "right";
                        jmin++;
                        break;
                }
                if (imin > imax || jmin > jmax)
                    done = true;
            }
            return result.ToArray();
        }

        //The goal of this exercise is to convert a string to a new string where each character in the new string is "(" if that character appears 
        //only once in the original string, or ")" if that 
        //character appears more than once in the original string. Ignore capitalization when determining if a character is a duplicate.
        //Examples
        //"din"      =>  "((("
        //"recede"   =>  "()()()"
        //"Success"  =>  ")())())"
        //"(( @"     =>  "))((" 
        //Notes
        //Assertion messages may be unclear about what they display in some languages. If you 
        //read "...It Should encode XXX", the "XXX" is the expected result, not the input!
        //  CLEVER  -----------------------------------------------
        //return new string (word.ToLower().Select(ch => word.ToLower().Count(innerCh => ch == innerCh) == 1 ? '(' : ')').ToArray());
        public static string DuplicateEncode(string word)
        {
            word = word.ToLower();
            char[] response = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                if (word.Count(x => x == word[i]) > 1)
                {
                    response[i] = ')';
                } else
                {
                    response[i] = '(';
                } 
            }
            string sresp = new string(response);
            return sresp;
        }

        //Your task is to sort a given string. Each word in the string will contain a single number.This number is the position the word should have in the result.
        //Note: Numbers can be from 1 to 9. So 1 will be the first word (not 0).
        //If the input string is empty, return an empty string. The words in the input String will only contain valid consecutive numbers.
        //Examples
        //"is2 Thi1s T4est 3a"  -->  "Thi1s is2 3a T4est"
        //"4of Fo1r pe6ople g3ood th5e the2"  -->  "Fo1r the2 g3ood 4of th5e pe6ople"
        //""  -->  ""
        //  CLEVER  -----------------------------------------------
        //if (string.IsNullOrEmpty(words)) return words;
        //return string.Join(" ", words.Split(' ').OrderBy(s => s.ToList().Find(c => char.IsDigit(c))));
        public static string Order(string words)
        {
            if (String.IsNullOrEmpty(words)) return "";
            var wordlist = words.Split(' ');
            Dictionary<int,string> keyValuePairs = new Dictionary<int, string>();
            foreach (var item in wordlist)
            {
                keyValuePairs.Add(int.Parse(item.Where(x=>char.IsDigit(x)).Single().ToString()),item);
            }
            keyValuePairs = keyValuePairs.OrderBy(x => x.Key).ToDictionary(x=>x.Key,x=>x.Value);
            string response = "";
            foreach (var item in keyValuePairs)
            {
                response += item.Value + " ";
            }
            return response.Trim();

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
