using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Task3BubbleShort
{
    public static class Bubble
    {
        public static void Sort(int[][] array, IComparer<int[]> comparer)
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
