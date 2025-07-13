namespace Execution_In_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This happens because of deferred execution in LINQ.The Select projection(IEnumerable<int> numbers2) doesn’t evaluate
            // immediately.It’s re-evaluated each time it’s iterated. So when you modify the original array after
            // defining the LINQ query but before the foreach, the changes are reflected in the output. That’s why 
            // the first number is now doubled as 20, not 2.

            int[] numbers = new int[] { 1, 2, 3 };

            IEnumerable<int> numbers2 = numbers.Select(x => x * 2);

            numbers[0] = 10;

            foreach (int item in numbers2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 50));

            IEnumerator<int> numbers3 = numbers2.GetEnumerator();
            while (numbers3.MoveNext())
            {
                Console.WriteLine(numbers3.Current);
            }

            // The Count property is not available for IEnumerable<T>. Instead, use the Count() extension method from LINQ.
            for (int i = 0; i < numbers2.Count(); i++)
            {
                // This will throw an exception because numbers2 is an IEnumerable<int> and does not support indexing.
                //Console.WriteLine(numbers2[i]);
            }

            Console.WriteLine(new string('-', 50));

            // This happens because the LINQ query is evaluated immediately when you call ToList().
            List<int> arrayInts = numbers2.ToList();
            // After this, if you modify the original array, it won't affect the already evaluated list.
            IEnumerable<int> filteredInts = arrayInts.Where(x => x > 4);

            //Console.WriteLine(filteredInts[0]);

            foreach (int item in filteredInts)
            {
                Console.WriteLine(item);
            }
        }
    }
}
