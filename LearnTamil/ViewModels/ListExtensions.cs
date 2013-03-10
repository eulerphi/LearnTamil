using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class ListExtensions
    {
        private static Random random = new Random();

        public static void ShuffleSort<T>(this List<T> source)
        {
            for (var i = 0; i < source.Count; i++)
            {
                var indexToSwapWith = random.Next(i, source.Count);
                var temp = source[i];
                source[i] = source[indexToSwapWith];
                source[indexToSwapWith] = temp;
            }
        }
    }
}
