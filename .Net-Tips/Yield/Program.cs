using System.Collections;

namespace Yield;

internal class Program
{
    public class Person
    {
        public int Id { get; set; }
    }

    static async Task Main(string[] args)
    {
        List<int> numbers = GetNumbers();
        Console.WriteLine(numbers[0]);

        foreach (var arg in GetNumbers())
        {
            Console.WriteLine(arg);
        }

        //Console.WriteLine(new string('-', 50));

        //IEnumerable<int> numbersWithYield = GetNumbersWithYield();
        ////Console.WriteLine(numbersWithYield[0]);

        ////foreach (var arg in numbersWithYield)
        ////{
        ////    Console.WriteLine(arg);
        ////}

        //var enumerator = numbersWithYield.GetEnumerator();
        //while (enumerator.MoveNext())
        //{
        //    Console.WriteLine(enumerator.Current);
        //}

        //Console.WriteLine(new string('-', 50));

        //foreach (var person in GetPersons())
        //{
        //    Console.WriteLine(person.Id);
        //}

        //Console.WriteLine(new string('-', 50));

        ////GetNumbers() -> iterator created -> First() -> yield return 0
        //IEnumerable<int> numbers = GetNumbersWithYield();

        //Console.WriteLine("Test");

        //var first = numbers.First();
        //Console.WriteLine(first);
    }

    private static IEnumerable<int> GetNumbersWithYield()
    {
        Console.WriteLine("Started");

        for (int i = 0; i < 10; i++)
        {
             yield return i;
        }
    }

    private static List<int> GetNumbers()
    {
        //List<int> numbers = new List<int>();
        //for (int i = 0; i < 10; i++)
        //{
        //    numbers.Add(i);
        //}

        //return numbers;

        return [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
    }

    private static IEnumerable<Person> GetPersons()
    {
        yield return new Person { Id = 1 };
        yield return new Person { Id = 2 };
        yield return new Person { Id = 3 };
        yield return new Person { Id = 4 };
    }
    
    private static IEnumerable<Person> GetPersonsList()
    {
        return
        [
            new() { Id = 1 },
            new() { Id = 2 },
            new() { Id = 3 },
            new() { Id = 4 }
        ];
    }

    public static async IAsyncEnumerable<Person> GetPersonsAsync()
    {
        for (int i = 1; i <= 3; i++)
        {
            await Task.Delay(1000);
            yield return new Person { Id = i };
        }
    }
}
