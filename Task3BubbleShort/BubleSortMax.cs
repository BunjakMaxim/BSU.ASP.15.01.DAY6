using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3BubbleShort
{
    public class BubleSortMax : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x.Max() - y.Max();
        }
    }
}
