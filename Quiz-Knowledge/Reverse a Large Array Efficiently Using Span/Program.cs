using System.Collections.Generic;
using System.Xml.Linq;

namespace Reverse_a_Large_Array_Efficiently_Using_Span
{
    // Original array (first 10 elements): [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
    // Reversed array(first 10 elements): [10, 9, 8, 7, 6, 5, 4, 3, 2, 1]

    internal class Program
    {
        static void Main(string[] args)
        {
            Span<int> span = new([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);

            foreach (var item in span)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            for (int i = 0, j = span.Length - 1; i < j; i++, j--)
            {
                int temp = span[i];
                span[i] = span[j];
                span[j] = temp;
            }

            Console.WriteLine("Reversed array(first 10 elements):");

            foreach (var item in span)
            {
                Console.Write(item + " ");
            }
        }
    }
}
