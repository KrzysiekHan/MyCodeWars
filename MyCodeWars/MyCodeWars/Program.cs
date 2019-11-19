using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            _4KYU.RevRot("79549049095957714555360838515781031424094833454369363281", 9);
            //_4KYU.ToCamelCase("the-stealth-warrior");
            //_4KYU.CountSmileys(new string[] { ";-D", ":(", ":(", ":(" });
            //_4KYU.DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);
            //_4KYU.Decrypt("s eT ashi tist!", 2);
            //_4KYU.Encrypt("This is a test!", 1); //"s eT ashi tist!"
            //_4KYU.print(5);
            //_4KYU.orderWeight("56 65 74 100 99 68 86 180 90");
            //_4KYU.IsPangram("The quick brown fox jumps over the lazy dog.");
            //_4KYU.SumDigPow(1, 100);
            //_4KYU.Narcissistic(371);
            //_4KYU.bouncingBall(30.0, 0.66, 1.5);//15
            //_4KYU.High("man i need a taxi up to ubud");
            //_4KYU.Decrypt("hsi  etTi sats!", 1);
            //_4KYU.Encrypt("This is a test!", 2); //"s eT ashi tist!"
            //_4KYU.TowerBuilder(5);
            //_4KYU.validBraces("()[]{}");
            //_4KYU.validBraces("()[)]{[[}");
            //_4KYU.SortArray(new int[] { 5, 3, 2, 8, 1, 4 }); //{ 1, 3, 2, 8, 5, 4 }
            //_4KYU.comp(new int[] {}, new int[] {});
            //_4KYU.comp(new int[] { 121, 144, 19, 161, 19, 144, 19, 11 }, new int[] { 121, 14641, 20736, 361, 25921, 361, 20736, 361 });
            //_4KYU.FindMissingLetter(new[] { 'a', 'b', 'c', 'd', 'f' }); //e
            //_4KYU.QueueTime(new int[] { 2, 2, 3, 3, 4, 4 }, 2); //9
            //_5KYU.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 3);//new String[] {"it","wkppv","ixoyx", "3452", "zzzzzzzzzzzz"}, 3), "ixoyx3452zzzzzzzzzzzz");
            //_5KYU.CreatePhoneNumber(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0}); //1,2,3,4,5,6,7,8,9,0  (123) 456-7890
            //_5KYU.UniqueInOrder("AAAABBBCCDAABBB");//"ABCDAB"
            //_5KYU.AlphabetPosition("The sunset sets at twelve o' clock.");
            //_5KYU.dirReduc(new string[] { "NORTH", "WEST", "SOUTH", "EAST"});//WEST
            //_5KYU.dirReduc(new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" });//WEST
            //_5KYU.Test("88 96 66 51 14 88 2 92 18 72 18 88 20 30 4 82 90 100 24 46");
            //_5KYU.SongDecoder("RWUBWUBWUBLWUB");
            //int[][] array2 = { new int[] { } };
            //_5KYU.Snail(array2);
            //_5KYU.DuplicateEncode("recede"); //"()()()"
            //_5KYU.Order("is2 Thi1s T4est 3a");
            //_5KYU.digPow(46288, 3);
            //_5KYU.Tribonacci(new double[] { 1, 1, 1 }, 10);
            //_5KYU.DuplicateCount("Indivisibilities");
            //_5KYU.Solution(10);
            //_5KYU.Persistence(999);
            //_5KYU.find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }); //should return 5
            //_5KYU.DateNbDays(4281, 5087, 2);
            //_5KYU.wave(" gap ");
            //_5KYU.factorial(5);
            //_5KYU.factorial(9);
            //_5KYU.factorial(15);
            //assert new List<int>(){1,2,3,4,5,6},
            //_5KYU.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1));
            //_5KYU.IsSolved(new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } });
            //double[] x = new double[] { 0.0, 0.23, 0.46, 0.69, 0.92, 1.15, 1.38, 1.61 };
            //_5KYU.Gps(20, x); //result should be 41
            //_6KYU.Pyramid(3);
            //_6KYU.HowManyMeasurements(2);
            //_6KYU.HowManyMeasurements(3);
            //_6KYU.HowManyMeasurements(8);
            //_6KYU.HowManyMeasurements(100);
            //_6KYU.Rgb(255, 255, 255);
            //_6KYU.AddLetters(new char[] { 'a', 'b', 'c', 'z' });
            //_6KYU.Gap(9); 
            //_6KYU.sumStrings("712569312664357328695151392", "8100824045303269669937");
            //_6KYU.Rot13("ABCD");
            //_6KYU.Anagrams("a", new List<string> { "a", "b", "c", "d" }); // correct answear a
            //_6KYU.Anagrams("racer", new List<string> { "carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr" }); //answear "carer", "arcre", "carre"
        }
    }
    public class Node
    {
        public Node Left;
        public Node Right;
        public int Value;

        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }
    }
}
