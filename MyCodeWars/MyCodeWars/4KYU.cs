using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCodeWars
{
    public static class _4KYU
    {
        //Convert string to camel case
        //Complete the method/function so that it converts dash/underscore delimited words into camel casing.
        //The first word within the output should be capitalized only if the original word was 
        //capitalized (known as Upper Camel Case, also often referred to as Pascal case).
        //Examples
        //Kata.ToCamelCase("the-stealth-warrior") // returns "theStealthWarrior"
        //Kata.ToCamelCase("The_Stealth_Warrior") // returns "TheStealthWarrior"
        public static string ToCamelCase(string str)
        {
            List<char> lista = new List<char>();
            lista = str.ToList();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '-' || str[i] == '_') {
                    //lista.RemoveAt(i);
                    lista[i+1] = char.ToUpper(lista[i+1]);
                }     
            }
            var resp = new string(lista.ToArray());
            resp = resp.Replace("-", "").Replace("_", "");
            return resp;
        }

        //Count the smiley faces!
        //Given an array(arr) as an argument complete the function countSmileys that should return the total number of smiling faces.
        //Rules for a smiling face:
        //-Each smiley face must contain a valid pair of eyes. Eyes can be marked as : or ;
        //-A smiley face can have a nose but it does not have to.Valid characters for a nose are - or ~
        //-Every smiling face must have a smiling mouth that should be marked with either ) or D.
        //No additional characters are allowed except for those mentioned.
        //Valid smiley face examples:
        //:) :D ;-D :~)
        //Invalid smiley faces:
        //;( :> :} :]
        //Example cases:
        //countSmileys([':)', ';(', ';}', ':-D']);       // should return 2;
        //countSmileys([';D', ':-(', ':-)', ';~)']);     // should return 3;
        //countSmileys([';]', ':[', ';*', ':$', ';-D']); // should return 1;
        //Note: In case of an empty array return 0. You will not be tested with invalid input(input will always be an array).
        //  CLEVER  -----------------------------------------------
        //return smileys.Count(s => Regex.IsMatch(s, @"^[:;]{1}[~-]{0,1}[\)D]{1}$"));
        public static int CountSmileys(string[] smileys)
        {
            int smileyCount = 0;
            foreach (var item in smileys)
            {
                Console.WriteLine(item);
                if (IsSmiley(item)) smileyCount++;
            }
            Console.WriteLine("---------");
            return smileyCount;
        }
        private static bool IsSmiley(string item)
        {
            string pattern = "[:;][~-]{0,1}[)D]";
            if (Regex.Match(item, pattern).Success) return true;
            return false;
        }

        //Delete occurrences of an element if it occurs more than n times
        //Task
        //Given a list lst and a number N, create a new list that contains each number of lst at most N times without
        //reordering.For example if N = 2, and the input is [1,2,3,1,2,1,2,3], you take[1, 2, 3, 1, 2], drop the next[1, 2] since this would 
        //lead to 1 and 2 being in the result 3 times, and then take 3, which leads to[1, 2, 3, 1, 2, 3].
        //Example
        //Kata.DeleteNth (new int[] {20,37,20,21}, 1) // return [20,37,21]
        //Kata.DeleteNth(new int[] {1,1,3,3,7,2,2,2,2}, 3) // return [1, 1, 3, 3, 7, 2, 2, 2]
        public static int[] DeleteNth(int[] arr, int x)
        {
            Dictionary<int, int> usageCounter = new Dictionary<int, int>();
            List<int> responseList = new List<int>(); 
            foreach (var item in arr)
            {
                if (!usageCounter.ContainsKey(item))
                {
                    usageCounter.Add(item, 1);
                }
                else
                {
                    usageCounter[item] += 1;             
                }
                if (usageCounter[item] <= x)
                {
                    responseList.Add(item);
                }
            }
            return responseList.ToArray();
        }


        //Write a function called that takes a string of parentheses, and determines if the order of the parentheses is valid.
        //The function should return true if the string is valid, and false if it's invalid.
        //Examples
        //"()"              =>  true
        //")(()))"          =>  false
        //"("               =>  false
        //"(())((()())())"  =>  true
        //Constraints
        //0 <= input.length <= 100
        //Along with opening(() and closing ()) parenthesis, input may contain any valid ASCII characters.Furthermore, the input 
        //string may be empty and/or not contain any parentheses at all.Do not treat other forms of brackets as parentheses(e.g. [], { }, <>).
        //  CLEVER  -----------------------------------------------
        //int c = 0;
        //return !input.Select(i => c += i == '(' ? 1 : i == ')' ? -1 : 0).Any(i => i< 0) && c == 0;
        public static bool ValidParentheses(string input)
        {
          string cleaned = string.Join("",
                            from ch in input
                            where ch =='(' || ch == ')'
                            select ch);
            string bracesNew = cleaned;
            string bracesOld = "";
            while (bracesNew != bracesOld)
            {
                bracesOld = bracesNew;
                for (int i = 0; i < bracesNew.Length - 1; i++)
                {
                    if (IsPaired(bracesNew[i], bracesNew[i + 1]))
                    {
                        bracesNew = bracesNew.Remove(i, 1);
                        bracesNew = bracesNew.Remove(i, 1);
                    }
                }
            }
            if (bracesNew.Length == 0) return true;
            return false;
        }

        public static bool IsPaired(char a, char b)
        {
            if (a == '(' && b == ')') return true;
            return false;
        }

        //Simple Encryption #1 - Alternating Split
        //For building the encrypted string:
        //Take every 2nd char from the string, then the other chars, that are not every 2nd char, and concat them as new String.
        //Do this n times!
        //Examples:
        //"This is a test!", 1 -> "hsi  etTi sats!"
        //"This is a test!", 2 -> "hsi  etTi sats!" -> "s eT ashi tist!"
        //Write two methods:
        //string Encrypt(string text, int n)
        //string Decrypt(string encryptedText, int n)
        //For both methods:
        //If the input-string is null or empty return exactly this value!
        //If n is <= 0 then return the input text.
        public static string Encrypt(string text, int n)
        {
            if (text == null) return text;
            if (text.Length == 0 || n <= 0) return text;
            string result = "";
            string result2 = "";
            string res = text;
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < text.Length; k++)
                {
                    if (k % 2 != 0) {
                        result += res[k];
                    }
                    if (k % 2 == 0)
                    {
                        result2 += res[k];
                    }
                }
                res = string.Concat(result, result2);
                result = "";
                result2 = "";
            }
            return res;
        }

        public static string Decrypt(string encryptedText, int n)
        {
            if (encryptedText == null) return encryptedText;
            if (encryptedText.Length == 0 || n <= 0) return encryptedText;
            char[] result = new char[encryptedText.Length];
            for (int h = 0; h < n; h++)
            {

                for (int i = 0; i <= encryptedText.Length; i++)
                {
                    if (i < encryptedText.Length / 2)
                    {
                        result[i * 2 + 1] = encryptedText[i];
                    }
                    if (i > encryptedText.Length / 2)
                    {
                        var test = encryptedText[i - 1];
                        result[(i - ((encryptedText.Length / 2) + 1)) * 2] = encryptedText[i - 1];
                    }
                }
                encryptedText = new string(result);
            }
            return new string(result);
        }

        //Build Tower
        //Build Tower by the following given argument:
        //number of floors(integer and always greater than 0).
        //Tower block is represented as *
        //C#: returns a string[];
        //for example, a tower of 3 floors looks like below
        //[
        //  '  *  ',
        //  ' *** ',
        //  '*****'
        //]
        //and a tower of 6 floors looks like below
        //[
        //  '     *     ',
        //  '    ***    ',
        //  '   *****   ',
        //  '  *******  ',
        //  ' ********* ',
        //  '***********'
        //]
        //  CLEVER  -----------------------------------------------
        //var result = new string[nFloors];
        //for(int i=0;i<nFloors;i++)
        //result[i] = string.Concat(new string (' ',nFloors - i - 1),
        //                        new string ('*',i* 2 + 1),
        //                        new string (' ',nFloors - i - 1));
        //return result;
        public static string[] TowerBuilder(int nFloors)
        {
            if (nFloors == 1) return new[] { "*" };
            string[] response = new string[nFloors];
            for (int i = 0; i < nFloors; i++)
            {
                response[i] = CreateFloor(i, nFloors);
            }
            return response;
        }
        private static string CreateFloor(int floor,int floorsCount)
        {
            string resp = "";
            int charactersCount = floorsCount * 2 - 1;
            for (int i = 1; i < (floorsCount-floor); i++)
            {
                resp += " ";
            }
            for (int i = 0; i < floor*2+1; i++)
            {
                resp += "*";
            }
            for (int i = 1; i < (floorsCount - floor); i++)
            {
                resp += " ";
            }
            return resp;
        }
        //Valid Braces
        //Write a function that takes a string of braces, and determines if the order of the braces is valid.
        //It should return true if the string is valid, and false if it's invalid.
        //All input strings will be nonempty, and will only consist of parentheses, brackets and curly braces: ()[]{}.
        //A string of braces is considered valid if all braces are matched with the correct brace.
        //Examples
        //"(){}[]"   =>  True
        //"([{}])"   =>  True
        //"(}"       =>  False
        //"[(])"     =>  False
        //"[({})](]" =>  False
        //  CLEVER  -----------------------------------------------
        //string prev = "";
        //while (str.Length != prev.Length)
        //{
        //    prev = str;
        //    str = str
        //        .Replace("()", String.Empty)
        //        .Replace("[]", String.Empty)
        //        .Replace("{}", String.Empty);
        //}
        //return (str.Length == 0);
        public static bool validBraces(String braces)
        {
            string bracesNew = braces;
            string bracesOld = "";
            while (bracesNew != bracesOld)
            {
                bracesOld = bracesNew;
                for (int i = 0; i < bracesNew.Length-1; i++)
                {
                    if (IsPair(bracesNew[i],bracesNew[i+1]))
                    {
                        bracesNew = bracesNew.Remove(i, 1);
                        bracesNew = bracesNew.Remove(i, 1);
                    }
                }
            }
            if (bracesNew.Length == 0) return true;
            return false;
        }

        public static bool IsPair(char a, char b)
        {
            if (a == '(' && b == ')') return true;
            if (a == '[' && b == ']') return true;
            if (a == '{' && b == '}') return true;
            return false;
        }

        //Sort the odd
        //You have an array of numbers.
        //Your task is to sort ascending odd numbers but even numbers must be on their places.
        //Zero isn't an odd number and you don't need to move it.If you have an empty array, you need to return it.
        //Example
        //sortArray([5, 3, 2, 8, 1, 4]) == [1, 3, 2, 8, 5, 4]
        //  CLEVER  -----------------------------------------------
        //Queue<int> odds = new Queue<int>(array.Where(e => e % 2 == 1).OrderBy(e => e));
        //return array.Select(e => e%2 == 1 ? odds.Dequeue() : e).ToArray();
        public static int[] SortArray(int[] array)
        {
            var oddarr = array.Where(x => x % 2 != 0).OrderBy(x=>x).ToList();
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i]%2 != 0)
                {
                    array[i] = oddarr[0];
                    oddarr.RemoveAt(0);
                }
            }
            return array;
        }

        //Are they the "same"?
        //Given two arrays a and b write a function comp(a, b) (compSame(a, b) in Clojure) that checks whether the two arrays have the "same" elements, 
        //with the same multiplicities.
        //"Same" means, here, that the elements in b are the elements in a squared, regardless of the order.
        //Examples
        //Valid arrays
        //a = [121, 144, 19, 161, 19, 144, 19, 11]
        //b = [121, 14641, 20736, 361, 25921, 361, 20736, 361]
        //comp(a, b) returns true because in b 121 is the square of 11, 14641 is the square of 121, 20736 the square of 144, 361 the square of 19, 25921 the 
        //square of 161, and so on.It gets obvious if we write b's elements in terms of squares:
        //a = [121, 144, 19, 161, 19, 144, 19, 11]
        //b = [11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19]
        //Invalid arrays
        //If we change the first number to something else, comp may not return true anymore:
        //a = [121, 144, 19, 161, 19, 144, 19, 11]
        //b = [132, 14641, 20736, 361, 25921, 361, 20736, 361]
        //comp(a, b) returns false because in b 132 is not the square of any number of a.
        //a = [121, 144, 19, 161, 19, 144, 19, 11]
        //b = [121, 14641, 20736, 36100, 25921, 361, 20736, 361]
        //comp(a, b) returns false because in b 36100 is not the square of any number of a.
        //Remarks
        //a or b might be [] (all languages except R, Shell). a or b might be nil or null or None or nothing(except in Haskell, Elixir, C++, Rust, R, Shell, PureScript).
        //If a or b are nil(or null or None), the problem doesn't make sense so return false.
        //If a or b are empty then the result is self-evident.
        //a or b are empty or not empty lists.
        //  CLEVER  -----------------------------------------------
        //if ((a == null) || (b == null)){
        //    return false;
        //}
        //int[] copy = a.Select(x => x * x).ToArray();
        //Array.Sort(copy);
        //Array.Sort(b);
        //return copy.SequenceEqual(b);
        public static bool comp(int[] a, int[] b)
        {
            if (a == null || b == null) return false;
            if (a.Length == 0 && b.Length == 0) return true;
            if (a.Length == 0 || b.Length == 0) return false;
            List<int> list_a = a.ToList();
            List<int> list_b = b.ToList();
            for (int i = 0; i < a.Length; i++)
            {
                if (list_b.Contains((int)Math.Pow(a[i], 2)))
                {
                    list_b.Remove((int)Math.Pow(a[i], 2));
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        //Find the missing letter
        //# Find the missing letter
        //Write a method that takes an array of consecutive(increasing) letters as input and that returns the missing letter in the array.
        //You will always get an valid array. And it will be always exactly one letter be missing. The length of the array will always be at least 2.
        //The array will always contain letters in only one case.
        //['a','b','c','d','f'] -> 'e' ['O','Q','R','S'] -> 'P'
        //["a","b","c","d","f"] -> "e"
        //["O","Q","R","S"] -> "P"
        //(Use the English alphabet with 26 letters!)
        public static char FindMissingLetter(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i + 1] - array[i] != 1) return (char)(array[i] + 1);
            }
            return ' ';
        }

        //There is a queue for the self-checkout tills at the supermarket.Your task is write a function to calculate the total time required for all the customers to check out!
        //input
        //customers: an array of positive integers representing the queue.Each integer represents a customer, and its value is the amount of time they require to check out.
        //n: a positive integer, the number of checkout tills.
        //output
        //The function should return an integer, the total time required.
        //Important
        //Please look at the examples and clarifications below, to ensure you understand the task correctly :)
        //Examples
        //queueTime([5,3,4], 1)
        //// should return 12
        //// because when there is 1 till, the total time is just the sum of the times
        //        queueTime([10,2,3,3], 2)
        //// should return 10
        //// because here n=2 and the 2nd, 3rd, and 4th people in the 
        //// queue finish before the 1st person has finished.
        //        queueTime([2,3,10], 2)
        //// should return 12
        //Clarifications
        //There is only ONE queue serving many tills, and
        //The order of the queue NEVER changes, and
        //The front person in the queue(i.e.the first element in the array/list) proceeds to a till as soon as it becomes free.
        public static long QueueTime(int[] customers, int n)
        {
            var registers = new List<int>(Enumerable.Repeat(0, n));
            foreach (int cust in customers)
            {
                registers[registers.IndexOf(registers.Min())] += cust;
            }
            return registers.Max();
        }

        //Array.diff
        //Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.
        //It should remove all values from list a, which are present in list b.
        //Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}
        //If a value is present in b, all of its occurrences must be removed from the other:
        //Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}
        //  CLEVER  -----------------------------------------------
        //return a.Where(n => !b.Contains(n)).ToArray();
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            List<int> intList = a.ToList();
            for (int i = 0; i < b.Length; i++)
            {
                if (intList.Contains(b[i])) intList.RemoveAll(x => x == b[i]);
            }
            return intList.ToArray();
        }


    }
}
