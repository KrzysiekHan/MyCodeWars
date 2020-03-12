using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeWars
{
    public static class Extensions
    {
        /// <summary>
        /// Sprawdza czy wszystkie elementy w stringu są literami
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isPlainWord(this string str)
        {
            return str.All(x => char.IsLetter(x));
        }

        /// <summary>
        /// Metoda spłaszczająca wielowymiarową tablicę (robi z niej listę wartości)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this T[,] target)
        {
            foreach (var item in target)
                yield return item;
        }
        /// <summary>
        /// Metoda pobierająca z wielowymiarowej tablicy listę tablic spełniających określony warunek
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Wielowymiarowa tablica z której pobrane będą inne</param>
        /// <param name="predicate">Warunek w postaci lambdy</param>
        /// <returns>Lista tablic</returns>
        public static IEnumerable<T[]> Filter<T>(T[,] source, Func<T[], bool> predicate)
        {
            for (int i = 0; i < source.GetLength(0); ++i)
            {
                T[] values = new T[source.GetLength(1)];
                for (int j = 0; j < values.Length; ++j)
                {
                    values[j] = source[i, j];
                }
                if (predicate(values))
                {
                    yield return values;
                }
            }
        }
    }
}
