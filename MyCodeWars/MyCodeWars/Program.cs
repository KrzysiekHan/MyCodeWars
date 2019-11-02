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
            _6KYU.Anagrams("a", new List<string> { "a", "b", "c", "d" }); // correct answear a
            _6KYU.Anagrams("racer", new List<string> { "carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr" }); //answear "carer", "arcre", "carre"
        }
    }
}
