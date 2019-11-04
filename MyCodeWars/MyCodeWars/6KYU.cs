using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MyCodeWars
{
    public static class _6KYU
    {

        //Your task is to add up letters to one letter.
        //The function will be given an array of letters(chars), each one being a letter to add.Return a char.
        //Notes:
        //Letters will always be lowercase.
        //Letters can overflow(see second to last example of the description)
        //If no letters are given, the function should return 'z'
        //Examples:
        //add_letters(new char[] {'a', 'b', 'c'}) = 'f'
        //add_letters(new char[] {'a', 'b'}) = 'c'
        //add_letters(new char[] {'z'}) = 'z'
        //add_letters(new char[] {'z', 'a'}) = 'a'
        //add_letters(new char[] {'y', 'c', 'b'}) = 'd' // notice the letters overflowing
        //add_letters(new char[] {}) = 'z'
        public static char AddLetters(char[] letters)
        {

            if (letters.Length == 0) return 'z';
            int result = 0;
            foreach (var item in letters)
            {
                int number = item - 96;
                result += number;
            }
            int answear = (result % 26) + 96;

            // your code here
            return (char)answear;
        }


        //C#7 not supported
        //The drawing shows 6 squares the sides of which have a length of 1, 1, 2, 3, 5, 8. It's easy to see that the sum of the perimeters of these squares is : 4 * (1 + 1 + 2 + 3 + 5 + 8) = 4 * 20 = 80
        //Could you give the sum of the perimeters of all the squares in a rectangle when there are n + 1 squares disposed in the same manner as in the drawing:
        //public static BigInteger perimeter(BigInteger n)
        //{

        //    BigInteger number = 0;
        //    // your code
        //    return -1;
        //}


        //A binary gap within a positive number num is any sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of num.
        //For example:
        //9 has binary representation 1001 and contains a binary gap of length 2.
        //529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3.
        //20 has binary representation 10100 and contains one binary gap of length 1.
        //15 has binary representation 1111 and has 0 binary gaps.
        //Write function gap(num) that, given a positive num, returns the length of its longest binary gap.
        //The function should return 0 if num doesn't contain a binary gap.
        //  CLEVER  -----------------------------------------------
        //var binary = Convert.ToString(num, 2);
        //return binary.Trim('0').Split('1').Select(s => s.Length).Max();
        public static int Gap(int num)
        {
            var binary = Convert.ToString(num , 2);
            int gap = 0;
            int longestGap = 0;
            char previous = ' ';
            //find first index of 1 
            if (binary.IndexOf('1') > 0) binary = binary.Substring(binary.IndexOf('1'));
            if (binary.LastIndexOf('1') != binary.Length) binary = binary.Substring(0, binary.LastIndexOf('1')+1);
            for (int i = 0; i < binary.Length; i++)
            {                

                if (binary[i] == '0')
                {
                    gap++;
                    if (gap > longestGap) longestGap = gap;
                } else {
                    gap = 0;
                }
                previous = binary[i];
            }
             return longestGap;
        }




        //Given the string representations of two integers, return the string representation of the sum of those integers.
        //For example:
        //sumStrings('1','2') // => '3'
        //A string representation of an integer will contain no characters besides the ten numerals "0" to "9".
        //  CLEVER  -----------------------------------------------
        //BigInteger aInt;
        //BigInteger bInt;
        //BigInteger.TryParse(a, out aInt);
        //BigInteger.TryParse(b, out bInt);   
        //return (aInt + bInt).ToString();

        public static string sumStrings(string a, string b)
        {
            if (a.Length > 28)
            {
                string resp = "";
                var s1 = a.ToCharArray();
                var s2 = b.ToCharArray();
                int prev = 0;
                for (int i = a.Length; i >=0 ; i--)
                {
                    int num = Int32.Parse(s1[i-1].ToString()) + Int32.Parse(s2[i-1].ToString()) + prev;
                    prev = 0;
                    if (num > 9)
                    {
                        prev = num / 10;
                        resp = (num % 10).ToString() + resp;
                    } else
                    {
                        resp = num.ToString() + resp;
                    }
                }
                if (prev > 0) resp = prev.ToString() + resp;
                return resp;
            }
            decimal n1 = 0m;
            decimal n2 = 0m;
            decimal.TryParse(a, out n1);
            decimal.TryParse(b, out n2);
            decimal result = n1+n2;
            return result.ToString();
        }
        //ROT13 is a simple letter substitution cipher that replaces a letter with the letter 13 letters after it in the alphabet. ROT13 is an example of the Caesar cipher.
        //Create a function that takes a string and returns the string ciphered with Rot13.If there are numbers or special characters included in the string, they should be returned as they are. Only letters from the latin/english alphabet should be shifted, like in the original Rot13 "implementation".
        //Assert.AreEqual("grfg", Kata.Rot13("test")
        //  CLEVER  -----------------------------------------------
        //    return String.Join("", message.Select(x => char.IsLetter(x) ? (x >= 65 && x <= 77) || (x >= 97 && x <= 109) ? (char)(x + 13) : (char)(x - 13) : x));
        public static string Rot13(string message)
        {
            string response= "";
            foreach (var item in message)
            {
                if (item>='A' && item <= 'Z')
                {
                    int letternr = (int)item;
                    char newLetter = item < 'M' ? (char)(letternr + 13) : (char)(letternr - 13);
                    response += newLetter;
                } else if (item>='a'&& item<='z')
                {
                    int letternr = (int)item;
                    char newLetter = item<'m'?(char)(letternr + 13): (char)(letternr - 13);
                    response += newLetter;
                } else
                {
                    response += item;
                }
            }
            return response;
        }

        //What is an anagram? Well, two words are anagrams of each other if they both contain the same letters.For example:
        //'abba' & 'baab' == true
        //'abba' & 'bbaa' == true
        //'abba' & 'abbba' == false
        //'abba' & 'abca' == false
        //Write a function that will find all the anagrams of a word from a list.You will be given two inputs a word and an array with words.
        //You should return an array of all the anagrams or an empty array if there are none.For example:
        //anagrams('abba', ['aabb', 'abcd', 'bbaa', 'dada']) => ['aabb', 'bbaa']
        //anagrams('racer', ['crazer', 'carer', 'racar', 'caers', 'racer']) => ['carer', 'racer']
        //anagrams('laser', ['lazing', 'lazy',  'lacer']) => []
        //  CLEVER  -----------------------------------------------
        //var pattern = word.OrderBy(p => p).ToArray();
        //return words.Where(item => item.OrderBy(p => p).SequenceEqual(pattern)).ToList();
        public static List<string> Anagrams(string word, List<string> words)
        {
            List<string> response = new List<string>();
            var letters = word.ToCharArray().ToList();
            letters.Sort();

            foreach (var item in words)
            {
                var array = item.ToCharArray().ToList();
                array.Sort();
                if (array.SequenceEqual(letters)) response.Add(item);
            }
            return response;
        }
    

    //There is an array with some numbers.All numbers are equal except for one.Try to find it!
    //findUniq([ 1, 1, 1, 2, 1, 1 ]) === 2
    //findUniq([ 0, 0, 0.55, 0, 0 ]) === 0.55
    //It’s guaranteed that array contains more than 3 numbers.
    //The tests contain some very huge arrays, so think about performance.
    //  CLEVER  -----------------------------------------------
    //return numbers.GroupBy(x=>x).Single(x=> x.Count() == 1).Key;
    public static int GetUnique(IEnumerable<int> numbers)
        {
            var test = numbers.Distinct().ToList();
            foreach (var item in test)
            {
                var counter = numbers.Where(c => c == item).Count();
                if (counter == 1) return item;
            }
            return -1;
        }
    }
}
