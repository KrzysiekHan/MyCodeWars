using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
    public static class _6KYU
    {
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

        public static List<string> Anagrams(string word, List<string> words)
        {
            List<string> response = new List<string>();
            var letters = word.ToCharArray().ToList();
            letters.Sort();

            foreach (var item in words)
            {
                var array = item.ToCharArray().ToList();
                array.Sort();
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
