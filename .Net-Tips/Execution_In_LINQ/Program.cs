namespace Execution_In_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This happens because of deferred execution in LINQ.The Select projection(var times2) doesn’t evaluate
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
        }
    }
}
