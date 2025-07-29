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

            Console.WriteLine(new string('-', 50));

            ClosureClass closureClass = new(100);
            Console.WriteLine(closureClass.ClosureFunc().Invoke());
            Console.WriteLine(closureClass.ClosureFunc().Invoke());
            Console.WriteLine(closureClass.ClosureFunc().Invoke());

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

    class ClosureClass
    {
        private int _x;

        public ClosureClass(int X)
        {
            _x = X;
        }

        public Func<int> ClosureFunc()
        {
            return () => Increase(_x);
        }

        public static int Increase(int x)
        {
            x++;
            return x;
        }
    }
}
