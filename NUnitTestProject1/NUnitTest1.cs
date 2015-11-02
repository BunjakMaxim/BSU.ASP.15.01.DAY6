using System;
using System.Collections;
using Task3BubbleShort;
using NUnit.Framework;

namespace NUnitTestProject1
{
    [TestFixture]
    public class NUnitTest1
    {
        private static int Max(int[] a)
        {
            int y = a[0];
            for(int i = 1; i < a.Length; i++)
                if(y < a[i])
                    y = a[i];
            return y;
        }
        private static int Sum(int[] a)
        {
            int y = 0;
            for (int i = 0; i < a.Length; i++)
                y += a[i];
            
            return y;
        }
        public static int[] CalcKey(int[][] array, Func<int[], int> g)
        {
            int[] key = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
                key[i] = g(array[i]);

            return key;
        }

        private static int ComparerMax(int[]a, int[]b)
        {
            return Max(a) - Max(b);
        }
        private static int ComparerSum(int[] a, int[] b)
        {
            return Sum(a) - Sum(b);
        }


        [Test]
        public void TestBubbleSort()
        {
            int[][] array = {
                                new int[]{11,33,5,15,64},//64         // 128
                                new int[]{22,99,7,32},  //99         // 160
                                new int[]{2,55,1},     //55         // 58
                                new int[]{11,55,87,3,6,99,312}//312// 573
                            };

            Task3BubbleShort.Bubble.Sort(array, (new BubleSortMax()));
            Assert.AreEqual(CalcKey(array, Max), new int[] { 55, 64, 99, 312 });

            Task3BubbleShort.Bubble.Sort(array, new BubbleSortSum());
            Assert.AreEqual(CalcKey(array, Sum), new int[] { 58, 128, 160, 573});
            
            Task3BubbleShort.Bubble.Sort(array, ComparerMax);
            Assert.AreEqual(CalcKey(array, Max), new int[] { 55, 64, 99, 312 });

            Task3BubbleShort.Bubble.Sort(array, ComparerSum);
            Assert.AreEqual(CalcKey(array, Sum), new int[] { 58, 128, 160, 573 });
        }


        [Test]
        public void TestBubbleSortNullAray()
        {
            int[][] array = {
                                new int[]{11,33,5,15,64}, // 64  // 128
                                new int[]{0},              //0
                                new int[]{2,55,1},           //55 //58
                                new int[]{11,55,87,3,6,99,312}//312  //573
                            };

            Task3BubbleShort.Bubble.Sort(array, (new BubleSortMax()));
            Assert.AreEqual(CalcKey(array, Max), new int[] { 0, 55, 64, 312 });

            Task3BubbleShort.Bubble.Sort(array, new BubbleSortSum());
            Assert.AreEqual(CalcKey(array, Sum), new int[] { 0, 58, 128, 573 });

            Task3BubbleShort.Bubble.Sort(array, ComparerMax);
            Assert.AreEqual(CalcKey(array, Max), new int[] { 0, 55, 64, 312 });

            Task3BubbleShort.Bubble.Sort(array, ComparerSum);
            Assert.AreEqual(CalcKey(array, Sum), new int[] { 0, 58, 128, 573 });
        }
    }
}