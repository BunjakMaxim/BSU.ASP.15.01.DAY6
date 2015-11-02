using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3BubbleShort
{
    public class BubbleSortSum : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x.Sum() - y.Sum();
        }
    }
}
