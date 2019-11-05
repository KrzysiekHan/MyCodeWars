using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
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

    class Program
    {


        static void Main(string[] args)
        {

            //assert new List<int>(){1,2,3,4,5,6},
            _5KYU.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1));
            
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
}
