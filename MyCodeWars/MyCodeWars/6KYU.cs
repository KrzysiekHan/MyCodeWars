using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
    public static class _6KYU
    {
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
