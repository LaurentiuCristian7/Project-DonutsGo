using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Class1
    {
        int[] arr = new int[] { 9, 8, 41, 10, 130 };
        int n = 5, i, j, x;
        Console.WriteLine("Insertion Sort");
            Console.Write("Initial array is: ");
            for (i = 0; i<n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            for (i = 1; i<n; i++)
            {
                x = arr[i];
                for (j = i - 1; j >= 0;)
                {
                    if (x<arr[j])
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = x;
                    }
                       else

                       {
                        break;
                        }
            }
            Console.Write("\nSorted Array is: ");
                for (i = 0; i < n; i++)
                {
                  Console.Write(arr[i] + " ");
                }

    }
}
