using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3BubbleShort
{
    class BubbleSortCompararToDelegate
    {
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            Sort(array, comparer.Compare);
        }

        private static void Sort(int[][] array, Func<int[], int[], int> comparer)
        {
            int iEnd = array.Length - 1;

            while (0 < iEnd)
            {
                for (int j = 0; j < iEnd; j++)
                    if (comparer(array[j], array[j + 1]) > 0)
                    {
                        int[] a = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = a;
                    }
                iEnd--;
            }
        }
    }
}
