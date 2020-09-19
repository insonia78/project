using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SampleNamespace
{
    public class SampleClass
    {
        public static void Main()
        {
            var array = Source.GetSource();
            Console.WriteLine(Partition(array, 0, array.Count));
        }      
        
        private static int Partition(IList<int> a, int l, int r)
        {
            if (l == r)
            {
                return 0;
            }

            var pivotIndex = ChoosePivot(a, l, r);
            Swap(a, l, pivotIndex);
            var pivot = a[l];
            var i = l + 1;
            for (var j = l + 1; j < r; j++)
            {
                if (a[j] < pivot)
                {
                    Swap(a, i, j);
                    i++;
                }
            }

            Swap(a, l, i - 1);

            return r - l - 1 + Partition(a, l, i - 1) + Partition(a, i, r);
        }

        public static int ChoosePivot(IList<int> a, int l, int r)
        {
            // Define the center of an array
            var middle = ((r - l) % 2 == 0) ? l + (r - l) / 2 - 1 : l + (r - l - 1) / 2;
            // Array of first, middle and last element
            var x = new List<int> {a[l], a[middle], a[r - 1]};
            x.Sort();
            // Take index of the medianeÃ
            return a[l] == x[1] ? l : a[middle] == x[1] ? middle : r - 1;
        }

        private static IList<int> Swap(IList<int> a, int i, int j)
        {
            var x = a[i];
            a[i] = a[j];
            a[j] = x;
            return a;
        }
    }
}

