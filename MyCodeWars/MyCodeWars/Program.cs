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
            _5KYU.UniqueInOrder("AAAABBBCCDAABBB");//"ABCDAB"
            //_5KYU.AlphabetPosition("The sunset sets at twelve o' clock.");
            //_5KYU.dirReduc(new string[] { "NORTH", "WEST", "SOUTH", "EAST"});//WEST
            //_5KYU.dirReduc(new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" });//WEST
            //_5KYU.Test("88 96 66 51 14 88 2 92 18 72 18 88 20 30 4 82 90 100 24 46");
            //_5KYU.SongDecoder("RWUBWUBWUBLWUB");
            //int[][] array =
            //{
            //    new []{1, 2, 3},
            //    new []{4, 5, 6},
            //    new []{7, 8, 9}
            //};
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
