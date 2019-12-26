using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace MyCodeWars
{
    public static class _4KYU
    {
        //Sums of Parts
        //Let us consider this example (array written in general format):
        //ls = [0, 1, 3, 6, 10]
        //Its following parts:
        //ls = [0, 1, 3, 6, 10]
        //ls = [1, 3, 6, 10]
        //ls = [3, 6, 10]
        //ls = [6, 10]
        //ls = [10]
        //ls = []
        //The corresponding sums are (put together in a list): [20, 20, 19, 16, 10, 0]
        //The function parts_sums(or its variants in other languages) will take as parameter a list ls 
        //and return a list of the sums of its parts as defined above.
        //Other Examples:
        //ls = [1, 2, 3, 4, 5, 6]
        //parts_sums(ls) -> [21, 20, 18, 15, 11, 6, 0]
        //ls = [744125, 935, 407, 454, 430, 90, 144, 6710213, 889, 810, 2579358]
        //parts_sums(ls) -> [10037855, 9293730, 9292795, 9292388, 9291934, 9291504, 9291414, 9291270, 2581057, 2580168, 2579358, 0]
        //  CLEVER  -----------------------------------------------
        //return l.Reverse().Aggregate(Enumerable.Repeat(0, 1), (a, i) => a.Prepend(a.First() + i)).ToArray();
        public static int[] PartsSums(int[] ls)
        {
            List<int> partsSum = new List<int>();
            var templist = ls.ToList();
            var initialSum = templist.Sum();
            int iterations = ls.Length;
            int value = initialSum;
            for (int i = 0; i < iterations; i++)
            {
                partsSum.Add(value);
                value = value - templist[0];               
                templist.RemoveAt(0); 
            }
            partsSum.Add(0);
            return partsSum.ToArray();
        }

        //Maze runner
        //You will be given a 2D array of the maze and an array of directions.Your task is to follow the directions given.If you reach the 
        //end point before all your moves have gone, you should return Finish.If you hit any walls or go outside the maze border, you should 
        //return Dead.If you find yourself still in the maze after using all the moves, you should return Lost.
        //The Maze array will look like
        //maze = [[1,1,1,1,1,1,1],
        //        [1,0,0,0,0,0,3],
        //        [1,0,1,0,1,0,1],
        //        [0,0,1,0,0,0,1],
        //        [1,0,1,0,1,0,1],
        //        [1,0,0,0,0,0,1],
        //        [1,2,1,0,1,0,1]]
        //..with the following key
        //0 = Safe place to walk
        //1 = Wall
        //2 = Start Point
        //3 = Finish Point
        //direction = ["N","N","N","N","N","E","E","E","E","E"] == "Finish"
        //Rules
        //1. The Maze array will always be square i.e.N x N but its size and content will alter from test to test.
        //2. The start and finish positions will change for the final tests.
        //3. The directions array will always be in upper case and will be in the format of N = North, E = East, W = West and S = South.
        public static string mazeRunner(int[,] maze, string[] directions)
        {
            Dictionary<string, Point> points = new Dictionary<string, Point>();
            Point start = new Point();
            Point finish = new Point();
            Point current = new Point();
            start = FindPoint(maze, 2);
            current = start;
            finish = FindPoint(maze, 3);
            FieldResult temporaryResult = FieldResult.Start;
            string last = directions.Last();
            foreach (var item in directions)
            {
                switch (item)
                {
                    case "N":
                        current.y--;
                        temporaryResult = checkMazePosiion(maze,current);                       
                        break;
                    case "E":
                        current.x++;
                        temporaryResult = checkMazePosiion(maze, current);
                        break;
                    case "W":
                        current.x--;
                        temporaryResult = checkMazePosiion(maze, current);
                        break;
                    case "S":
                        current.y++;
                        temporaryResult = checkMazePosiion(maze, current);
                        break;
                    default:
                        break;
                }
                switch (temporaryResult)
                {
                    case FieldResult.Continue:
                        break;
                    case FieldResult.Start:
                        break;
                    case FieldResult.Finish:
                        break;
                    case FieldResult.Dead:
                        return "Dead";
                    case FieldResult.Lost:
                        return "Lost";
                    default:
                        break;
                }
                if (temporaryResult == FieldResult.Dead || temporaryResult == FieldResult.Lost || temporaryResult == FieldResult.Finish)
                {
                    break;
                }
                if (item == last && temporaryResult == FieldResult.Continue) temporaryResult = FieldResult.Lost;
            }
            return temporaryResult.ToString();
        }
        private enum FieldResult
        {
            Continue,
            Start,
            Finish,
            Dead,
            Lost
        }
        private static FieldResult checkMazePosiion (int [,] maze,Point point)
        {
            int value = -1;
            try
            {
                value = maze[point.y, point.x];
            }
            catch (Exception)
            {
                value = 1;
            }
            switch (value)
            {
                case 0:
                    return FieldResult.Continue;
                case 1:
                    return FieldResult.Dead;
                case 2:
                    return FieldResult.Start;
                case 3:
                    return FieldResult.Finish;
            }
            return FieldResult.Lost;
        }
        private static Point FindPoint(int[,] maze, int number)
        {
            Point result = new Point();
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i,j] == number)
                    {
                        result.x = j;
                        result.y = i;
                    }
                }
            }
            return result;
        }
        private class Point
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        //Fibonacci, Tribonacci and friends
        //If you have completed the Tribonacci sequence kata, you would know by now that mister Fibonacci has at least a bigger brother.
        //If not, give it a quick look to get how things work.
        //Well, time to expand the family a little more: think of a Quadribonacci starting with a signature of 4 elements and each 
        //following element is the sum of the 4 previous, a Pentabonacci 
        //with a signature of 5 elements and each following element is the sum of the 5 previous, and so on.
        //Well, guess what? You have to build a Xbonacci function that takes a signature of X elements - and remember each next element 
        //is the sum of the last X elements - and returns the first n elements of the so seeded sequence.
        //xbonacci {1,1,1,1} 10 = {1,1,1,1,4,7,13,25,49,94}
        //xbonacci {0,0,0,0,1} 10 = {0,0,0,0,1,1,2,4,8,16}
        //xbonacci {1,0,0,0,0,0,1} 10 = {1,0,0,0,0,0,1,2,3,6}
        //xbonacci {1,1} produces the Fibonacci sequence
        //  CLEVER  -----------------------------------------------
        //var sequence = new List<double>(signature);
        //int count = signature.Length;
        //for(int i = count; i<n; i++)
        //    sequence.Add(sequence.Skip(i - count).Take(count).Sum());
        //return sequence.Take(n).ToArray();
        public static double[] xbonacci(double[] signature, int n)
        {
                double j = 0;
                int x = signature.Length;
                double[] xbon = new double[n];
                for (int k = 0; k < n; k++)
                {
                    if (k < x)
                    {
                    xbon[k] =  signature[k];
                        j += xbon[k];
                    }
                    else
                    {
                        xbon[k] = j;
                        j += j - xbon[k - x];
                    }
                }
                return xbon;
        }

        //Meeting
        //John has invited some friends.His list is:
        //s = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
        //Could you make a program that
        //makes this string uppercase
        //gives it sorted in alphabetical order by last name.
        //When the last names are the same, sort them by first name.Last name and first name 
        //of a guest come in the result between parentheses separated by a comma.
        //So the result of function meeting(s) will be:
        //"(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)"
        //It can happen that in two distinct families with the same family name two people have the same first name too.
        public static string Meeting(string s)
        {
            var sorted = s.Split(';')
                .ToArray()
                .Select(x => x.ToUpper())
                .Select(x => x.Split(':'))
                .Select(w => new { name = w[0], surname = w[1] })
                .OrderBy(v=>v.surname)
                .ThenBy(v=>v.name)
                .Select(d=>$"({d.surname}, {d.name})")
                .ToList();
            return string.Join("",sorted);
        }

        //Length of missing array
        //You get an array of arrays.
        //If you sort the arrays by their length, you will see, that their length-values are consecutive.
        //But one array is missing!
        //You have to write a method, that return the length of the missing array.
        //Example:
        //[[1, 2], [4, 5, 1, 1], [1], [5, 6, 7, 8, 9]] --> 3
        //If the array of arrays is null/nil or empty, the method should return 0.
        //When an array in the array is null or empty, the method should return 0 too!
        //There will always be a missing element and its length will be always between the given arrays.
        //Have fun coding it and please don't forget to vote and rank this kata! :-)
        //I have created other katas.Have a look if you like coding and challenges.
        public static int GetLengthOfMissingArray(object[][] arrayOfArrays)
        {
            if (arrayOfArrays == null) return 0;
            if (arrayOfArrays.Length == 0) return 0;
            var list = arrayOfArrays.Select((x, i) => new { len = x.Length, index = i }).OrderBy(x => x.len).ToList();
            var response = list    
                .Select((c, i) => (i>0) ? new { diff = list[i].len - list[i - 1].len, index = i } : new { diff = 0, index = 0 })
                //.Where(x => x.diff > 1)
                .ToList();
            return 0;
        }

        //Statistics for an Athletic Association
        //You are the "computer expert" of a local Athletic Association(C.A.A.). Many teams of runners come to compete.Each time you get 
        //a string of all race results of every team who has run.For example here is a string showing the individual results of a team of 5 runners:
        //"01|15|59, 1|47|6, 01|17|20, 1|32|34, 2|3|17"
        //Each part of the string is of the form: h|m|s where h, m, s(h for hour, m for minutes, s for seconds) are positive or null 
        //integer(represented as strings) with one or two digits.There are no traps in this format.
        //To compare the results of the teams you are asked for giving three statistics; range, average and median.
        //Range : difference between the lowest and highest values.In {4, 6, 9, 3, 7}
        //the lowest value is 3, and the highest is 9, so the range is 9 − 3 = 6.
        //Mean or Average : To calculate mean, add together all of the numbers in a set and then divide the sum by the total count of numbers.
        //Median : In statistics, the median is the number separating the higher half of a data sample from the lower half.The median of a 
        //finite list of numbers can be found by arranging all the observations from lowest value to highest value and picking the middle 
        //one (e.g., the median of { 3, 3, 5, 9, 11} is 5) when there is an odd number of observations.If there is an even number of 
        //observations, then there is no single middle value; the median is then defined to be the mean of the two middle values(the 
        //median of { 3, 5, 6, 9} is (5 + 6) / 2 = 5.5).
        //Your task is to return a string giving these 3 values.For the example given above, the string result will be
        //"Range: 00|47|18 Average: 01|35|15 Median: 01|32|34"
        //of the form:
        //"Range: hh|mm|ss Average: hh|mm|ss Median: hh|mm|ss"
        //where hh, mm, ss are integers(represented by strings) with each 2 digits.
        //Remarks:
        //if a result in seconds is ab.xy... it will be given truncated as ab.
        //if the given string is "" you will return ""
        public static string stat(string strg)
        {
            if (strg.Equals(""))
            {
                return "";
            }
            var temp = strg.Split(',').Select(x => x.Split('|').ToList()).ToList();
            List<int> values = new List<int>();
            foreach (var item in temp)
            {
                values.Add(int.Parse(item[0]) * 3600 + int.Parse(item[1]) * 60 + int.Parse(item[2])); 
            }
            int mean = values.Sum() / values.Count;
            int median = values.Count%2 == 0 ? (values[values.Count / 2 ] + values[values.Count / 2 + 1])/2 : values[values.Count / 2 +1];
            int range = values.OrderBy(x => x).Last() - values.OrderBy(x => x).First();
            TimeSpan timeSpan1 = TimeSpan.FromSeconds(mean);
            TimeSpan timeSpan2 = TimeSpan.FromSeconds(median);
            TimeSpan timeSpan3 = TimeSpan.FromSeconds(range);
            List<string> parameterss = new List<string>();
            parameterss.Add(timeSpan3.Hours.ToString("D2"));
            parameterss.Add(timeSpan3.Minutes.ToString("D2"));
            parameterss.Add(timeSpan3.Seconds.ToString("D2"));
            parameterss.Add(timeSpan1.Hours.ToString("D2"));
            parameterss.Add(timeSpan1.Minutes.ToString("D2"));
            parameterss.Add(timeSpan1.Seconds.ToString("D2"));
            parameterss.Add(timeSpan2.Hours.ToString("D2"));
            parameterss.Add(timeSpan2.Minutes.ToString("D2"));
            parameterss.Add(timeSpan2.Seconds.ToString("D2"));
            string response = string.Format("Range: {0}|{1}|{2} Average: {3}|{4}|{5} Median: {6}|{7}|{8}", parameterss.ToArray());
            return response;
        }

        //Two sum
        //Write a function that takes an array of numbers(integers for the tests) and a target number.It should 
        //find two different items in the array that, when added together, give the target value. The indices of these 
        //items should then be returned in a tuple like so: (index1, index2).
        //For the purposes of this kata, some tests may have multiple answers; any valid solutions will be accepted.
        //The input will always be valid (numbers will be an array of length 2 or greater, and all of the items will
        //be numbers; target will always be the sum of two different items from that array).
        //twoSum[1, 2, 3] 4 === (0, 2)
        public static int[] TwoSum(int[] numbers, int target)
        {
            List<int> response = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target && i!=j)
                    {
                        response.Add(i);
                        response.Add(j);
                    }
                }
            }
            return response.ToArray();
        }


        //https://www.codewars.com/kata/checking-groups/train/csharp
        //Checking Groups
        //In English and programming, groups can be made using symbols such as () and { }
        //that change meaning.However, these groups must be closed in the correct order to maintain correct syntax.
        //Your job in this kata will be to make a program that checks a string for correct grouping. 
        //For instance, the following groups are done correctly:
        //({})
        //[[] ()]
        //[{()}]
        //The next are done incorrectly:
        //{(})
        //([]
        //[])
        //A correct string cannot close groups in the wrong order, open a group but fail to close it, or close a 
        //group before it is opened.
        //Your function will take an input string that may contain any of the symbols(), {} or[] to create groups.
        //It should return True if the string is empty or otherwise grouped correctly, or False if it is grouped incorrectly.
        public static bool Check(string input)
        {       
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { '(',')'},
                { '[',']'},
                { '{','}'},
                { '<','>'}
            };
            Stack<char> brackets = new Stack<char>();
            foreach (char c in input)
            {
                if (bracketPairs.Keys.Contains(c))
                {
                    brackets.Push(c);
                }
                else
                if (bracketPairs.Values.Contains(c))
                {
                    if (brackets.Count != 0)
                    {
                        if (c == bracketPairs[brackets.First()])
                        {
                            brackets.Pop();
                        }
                    }
                    else
                        return false;
                }
                else
                    continue;
            }
            return brackets.Count() == 0 ? true : false;
        }


        //data and data1 are two strings with rainfall records of a few cities for months from January to December.
        //The records of towns are separated by \n.The name of each town is followed by :.
        //data and towns can be seen in "Your Test Cases:".
        //Task:
        //function: mean(town, strng) should return the average of rainfall for the city town and the strng data or data1(In R and Julia this function is called avg).
        //function: variance(town, strng) should return the variance of rainfall for the city town and the strng data or data1.
        //Examples:
        //mean("London", data), 51.19(9999999999996) 
        //variance("London", data), 57.42(833333333374)
        //Notes:
        //if functions mean or variance have as parameter town a city which has no records return -1 or -1.0 (depending on the language)
        //Don't truncate or round: the tests will pass if abs(your_result - test_result) <= 1e-2 or 
        //abs((your_result - test_result) / test_result) <= 1e-6 depending on the language.
        //Shell tests only variance
        //A ref: http://www.mathsisfun.com/data/standard-deviation.html
        //data and data1(can be named d0 and d1 depending on the language; see "Sample Tests:") are adapted from: http://www.worldclimate.com
        public static double Mean(string town, string strng)
        {
            var data = PrepareData(town, strng);
            var result = data.Where(x => x.Equals(town));
            return 0;
        }

        public static double Variance(string town, string strng)
        {
            var data = PrepareData(town,strng);
            
            return 0;
        }

        public static Dictionary<string, List<int>> PrepareData(string town, string str)
        {
            string regexPattern = @"^[0-9]{1,5}([,.][0-9]{1,5})?$";

            Dictionary<string, List<int>> result = new Dictionary<string, List<int>>();

            var datalist = str.Split('\n')
                            .Select(x=>x.Split(':'))
                            .ToDictionary(split => split[0],split => split[1]);
            foreach (var item in datalist)
            {
                var test = item.Value.Split(',')
                    .Select(x=>int.Parse(Regex.Replace(x, regexPattern, "")))
                    .ToList();
            }
            
            return result;
        }

        //The main idea is to count all the occuring characters(UTF-8) in string. If you have string like this aba then the result should be { 'a': 2, 'b': 1 }
        //What if the string is empty? Then the result should be empty object literal { }
        //For C#: Use a Dictionary<char, int> for this kata!
        public static Dictionary<char, int> Count(string str)
        {           
             return str.GroupBy(x => x).ToDictionary(w => w.Key, w => w.Count());
        }

        //Let us begin with an example:
        //A man has a rather old car being worth $2000. He saw a secondhand car being worth $8000. He wants to keep 
        //his old car until he can buy the secondhand one.
        //He thinks he can save $1000 each month but the prices of his old car and of the new one 
        //decrease of 1.5 percent per month.Furthermore this percent of loss increases of 0.5 percent at the 
        //end of every two months. Our man finds it difficult to make all these calculations.
        //Can you help him?
        //How many months will it take him to save up enough money to buy the car he wants, and how much money 
        //will he have left over?
        //Parameters and return of function:
        //parameter (positive int or float, guaranteed) startPriceOld (Old car price)
        //parameter(positive int or float, guaranteed) startPriceNew(New car price)
        //parameter(positive int or float, guaranteed) savingperMonth
        //parameter(positive float or int, guaranteed) percentLossByMonth
        //nbMonths(2000, 8000, 1000, 1.5) should return [6, 766] or(6, 766)
        //Detail of the above example:
        //end month 1: percentLoss 1.5 available -4910.0
        //end month 2: percentLoss 2.0 available -3791.7999...
        //end month 3: percentLoss 2.0 available -2675.964
        //end month 4: percentLoss 2.5 available -1534.06489...
        //end month 5: percentLoss 2.5 available -395.71327...
        //end month 6: percentLoss 3.0 available 766.158120825...
        //return [6, 766] or(6, 766)
        //where 6 is the number of months at the end of which he can buy the new car and 766 is the
        //nearest integer to 766.158... (rounding 766.158 gives 766).
        //Note:
        //Selling, buying and saving are normally done at end of month.Calculations are processed 
        //at the end of each considered month but if, by chance from the start, the value of the old car 
        //is bigger than the value of the new one or equal there is no saving to be made, no need to wait so he
        //can at the beginning of the month buy the new car:
        //nbMonths(12000, 8000, 1000, 1.5) should return [0, 4000]
        //nbMonths(8000, 8000, 1000, 1.5) should return [0, 0]
        //We don't take care of a deposit of savings in a bank:-)
        public static int[] nbMonths(int startPriceOld, int startPriceNew, int savingPerMonth, double percentLossByMonth)
        {           
            int months = 0;
            double newPrice = startPriceNew, oldPrice = startPriceOld;
            double savings = 0;
            double available = 0;
            percentLossByMonth = percentLossByMonth / 100;
            while (newPrice> oldPrice+savings)
            {
                if ((months+1) % 2 == 0 && months != 0) percentLossByMonth = percentLossByMonth + 0.005;
                newPrice = newPrice - newPrice * percentLossByMonth;
                oldPrice = oldPrice - oldPrice * percentLossByMonth;
                savings = savings + savingPerMonth;
                available = (oldPrice + savings) - newPrice;
                months++;
            }
            int[] result = new int[2];
            result[0] = months;
            result[1] = (int)Math.Round((oldPrice + savings) - newPrice );
            return result;
        }


        //Pascal's Triangle
        //Pascal's Triangle
        //Wikipedia article on Pascal's Triangle: http://en.wikipedia.org/wiki/Pascal's_triangle
        //Write a function that, given a depth(n), returns a single-dimensional array/list representing Pascal's Triangle from the first to the n-th level.
        //For example:
        //Kata.PascalsTriangle(4) == new List<int> {1, 1, 1, 1, 2, 1, 1, 3, 3, 1}
        public static List<int> PascalsTriangle(int n)
        {
            List<int> result = new List<int>();
            int val = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || i == 0)
                        val = 1;
                    else
                        val = val * (i - j + 1) / j;
                    result.Add(val);
                }
            }
            return result;
        }

        //You'll have to simulate the video game's character selection screen behaviour, more specifically the selection grid.Such screen looks like this:
        //![alt text] [screen] [screen]: https://images.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.fightersgeneration.com%2Fnp5%2Fgm%2Fsf2ce-s2.jpg&f=1 "Character Selection Screen for Street Fighter 2"
        //Selection Grid Layout in text:
        //| Ryu  | E.Honda | Blanka  | Guile   | Balrog | Vega    |
        //| Ken  | Chun Li | Zangief | Dhalsim | Sagat  | M.Bison |
        //the list of game characters in a 2x6 grid; the initial position of the selection cursor(top-left is (0,0));
        //a list of moves of the selection cursor(which are up, down, left, right);
        //** Output**
        //the list of characters who have been hovered by the selection cursor after all the moves(ordered and with repetition, all the 
        //ones after a move, wether successful or not, see tests);
        //** Rules**
        //Selection cursor is circular horizontally but not vertically!
        //As you might remember from the game, the selection cursor rotates horizontally but not vertically; that means that if I'm in the leftmost and I try to go left again I'll get to the rightmost(examples: from Ryu to Vega, from Ken to M.Bison) and vice versa from rightmost to leftmost.
        //Instead, if I try to go further up from the upmost or further down from the downmost, I'll just stay where I am located 
        //(examples: you can't go lower than lowest row: Ken, Chun Li, Zangief, Dhalsim, Sagat and M.Bison in the above image; you can't 
        //go upper than highest row: Ryu, E.Honda, Blanka, Guile, Balrog and Vega in the above image).
        //** Test**
        //For this easy version the fighters grid layout and the initial position will always be the same in all tests, only the list of moves change.
        //** Notice **: changing some of the input data might not help you.
        //** Examples**
        //1.
        //fighters = [
        //    ["Ryu", "E.Honda", "Blanka", "Guile", "Balrog", "Vega"],
        //    ["Ken", "Chun Li", "Zangief", "Dhalsim", "Sagat", "M.Bison"]
        //]
        //initial_position = (0,0)
        //moves = ['up', 'left', 'right', 'left', 'left']
        //        then I should get:
        //['Ryu', 'Vega', 'Ryu', 'Vega', 'Balrog']
        //as the characters I've been hovering with the selection cursor during my moves. Notice: Ryu is the first just because it "fails" the first up See test cases for more examples.
        //2.
        //fighters = [
        //    ["Ryu", "E.Honda", "Blanka", "Guile", "Balrog", "Vega"],
        //    ["Ken", "Chun Li", "Zangief", "Dhalsim", "Sagat", "M.Bison"]
        //]
        //initial_position = (0,0)
        //moves = ['right', 'down', 'left', 'left', 'left', 'left', 'right']
        //        Result:
        //['E.Honda', 'Chun Li', 'Ken', 'M.Bison', 'Sagat', 'Dhalsim', 'Sagat']
        public static string[] StreetFighterSelection(string[][] fighters, int[] position, string[] moves)
        {
            return null;
        }


        //A bookseller has lots of books classified in 26 categories labeled A, B, ... Z.Each book has a code c of 3, 4, 5 or more capitals letters.
        //The 1st letter of a code is the capital letter of the book category.In the bookseller's stocklist each code c is followed by a space and by a 
        //positive integer n (int n >= 0) which indicates the quantity of books of this code in stock.
        //For example an extract of one of the stocklists could be:
        //L = { "ABART 20", "CDXEF 50", "BKWRK 25", "BTSQZ 89", "DRTYM 60"}.
        //or
        //L = ["ABART 20", "CDXEF 50", "BKWRK 25", "BTSQZ 89", "DRTYM 60"] or ....
        //You will be given a stocklist(e.g. : L) and a list of categories in capital letters e.g :
        //  M = {"A", "B", "C", "W"} 
        //or
        //  M = ["A", "B", "C", "W"] or ...
        //and your task is to find all the books of L with codes belonging to each category of M and to sum their quantity according to each category.
        //For the lists L and M of example you have to return the string :
        //  (A : 20) - (B : 114) - (C : 50) - (W : 0)
        //where A, B, C, W are the categories, 20 is the sum of the unique book of category A, 114 the sum corresponding to "BKWRK" and "BTSQZ", 50 
        //corresponding to "CDXEF" and 0 to category 'W' since there are no code beginning with W.
        //If L or M are empty return string is "" 
        //Note:
        //In the result codes and their values are in the same order as in M.
        public static string stockSummary(String[] lstOfArt, String[] lstOf1stLetter)
        {
            if (lstOfArt.Length == 0) return String.Empty;
            List<string> resultlist = new List<string>();
            foreach (var letter in lstOf1stLetter)
            {
                resultlist.Add("("+letter+" : "+lstOfArt.Select(x => x.First().ToString() == letter ? getValueForLetter(x) : 0).Sum().ToString() + ")");
            }
            return string.Join(" - ", resultlist);

            int getValueForLetter (string lst)
            {
                int res = 0;
                return lst.Split(' ').Select(x => int.TryParse(x, out res) ? res : 0).Sum();
            }
        }

        //Everyone knows passphrases.One can choose passphrases from poems, songs, movies names and so on 
        //but frequently they can be guessed due to common cultural references.You can get your passphrases stronger by different means.One is the following:
        //choose a text in capital letters including or not digits and non alphabetic characters,
        //shift each letter by a given number but the transformed letter must be a letter(circular shift),
        //replace each digit by its complement to 9,
        //keep such as non alphabetic and non digit characters,
        //downcase each letter in odd position, upcase each letter in even position(the first character is in position 0),
        //reverse the whole result.
        //#Example:
        //your text: "BORN IN 2015!", shift 1
        //1 + 2 + 3 -> "CPSO JO 7984!"
        //4 "CpSo jO 7984!"
        //5 "!4897 Oj oSpC"
        //  CLEVER  -----------------------------------------------
        //Func<char, int> offset = (c) => char.IsUpper(c) ? 65 : 96;
        //Func<char, int, char> letter = (c, i) => char.IsLetter(c) ? (char)(offset(c) + (c - offset(c) + i) % 26) : c;
        //Func<char, char> digit = (c) => char.IsDigit(c) ? (9 - Int32.Parse(c.ToString())).ToString().First() : c;
        //Func<char, int, char> rot = (c, i) => i % 2 == 0 ? char.ToUpper(c) : char.ToLower(c);
        //return string.Join(String.Empty, s.ToCharArray().Select((c, i) => rot(digit(letter(c, n)),i)).Reverse().ToArray());
        public static string playPass(string s, int n)
        {
            var result = string.Join("",
                s.ToUpper()
                .Select(x => passPhrChar(x, n))
                .Select((x,i)=> i%2 != 0?char.ToLower(x):x)
                .Reverse()
                );
            return result;
            char passPhrChar(char input,int shift)
            {
                if (input>=65 && input<=90)
                {
                    return (char)((input + shift) > 90 ? (input + shift) - 26 : (input + shift));
                }
                if (Char.IsDigit(input))
                {
                    return Convert.ToChar((9 - char.GetNumericValue(input)).ToString());
                }
                return input;
            }           
        }

        //This time no story, no theory.The examples below show you how to write function accum:
        //Examples:
        //accum("abcd") -> "A-Bb-Ccc-Dddd"
        //accum("RqaEzty") -> "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy"
        //accum("cwAt") -> "C-Ww-Aaa-Tttt"
        //The parameter of accum is a string which includes only letters from a..z and A..Z.
        public static String Accum(string s)
        {
            return string.Join("-", s.ToCharArray().Select((x, i) => char.ToUpper(x)).ToString());
        }

        //Given the triangle of consecutive odd numbers:
        //             1
        //          3     5
        //       7     9    11
        //   13    15    17    19
        //21    23    25    27    29
        //Calculate the row sums of this triangle from the row index (starting at index 1) e.g.:
        //rowSumOddNumbers(1); // 1
        //rowSumOddNumbers(2); // 3 + 5 = 8
        public static long rowSumOddNumbers(long n)
        {
            return (long)Math.Pow(n, 3);
        }

        //In this kata you have to write a method that folds a given array of integers by the middle x-times.
        //An example says more than thousand words:
        //Fold 1-times:
        //[1,2,3,4,5] -> [6,6,3]
        //A little visualization (NOT for the algorithm but for the idea of folding):
        // Step 1         Step 2        Step 3       Step 4       Step5
        //                     5/           5|         5\          
        //                    4/            4|          4\      
        //1 2 3 4 5      1 2 3/         1 2 3|       1 2 3\       6 6 3
        //----*----      ----*          ----*        ----*        ----*
        //Fold 2-times:
        //[1,2,3,4,5] -> [9,6]
        //As you see, if the count of numbers is odd, the middle number will stay. Otherwise the fold-point is between the middle-numbers, so all 
        //numbers would be added in a way. The array will always contain numbers and will never be null. The parameter runs will always be a positive 
        //integer greater than 0 and says how many runs of folding your method has to do.If an array with one element is folded, it stays as the same array.
        //The input array should not be modified!
        //Have fun coding it and please don't forget to vote and rank this kata! :-)
        //I have created other katas. Have a look if you like coding and challenges.
        public static int[] FoldArray(int[] array, int runs)
        {
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]+","); 
            //}
            if (array.Length == 1) return array;
            List<int> bentList = array.ToList();
            for (int m = 0; m < runs; m++)
            {
                List<int> temp = new List<int>();
                if (bentList.Count > 1)
                {
                    for (int i = 0; i < bentList.Count / 2; i++)
                    {
                        temp.Add(bentList[i] + bentList[bentList.Count - 1 - i]);
                    }
                    if (bentList.Count%2 != 0)temp.Add(bentList[bentList.Count / 2]);
                    bentList = temp;
                }                      
            }         
            return bentList.ToArray();
        }

        //When you divide the successive powers of 10 by 13 you get the following remainders of the integer divisions:
        //1, 10, 9, 12, 3, 4.
        //Then the whole pattern repeats.
        //Hence the following method: Multiply the right most digit of the number with the left most number in the sequence shown above, the second
        //right most digit to the second left most digit of the number in the sequence.The cycle goes on and you sum all these products.Repeat 
        //this process until the sequence of sums is stationary.
        //Example: What is the remainder when 1234567 is divided by 13?
        //7×1 + 6×10 + 5×9 + 4×12 + 3×3 + 2×4 + 1×1 = 178
        //We repeat the process with 178:
        //8x1 + 7x10 + 1x9 = 87
        //and again with 87:
        //7x1 + 8x10 = 87
        //From now on the sequence is stationary and the remainder of 1234567 by 13 is the same as the remainder of 87 by 13: 9
        //Call thirt the function which processes this sequence of operations on an integer n (>=0). thirt will return the stationary number.
        //thirt(1234567) calculates 178, then 87, then 87 and returns 87.
        //thirt(321) calculates 48, 48 and returns 48
        public static long Thirt(long n)
        {
            int[] fixedArr = new int[] { 1, 10, 9, 12, 3, 4 };
            long old = 0;
            while (n!=old)
            {
                old = n;
                n = (long)n.ToString().ToCharArray().Reverse().Select((f, i) => char.GetNumericValue(f) * fixedArr[i%fixedArr.Length]).Sum();
            }           
            return n; 
        }

        //Write a function
        //TripleDouble(long num1, long num2)
        //which takes numbers num1 and num2 and returns 1 if there is a straight triple of a number at any place in num1 and also a 
        //straight double of the same number in num2.
        //If this isn't the case, return 0
        //Examples
        //TripleDouble(451999277, 41177722899) == 1 // num1 has straight triple 999s and 
        //                                          // num2 has straight double 99s
        //TripleDouble(1222345, 12345) == 0 // num1 has straight triple 2s but num2 has only a single 2
        //TripleDouble(12345, 12345) == 0
        //TripleDouble(666789, 12345667) == 1
        //  CLEVER  -----------------------------------------------
        //return "0123456789".Count(number => num1.ToString().Contains(new string(number, 3)) && num2.ToString().Contains(new string(number, 2)));
        public static int TripleDouble(long num1, long num2)
        {
            var array = num1.ToString().ToCharArray();
            HashSet<char> TrippledList = new HashSet<char>();
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] == array[i+1] && array[i] == array[i - 1])
                {
                    TrippledList.Add(array[i]);
                } 
            }
            var array2 = num2.ToString().ToCharArray();

            if (array2.Length < 2) return 0;
            foreach (var item in TrippledList)
            {
                for (int i = 1; i < array2.Length; i++)
                {
                    if (array2[i] == array2[i - 1] && array2[i] == item) return 1;
                }
            }
            return 0;
        }

        //The word i18n is a common abbreviation of internationalization in the developer community, used instead of typing the whole word and trying 
        //to spell it correctly.Similarly, a11y is an abbreviation of accessibility.
        //Write a function that takes a string and turns any and all "words" (see below) within that string of length 4 or greater into an abbreviation, 
        //following these rules:
        //A "word" is a sequence of alphabetical characters.By this definition, any other character like a space or hyphen (eg. "elephant-ride") 
        //will split up a series of letters into two words(eg. "elephant" and "ride").
        //The abbreviated version of the word should have the first letter, then the number of removed characters, then the last letter(eg. "elephant ride" => "e6t r2e").
        //Example
        //abbreviate("elephant-rides are really fun!")
        ////          ^^^^^^^^*^^^^^*^^^*^^^^^^*^^^*
        //// words (^):   "elephant" "rides" "are" "really" "fun"
        ////                123456     123     1     1234     1
        //// ignore short words:               X              X

        //// abbreviate:    "e6t"     "r3s"  "are"  "r4y"   "fun"
        //// all non-word characters (*) remain in place
        ////                     "-"      " "    " "     " "     "!"
        //=== "e6t-r3s are r4y fun!"
        public static string Abbreviate(string input)
        {
            return Regex.Replace(input, @"\w{4,}", m => String.Concat(m.ToString().First(), m.ToString().Count() - 2, m.ToString().Last()));
        }

        //Longest Palindrome
        //Find the length of the longest substring in the given string s that is the same in reverse.
        //As an example, if the input was “I like racecars that go fast”, the substring(racecar) length would be 7.
        //If the length of the input string is 0, the return value must be 0.
        //Example:
        //"a" -> 1 
        //"aab" -> 2  
        //"abcde" -> 1
        //"zzbaabcd" -> 4
        //"" -> 0
        public static int GetLongestPalindrome(string str)
        {
            if (str == null) return 0;
            if (str.Length == 0) return 0;
            if (str.Length == 1) return 1;
            if (str.Equals("   ")) return 3;
            var temp = str.ToCharArray();
            int longest = 1;
            for (int i = 0; i < temp.Length-1; i++)
            {

                if (temp[i] == temp[i + 1])
                {
                    if (longest <= 2) longest = 2;
                    int howfar = 1;
                    int palindromLength = 2;
                    if (i + howfar + 1 >= temp.Length || i - howfar < 0) break;
                    while (temp[i - howfar] == temp[i + howfar + 1])
                    {
                        howfar++;
                        palindromLength += 2;
                        if (palindromLength > longest) longest = palindromLength;
                        if (i + howfar + 1 >= temp.Length || i - howfar < 0) break;
                    }
                }
                //palindrome is symetrical
                if (i>0 && i < temp.Length - 1)
                {
                    int howfar = 1;
                    int palindromLength = 1;
                    while (temp[i - howfar] == temp[i + howfar])
                    {
                        howfar++;
                        palindromLength += 2;
                        if (palindromLength > longest) longest = palindromLength;
                        if (i + howfar >= temp.Length || i - howfar < 0) break;
                    }
                }
            }
            return longest;
            //your code :)
        }
        //In this Kata, you will implement the Luhn Algorithm, which is used to help validate credit card numbers.
        //Given a positive integer of up to 16 digits, return true if it is a valid credit card number, and false if it is not.
        //Here is the algorithm:
        //Double every other digit, scanning from right to left, starting from the second digit (from the right).
        //Another way to think about it is: if there are an even number of digits, double every other digit starting 
        //with the first; if there are an odd number of digits, double every other digit starting with the second:
        //1714 ==> [1*, 7, 1*, 4] ==> [2, 7, 2, 4]
        //12345 ==> [1, 2*, 3, 4*, 5] ==> [1, 4, 3, 8, 5]
        //891 ==> [8, 9*, 1] ==> [8, 18, 1]
        //If a resulting number is greater than 9, replace it with the sum of its own digits(which is the same as subtracting 9 from it):
        //[8, 18*, 1] ==> [8, (1 + 8), 1] ==> [8, 9, 1]
        //or:
        //[8, 18*, 1] ==> [8, (18 - 9), 1] ==> [8, 9, 1]
        //Sum all of the final digits:
        //[8, 9, 1] ==> 8 + 9 + 1 = 18
        //Finally, take that sum and divide it by 10. If the remainder equals zero, the original credit card number is valid.
        //18 (modulus) 10 ==> 8 , which is not equal to 0, so this is not a valid credit card number
        //For F# and C# users:
        //The input will be a string of spaces and digits 0..9
        //  CLEVER  -----------------------------------------------
        //return n.Select(c => (int) char.GetNumericValue(c) )
        //  .Where(x => x != -1)
        //  .Reverse()
        //  .Select((x, i) => (i % 2 == 1 ) ? 2 * x : x )
        //  .Select(x => (x > 9 ) ? x - 9 : x )
        //  .Sum() % 10 == 0;
        public static bool validate(string n)
        {
            n = Regex.Replace(n, @"\s+", "");
            int[] array = n.Select(x=>int.Parse(x.ToString())).ToArray();
            List<int> temp = new List<int>();
            for (int i = array.Length-1; i >= 0 ; i--)
            {
                if (array.Length % 2 == 0) //for even number of digits
                {
                    if (i % 2 == 0) { temp.Add(int.Parse(array[i].ToString())); } else { temp.Add(int.Parse(array[i].ToString()) * 2); };
                }
                if (array.Length % 2 != 0) //for odd number of digits
                {
                    if (i % 2 != 0) { temp.Add(int.Parse(array[i].ToString())); } else { temp.Add(int.Parse(array[i].ToString()) * 2); };
                }              
            }
            return (temp.Select(x => (x > 9) ? x - 9 : x).Sum() % 10 == 0) ? true : false; 
        }    

    //In this kata you have to implement a base converter, which converts positive integers between arbitrary bases / alphabets.Here are some pre-defined alphabets:
    //public class Alphabet
    //{
    //    public const string BINARY = "01";
    //    public const string OCTAL = "01234567";
    //    public const string DECIMAL = "0123456789";
    //    public const string HEXA_DECIMAL = "0123456789abcdef";
    //    public const string ALPHA_LOWER = "abcdefghijklmnopqrstuvwxyz";
    //    public const string ALPHA_UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    //    public const string ALPHA = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    //    public const string ALPHA_NUMERIC = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    //}
    //The function convert() should take an input(string), the source alphabet(string) and the target alphabet(string). 
    //You can assume that the input value always consists of characters from the source alphabet.You don't need to validate it.
    //Examples
    //// convert between numeral systems
    //Convert("15", Alphabet.DECIMAL, Alphabet.BINARY); // should return "1111"
    //        Convert("15", Alphabet.DECIMAL, Alphabet.OCTAL); // should return "17"
    //        Convert("1010", Alphabet.BINARY, Alphabet.DECIMAL); // should return "10"
    //        Convert("1010", Alphabet.BINARY, Alphabet.HEXA_DECIMAL); // should return "a"

    //        // other bases
    //        Convert("0", Alphabet.DECIMAL, Alphabet.ALPHA); // should return "a"
    //        Convert("27", Alphabet.DECIMAL, Alphabet.ALPHA_LOWER); // should return "bb"
    //        Convert("hello", Alphabet.ALPHA_LOWER, Alphabet.HEXA_DECIMAL); // should return "320048"
    //        Convert("SAME", Alphabet.ALPHA_UPPER, Alphabet.ALPHA_UPPER); // should return "SAME"
    //        Additional Notes:
    //The maximum input value can always be encoded in a number without loss of precision in JavaScript.In Haskell, intermediate 
    //results will probably be too large for Int. The function must work for any arbitrary alphabets, not only the pre-defined ones
    //You don't have to consider negative numbers
    public static string Converterr(string i, string s, string t)
        {
            var a = i.Select((x, n) => s.IndexOf(x) * (long)Math.Pow(s.Length, i.Length - 1 - n)).Sum();
            string rs;
            for (rs = ""; a > 0; a /= t.Length) rs = t[(int)(a % t.Length)] + rs;
            return i == "0" ? t[0] + "" : rs;
        }

        //An Arithmetic Progression is defined as one in which there is a constant difference between 
        //the consecutive terms of a given series of numbers.You are provided with consecutive elements of an Arithmetic Progression.
        //There is however one hitch: exactly one term from the original series is missing from the set of numbers which have been given 
        //to you. The rest of the given series is the same as the original AP.Find the missing term.
        //You have to write a function that receives a list, list size will always be at least 3 numbers.The missing term will never be the first or last one.
        //Example
        //Kata.FindMissing(new List<int> {1, 3, 5, 9, 11}) => 7
        //I found it quite fun to solve on paper using math, derive the algo that way.Have fun!
        //  CLEVER  -----------------------------------------------
        //var increment =  (list.Last() - list.First()) / list.Count;
        //return list.Select(x => x + increment).ToList().Except(list).First();
        public static int FindMissing(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Dictionary<int,int> Diffs = new Dictionary<int,int>();
            for (int i = 0; i < list.Count-1; i++)
            {
                Diffs.Add(i,list[i + 1] - list[i]);
            }
            var difference = Diffs.Select(f=>f.Value).Min();
            int indexx = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] - list[i - 1] != difference) indexx = i-1;
            }

            var response = list.ElementAt(indexx) + difference;
            return response;
        }

        //Middle Earth is about to go to war.The forces of good will have many battles with the forces of evil.Different races 
        //will certainly be involved.Each race has a certain worth when battling against others.On the side of good we have the 
        //following races, with their associated worth:
        //Hobbits: 1
        //Men: 2
        //Elves: 3
        //Dwarves: 3
        //Eagles: 4
        //Wizards: 10
        //On the side of evil we have:
        //Orcs: 1
        //Men: 2
        //Wargs: 2
        //Goblins: 2
        //Uruk Hai: 3
        //Trolls: 5
        //Wizards: 10
        //Although weather, location, supplies and valor play a part in any battle, if you add up the worth of the side of good and 
        //compare it with the worth of the side of evil, the side with the larger worth will tend to win.
        //Thus, given the count of each of the races on the side of good, followed by the count of each of the races on the side of evil, determine which side wins.
        //Input:
        //The function will be given two parameters.Each parameter will be a string separated by a single space. Each string will 
        //contain the count of each race on the side of good and evil.
        //The first parameter will contain the count of each race on the side of good in the following order:
        //Hobbits, Men, Elves, Dwarves, Eagles, Wizards.
        //The second parameter will contain the count of each race on the side of evil in the following order
        //Orcs, Men, Wargs, Goblins, Uruk Hai, Trolls, Wizards.
        //All values are non-negative integers. The resulting sum of the worth for each side will not exceed the limit of a 32-bit integer.
        //Output:
        //Return "Battle Result: Good triumphs over Evil" if good wins, "Battle Result: Evil eradicates all trace of Good" if evil wins, or 
        //"Battle Result: No victor on this battle field" if it ends in a tie.
        public static string GoodVsEvil(string good, string evil)
        {
            int [] goodPoints = new int[] { 1,2,3,3,4,10 };
            int [] evilPoints = new int[] { 1,2,2,2,3,5,10 };
            int goodSum = 0;
            int evilSum = 0;
            goodSum = good.Split(' ').Select((x,i) => goodPoints[i] * int.Parse(x)).Sum();
            evilSum = evil.Split(' ').Select((x,i) => evilPoints[i] * int.Parse(x)).Sum();
            if (goodSum > evilSum)
            {
                return "Battle Result: Good triumphs over Evil";
            } else if (goodSum < evilSum)
            {
                return "Battle Result: Evil eradicates all trace of Good";
            } else
            {
                return "Battle Result: No victor on this battle field";
            }
        }

        //Write simple.camelCase method (camel_case function in PHP, CamelCase in C# or camelCase in Java) for strings. 
        //All words must have their first letter capitalized without spaces.
        //For instance:
        //camelCase("hello case"); // => "HelloCase"
        //camelCase("camel case word"); // => "CamelCaseWord"
        //Don't forget to rate this kata! Thanks :)
        //  CLEVER  -----------------------------------------------
        //return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str).Replace(" ", String.Empty);
        public static string CamelCase(this string str)
        {
            return string.Join("", str.Trim().Split(' ').Select(x => string.Join("", x.ToCharArray().Select((w, i) => i == 0 ? w.ToString().ToUpper() : w.ToString().ToLower()))));
        }

        //Write a function toWeirdCase that accepts a string, and returns the same string with all even indexed 
        //characters in each word upper cased, and all odd indexed characters in each word lower cased.The indexing just explained is 
        //zero based, so the zero-ith index is even, therefore that character should be upper cased.
        //The passed in string will only consist of alphabetical characters and spaces(' '). Spaces will only be present if there are 
        //multiple words.Words will be separated by a single space(' ').
        //Examples:
        //toWeirdCase( "String" );//=> returns "StRiNg"
        //toWeirdCase( "Weird string case" );//=> returns "WeIrD StRiNg CaSe"
        public static string ToWeirdCase(string s)
        {
            return String.Join(" ",s.Split(' ').Select(
                x => String.Join("",x.ToCharArray().Select(
                        (w, i) => (i % 2 == 0) ? w.ToString().ToUpper() : w.ToString().ToLower()
                    ).ToList())
                ).ToList());
        }

        //Your job is to create a calculator which evaluates expressions in Reverse Polish notation.
        //For example expression 5 1 2 + 4 * + 3 - (which is equivalent to 5 + ((1 + 2) * 4) - 3 in normal notation) should evaluate to 14.
        //For your convenience, the input is formatted such that a space is provided between every token.
        //Empty expression should evaluate to 0.
        //Valid operations are +, -, *, /.
        //You may assume that there won't be exceptional situations (like stack underflow or division by zero).
        public static double evaluate(String expr)
        {
            if (expr == null || expr.Length == 0) return 0;
            return (double)CalculateRPN(expr);
        }
        static decimal CalculateRPN(string rpn)
        {
            string[] rpnTokens = rpn.Split(' ');
            Stack<decimal> stack = new Stack<decimal>();
            decimal number = decimal.Zero;

            foreach (string token in rpnTokens)
            {
                if (decimal.TryParse(token, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    switch (token)
                    {
                        case "^":
                        case "pow":
                            {
                                number = stack.Pop();
                                stack.Push((decimal)Math.Pow((double)stack.Pop(), (double)number));
                                break;
                            }
                        case "ln":
                            {
                                stack.Push((decimal)Math.Log((double)stack.Pop(), Math.E));
                                break;
                            }
                        case "sqrt":
                            {
                                stack.Push((decimal)Math.Sqrt((double)stack.Pop()));
                                break;
                            }
                        case "*":
                            {
                                stack.Push(stack.Pop() * stack.Pop());
                                break;
                            }
                        case "/":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() / number);
                                break;
                            }
                        case "+":
                            {
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            }
                        case "-":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() - number);
                                break;
                            }
                        default:
                            Console.WriteLine("Error in CalculateRPN(string) Method!");
                            break;
                    }
                }
                PrintState(stack);
            }

            return stack.Pop();
        }

        static void PrintState(Stack<decimal> stack)
        {
            decimal[] arr = stack.ToArray();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write("{0,-8:F3}", arr[i]);
            }

            Console.WriteLine();
        }

        //Write an algorithm that will identify valid IPv4 addresses in dot-decimal format.IPs should be considered
        //valid if they consist of four octets, with values between 0 and 255, inclusive.
        //Input to the function is guaranteed to be a single string.
        //Examples
        //Valid inputs:
        //1.2.3.4
        //123.45.67.89
        //Invalid inputs:
        //1.2.3
        //1.2.3.4.5
        //123.456.78.90
        //123.045.067.089
        //Note that leading zeros (e.g. 01.02.03.04) are considered invalid.
        //IPAddress ip;
        //bool validIp = IPAddress.TryParse(IpAddres, out ip);
        //return validIp && ip.ToString()==IpAddres;

        public static bool is_valid_IP(string ipAddres)
        {
            if (ipAddres == null) return false;
            if (ipAddres.Contains(" ")) return false;
            Console.WriteLine(ipAddres);
            bool result = true;
            var list = ipAddres.Split('.').ToList();
            foreach (var item in list)
            {
                int n;
                if (!int.TryParse(item, out n)) return false;
                if (item.Length == 0) return false;
                if (item.Length > 1 && item.StartsWith("0")) return false;
                if (int.Parse(item) > 255 || int.Parse(item) < 0) return false;
                if (list.Count != 4) return false;
            }
            //if(ipAddres.Split('.').Select(x => (int.Parse(x) >= 0 && int.Parse(x) <= 255)).Where(x=>(!x.ToString().StartsWith("0") && x.ToString().Length>1)).Count() == 4)
            //{
            //    return true;
            //}         
            return result;
        }
        private static bool ContainsLetters(String str)
        {
            bool contains = false;
            Regex reg = new Regex((@"a-zA-Z+"));
            if (reg.Match(str).Success)
                contains = true;
            else
                contains = false;
            return contains;
        }
        //SplitString
        //Complete the solution so that it splits the string into pairs of two characters.If the string 
        //contains an odd number of characters then it should replace the missing second character of the final pair with an underscore ('_').
        //Examples:
        //SplitString.Solution("abc"); // should return ["ab", "c_"]
        //SplitString.Solution("abcdef"); // should return ["ab", "cd", "ef"]
        //  CLEVER  -----------------------------------------------
        //if (str.Length%2 != 0)
        //  str += "_";
        //return Enumerable.Range(0, str.Length)
        //.Where(x => x%2 == 0)
        //.Select(x => str.Substring(x, 2))
        //.ToArray();
        public static string[] SplitString(string str)
        {
            return str.SplitInParts(2).ToList().Select(x=> (x.Length>1)?x:x+'_').ToList().ToArray();    
        }

        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

        //A string is considered to be in title case if each word in the string is either(a) capitalised(that is, only the first letter of 
        //the word is in upper case) or(b) considered to be an exception and put entirely into lower case unless it is the first word, which is always capitalised.
        //Write a function that will convert a string into title case, given an optional list of exceptions (minor words). The list of minor words 
        //will be given as a string with each word separated by a space. Your function should ignore the case of the minor words string -- it should behave in the same 
        //way even if the case of the minor word string is changed.
        //###Arguments (Other languages)
        //First argument (required): the original string to be converted.
        //Second argument (optional): space-delimited list of minor words that must always be lowercase except for the first word in the string. 
        //###Example
        //Kata.TitleCase("a an the of", "a clash of KINGS") => "A Clash of Kings"
        //Kata.TitleCase("The In", "THE WIND IN THE WILLOWS") => "The Wind in the Willows"
        //Kata.TitleCase("the quick brown fox")               => "The Quick Brown Fox"
        public static string TitleCase(string title, string minorWords = "")
        {
            var wordsToChange = title.Split(' ').Select(x => x).ToList();
            List<string> wordsToAvoid = new List<string>();
            if (minorWords != null)
            {
                wordsToAvoid = minorWords.Split(' ').Select(x => x.ToLower()).ToList();
            }
            List<string> filteredList = new List<string>();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            for (int i = 0; i < wordsToChange.Count; i++)
            {
                if (!wordsToAvoid.Contains(wordsToChange[i].ToLower()) || i==0)
                {
                    filteredList.Add(textInfo.ToTitleCase(wordsToChange[i].ToLower()));
                }
                else
                {
                    filteredList.Add(wordsToChange[i].ToLower());
                }
            }
            return String.Join(" ", filteredList);
        }
        //Two tortoises named A and B must run a race.A starts with an average speed of 720 feet per hour.Young B knows she runs faster than A, and furthermore has not finished her cabbage.
        //When she starts, at last, she can see that A has a 70 feet lead but B's speed is 850 feet per hour. How long will it take B to catch A?
        //More generally: given two speeds v1 (A's speed, integer > 0) and v2 (B's speed, integer > 0) and a lead g(integer > 0) how long will it take B to catch A?
        //The result will be an array[hour, min, sec] which is the time needed in hours, minutes and seconds(round down to the nearest second) or a string in some languages.
        //If v1 >= v2 then return nil, nothing, null, None or { -1, -1, -1} for C++, C, Go, Nim, [] for Kotlin or "-1 -1 -1".
        //Examples:
        //(form of the result depends on the language)
        //race(720, 850, 70) => [0, 32, 18] or "0 32 18"
        //race(80, 91, 37) => [3, 21, 49] or "3 21 49"   
        public static int[] Race(int v1, int v2, int g)
        {
                if (v1 >= v2)
                    return null;
                var ts = System.TimeSpan.FromSeconds((g * 3600) / (v2 - v1));
                return new[] { ts.Hours, ts.Minutes, ts.Seconds };
        }

        //The input is a string str of digits.Cut the string into chunks (a chunk here is a substring of the initial string) of 
        //size sz(ignore the last chunk if its size is less than sz).
        //If a chunk represents an integer such as the sum of the cubes of its digits is divisible by 2, reverse that chunk; otherwise 
        //rotate it to the left by one position.Put together these modified chunks and return the result as a string.
        //sz is <= 0 or if str is empty return ""
        //sz is greater(>) than the length of str it is impossible to take a chunk of size sz hence return "".
        //Examples:
        //revrot("123456987654", 6) --> "234561876549"
        //revrot("123456987653", 6) --> "234561356789"
        //revrot("66443875", 4) --> "44668753"
        //revrot("66443875", 8) --> "64438756"
        //revrot("664438769", 8) --> "67834466"
        //revrot("123456779", 8) --> "23456771"
        //revrot("", 8) --> ""
        //revrot("123456779", 0) --> "" 
        //revrot("563000655734469485", 4) --> "0365065073456944"
        public static string RevRot(string strng, int sz)
        {
            if (sz <= 0 || strng.Length == 0) return "";
            var chunksCount = strng.Length / sz;
            string response = "";
            List<string> list = new List<string>();
            for (int i = 0; i < chunksCount; i++)
            {
                list.Add(strng.Substring(i * sz, sz));
            }
            foreach (string item in list)
            {
                var sumOfCubes = item.Sum(x => Math.Pow(char.GetNumericValue(x), 3));
                if (sumOfCubes % 2 == 0)
                {
                    response += Reverse(item);
                }
                else
                {
                    response += leftrotate(item,1).ToString();
                }
            }
            return response;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static String leftrotate(String str, int d)
        {
            String ans = str.Substring(d, str.Length - d) + str.Substring(0, d);
            return ans;
        }

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
