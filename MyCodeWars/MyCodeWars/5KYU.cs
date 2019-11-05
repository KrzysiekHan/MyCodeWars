using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyCodeWars.Program;

namespace MyCodeWars
{
    public static class _5KYU
    {

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
