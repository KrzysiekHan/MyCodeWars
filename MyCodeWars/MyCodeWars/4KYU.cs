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
        //You need to return a string that looks like a diamond shape when printed on the screen, using asterisk (*) characters.
        //Trailing spaces should be removed, and every line must be terminated with a newline character (\n).
        //Return null/nil/None/... if the input is an even number or negative, as it is not possible to print a diamond of even or negative size.
        //A size 3 diamond:
        // *
        //***
        // *
        //...which would appear as a string of " *\n***\n *\n"
        //A size 5 diamond:
        //  *
        // ***
        //*****
        // ***
        //  *
        //...that is: " *\n ***\n*****\n ***\n *\n"
        public static string print(int n)
        {
            if (n % 2 == 0 || n <= 0) return null;
            string result = "";
            int middle = (n / 2) + 1;
            for (int i = 1; i <= n; i++)
            {
                if (i<=middle)
                {
                    var starCount = (i * 2) - 1;
                    for (int y = 0; y < (n - starCount) / 2; y++)
                    {
                        result += ' ';
                    }
                    for (int o = 0; o < starCount; o++)
                    {
                        result += '*';
                    }
                    result += '\n';
                }
                else
                {
                    var starCount = ((n - i) * 2) + 1;
                    for (int y = 0; y < (n - starCount) / 2; y++)
                    {
                        result += ' ';
                    }
                    for (int o = 0; o < starCount; o++)
                    {
                        result += '*';
                    }
                    result += '\n';
                }
            }
            return result;
        }
        //Maximum subarray sum
        //The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:
        //maxSequence[-2, 1, -3, 4, -1, 2, 1, -5, 4]
        //-- should be 6: [4, -1, 2, 1]
        //Easy case is when the list is made up of only positive numbers and the maximum 
        //sum is the sum of the whole array.If the list is made up of only negative numbers, return 0 instead.
        //Empty list is considered to have zero greatest sum. Note that the empty list or array is also a valid sublist/subarray.
        public static int MaxSequence(int[] arr)
        {
            if (arr.Length == 0) return 0;
            bool allNegative = true;
            foreach (var item in arr)
            {
                if (item >= 0) allNegative = false;              
            }
            if (allNegative) return 0;
            if (arr.Sum() <= 0) return 0;
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int maxSum = 0;
                for (int l = i; l<arr.Length; l++)
                {
                    maxSum = maxSum + arr[l];
                    if (maxSum > max)
                    {
                        max = maxSum;
                    }
                }
            }
            return max;
        }


        //Weight for weight
        //my friend John and I are members of the "Fat to Fit Club (FFC)". John is worried because each month a list with the weights 
        //of members is published and each month he is the last on the list which means he is the heaviest.
        //I am the one who establishes the list so I told him: "Don't worry any more, I will modify the order of the list". It was decided 
        //to attribute a "weight" to numbers. The weight of a number will be from now on the sum of its digits.
        //For example 99 will have "weight" 18, 100 will have "weight" 1 so in the list 100 will come before 99. Given a string with the 
        //weights of FFC members in normal order can you give this string ordered by "weights" of these numbers?
        //Example:
        //"56 65 74 100 99 68 86 180 90" ordered by numbers weights becomes: "100 180 90 56 65 74 68 86 99"
        //When two numbers have the same "weight", let us class them as if they were strings(alphabetical ordering) and not numbers: 100 is 
        //before 180 because its "weight" (1) is less than the one of 180 (9) and 180 is before 90 since, having the same "weight" (9), 
        //it comes before as a string.
        //All numbers in the list are positive numbers and the list can be empty.
        //it may happen that the input string have leading, trailing whitespaces and more than a unique whitespace between two consecutive numbers
        //ALGORITHMSNUMBERS
        public static string orderWeight(string strng)
        {
           return string.Join(" ",strng.Split(' ').OrderBy(a => a.Select(b => char.GetNumericValue(b)).Sum()).ThenBy(c=>c).ToList());
        }

        //A pangram is a sentence that contains every single letter of the alphabet at least once.For example, 
        //the sentence "The quick brown fox jumps over the lazy dog" is a pangram, because it uses the 
        //letters A-Z at least once(case is irrelevant).Given a string, detect whether or not it is 
        //a pangram.Return True if it is, False if not.Ignore numbers and punctuation.
        //  CLEVER  -----------------------------------------------
        //return str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;
        public static bool IsPangram(string str)
        {
            var lettersArr = str.ToLower().ToCharArray();
            List<int> letters = new List<int>(Enumerable.Range(1, 26));
            for (int i = 0; i < lettersArr.Length; i++)
            {
                int letterNum = (int)lettersArr[i] - 96;
                if (letters.Contains(letterNum)) letters.Remove(letterNum);
            }
            if (letters.Count > 0) return false;
            return true;
        }

        //Rectangle into Squares
        //The drawing below gives an idea of how to cut a given "true" rectangle into squares("true" rectangle 
        //meaning that the two dimensions are different).
        //Can you translate this drawing into an algorithm?
        //You will be given two dimensions
        //a positive integer length (parameter named lng)
        //a positive integer width (parameter named wdth)
        //You will return an array or a string (depending on the language; Shell bash, PowerShell and Fortran return a string) with the size of each of the squares.
        //  sqInRect(5, 3) should return [3, 2, 1, 1]
        //Notes:
        //lng == wdth as a starting case would be an entirely different problem and the drawing is 
        //planned to be interpreted with lng != wdth.
        //When the initial parameters are so that lng == wdth, the solution [lng] would be the 
        //most obvious but not in the spirit of this kata so, in that case, return null
        public static List<int> sqInRect(int lng, int wdth)
        {
            if (lng == wdth) return null;
            List<int> result = new List<int>();
            while (lng != wdth)
            {
                int small = (lng < wdth) ? lng : wdth; 
                int big = (lng > wdth) ? lng : wdth;

                result.Add(small);

                lng = small;
                wdth = big - small;
            }
            result.Add(lng);
            return result;
        }


        //Is a number prime?
        //Define a function that takes an integer argument and returns logical value true or false depending on if the integer is a prime.
        //Per Wikipedia, a prime number (or a prime) is a natural number greater than 1 that has no positive divisors other than 1 and itself.
        //Example
        //is_prime(1)  /* false */
        //is_prime(2)  /* true  */
        //is_prime(-1) /* false */
        //Assumptions
        //You can assume you will be given an integer input.
        //You can not assume that the integer will be only positive.You may be given negative numbers as well(or 0).
        //There are no fancy optimizations required, but still the most trivial solutions might time out. 
        //Try to find a solution which does not loop all the way up to n.
        //  CLEVER  -----------------------------------------------         
        //if (n <= 2 || n % 2 == 0) return n == 2;
        //for (int i = 3; i <= Math.Sqrt(n); i += 2) if (n % i == 0) return false;
        //return true;
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            int bound = (int)Math.Floor(Math.Sqrt(n));
            for (int i = 2; i <= bound; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        //Take a Number And Sum Its Digits Raised To The Consecutive Powers And ....¡Eureka!!
        //The number 89 is the first integer with more than one digit that fulfills the property partially 
        //introduced in the title of this kata.What's the use of saying "Eureka"? Because this sum gives the same number.
        //In effect: 89 = 8^1 + 9^2
        //The next number in having this property is 135.
        //See this property again: 135 = 1^1 + 3^2 + 5^3
        //We need a function to collect these numbers, that may receive two integers a, b that defines the range[a, b] 
        //(inclusive) and outputs a list of the sorted numbers in the range that fulfills the property described above.
        //Let's see some cases:
        //sum_dig_pow(1, 10) == [1, 2, 3, 4, 5, 6, 7, 8, 9]
        //sum_dig_pow(1, 100) == [1, 2, 3, 4, 5, 6, 7, 8, 9, 89]
        //If there are no numbers of this kind in the range[a, b] the function should output an empty list.
        //sum_dig_pow(90, 100) == []
        //  CLEVER  ----------------------------------------------- 
        //List<long> values = new List<long>();
        //for (long x = a; x <= b; x++)
        //{
        //  if (x.ToString().Select((c, i) => Math.Pow(Char.GetNumericValue(c), i + 1)).Sum() == x)
        //    values.Add(x);
        //}
        //return values.ToArray();
        public static long[] SumDigPow(long a, long b)
        {
            List<long> response = new List<long>();
            for (long i = a; i < b; i++)
            {
                if (Eureka((int)i)) response.Add(a);
            }
            return response.ToArray();
        }

        public static bool Eureka(int value)
        {
            string str = value.ToString();
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                result += (int)Math.Pow(Convert.ToInt32(str[i].ToString()), i+1);
            }
            return (value == result) ? true : false;
        }

        //A Narcissistic Number is a number which is the sum of its own digits, each raised to the power of the number of digits 
        //in a given base. In this Kata, we will restrict ourselves to decimal (base 10).
        //For example, take 153 (3 digits):
        //    1^3 + 5^3 + 3^3 = 1 + 125 + 27 = 153
        //and 1634 (4 digits):
        //    1^4 + 6^4 + 3^4 + 4^4 = 1 + 1296 + 81 + 256 = 1634
        //The Challenge:
        //Your code must return true or false depending upon whether the given number is a Narcissistic number in base 10.
        //Error checking for text strings or other invalid inputs is not required, only valid integers will be passed into the function.
        //  CLEVER  -----------------------------------------------        
        //var str = value.ToString();
        //return str.Sum(c => Math.Pow(Convert.ToInt16(c.ToString()), str.Length)) == value;
        public static bool Narcissistic(int value)
        {
            var temp = value.ToString().ToArray();
            int result = 0;
            for (int i = 0; i < temp.Length; i++)
            {
               result += (int)Math.Pow(int.Parse(temp[i].ToString()), temp.Length);
            }
            return (result == value) ? true : false;
        }


        //A child is playing with a ball on the nth floor of a tall building.The height of this floor, h, is known.
        //He drops the ball out of the window.The ball bounces (for example), to two-thirds of its height(a bounce of 0.66).
        //His mother looks out of a window 1.5 meters from the ground.
        //How many times will the mother see the ball pass in front of her window (including when it's falling and bouncing?
        //Three conditions must be met for a valid experiment:
        //Float parameter "h" in meters must be greater than 0
        //Float parameter "bounce" must be greater than 0 and less than 1
        //Float parameter "window" must be less than h.
        //If all three conditions above are fulfilled, return a positive integer, otherwise return -1.
        //Note:
        //The ball can only be seen if the height of the rebounding ball is strictly greater than the window parameter.
        //Example:
        //- h = 3, bounce = 0.66, window = 1.5, result is 3
        //- h = 3, bounce = 1, window = 1.5, result is -1 
        //(Condition 2) not fulfilled).
        public static int bouncingBall(double h, double bounce, double window)
        {
            if (h<=0) return -1;
            if (bounce >= 1) return -1;
            if (bounce <= 0) return -1;
            if (window >= h) return -1;

            double bounceHeight = h;
            int howMany = 0;

            while (bounceHeight>window)
            {
                bounceHeight = bounceHeight * bounce;
                howMany++;
                howMany++;
            }
            // your code
            return howMany-1;
        }


        //Highest Scoring Word
        //Given a string of words, you need to find the highest scoring word.
        //Each letter of a word scores points according to its position in the alphabet: a = 1, b = 2, c = 3 etc.
        //You need to return the highest scoring word as a string
        //If two words score the same, return the word that appears earliest in the original string.
        //All letters will be lowercase and all inputs will be valid.
        //  CLEVER  ----------------------------------------------- 
        //return s.Split(' ').OrderBy(a => a.Select(b => b - 96).Sum()).Last();
        public static string High(string s)
        {
            var words = s.Split(' ');
            Dictionary<string, int> results = new Dictionary<string, int>();
            foreach (var item in words)
            {
                int points = 0;
                for (int i = 0; i < item.Length; i++)
                {
                    points += LetterPoints(item[i]);
                }
                if (!results.ContainsKey(item))
                {
                    results.Add(item, points);
                }            
            }
            var res = results.OrderByDescending(x => x.Value);
            return res.First().Key;      
        }
        public static int LetterPoints(char letter)
        {          
            return (int)letter - 96;
        }


        //Roman Numerals Encoder
        //Create a function taking a positive integer as its parameter and returning a string containing the Roman Numeral representation of that integer.
        //Modern Roman numerals are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero.
        //In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC. 2008 is written as 2000=MM, 8=VIII; or MMVIII. 
        //1666 uses each Roman symbol in descending order: MDCLXVI.
        //Example:
        //RomanConvert.Solution(1000) -- should return "M"
        //Help:
        //Symbol Value
        //I          1
        //V          5
        //X          10
        //L          50
        //C          100
        //D          500
        //M          1,000
        //Remember that there can't be more than 3 identical symbols in a row.
        public static string Solution(int n)
        {
            string roman = "";
            string[] thousand = { "", "M", "MM", "MMM" };
            string[] hundred = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] ten = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] one = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            roman += thousand[(n / 1000) % 10];
            roman += hundred[(n / 100) % 10];
            roman += ten[(n / 10) % 10];
            roman += one[n % 10];

            return roman;
        }

        //Write function bmi that calculates body mass index(bmi = weight / height ^ 2).
        //if bmi <= 18.5 return "Underweight"
        //if bmi <= 25.0 return "Normal"
        //if bmi <= 30.0 return "Overweight"
        //if bmi > 30 return "Obese"
        public static string Bmi(double weight, double height)
        {
            double result = weight / (Math.Pow(height, 2));
            return result.ToString();
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
