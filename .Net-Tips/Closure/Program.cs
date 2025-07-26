namespace Closure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int> closureFunc = ClosureFunc();

            Console.WriteLine(closureFunc.Invoke());
            Console.WriteLine(closureFunc());
            Console.WriteLine(closureFunc());
            Console.WriteLine(closureFunc());

            Console.WriteLine(new string('-', 50));

            Func<int> closureFunc2 = ClosureFunc();
            Console.WriteLine(closureFunc2.Invoke());
            Console.WriteLine(closureFunc2());
        }

        static Func<int> ClosureFunc()
        {
            int x = 10;
            return () =>
            {
                x++;
                return x;
            };
        }
    }
}
