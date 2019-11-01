using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
    public static class _6KYU
    {
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
