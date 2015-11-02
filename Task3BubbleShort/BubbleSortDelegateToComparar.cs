using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace Task3BubbleShort
{
    class BubbleSortDelegateToComparar
    {
        class Comparer : IComparer<int[]>
        {
            Func<int[], int[], int> d;
            
            public Comparer(Func<int[], int[], int> d)
            {
                this.d = d;
            }

            public int Compare(int[] x, int[] y)
            {
                return d(x, y);
            }
        }

        private static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            int iEnd = array.Length - 1;

            while (0 < iEnd)
            {
                for (int j = 0; j < iEnd; j++)
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        int[] a = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = a;
                    } 
                iEnd--;
            }
        }

        public static void Sort(int[][] array, Func<int[], int[], int> comparer)
        {
            Sort(array, new Comparer(comparer));
        }
    }
}
