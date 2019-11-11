using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
    public static class _4KYU
    {
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
