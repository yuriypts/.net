namespace LinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> linkedList = new();

        linkedList.AddFirst(1);
        linkedList.AddFirst(3);
        linkedList.AddLast(2);

        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(new string('-', 20));

        linkedList.Remove(1);
        // This line is commented out because LinkedList<T> does not have a RemoveAt method. Instead, you can use Remove to remove a specific value or manipulate nodes directly.
        //linkedList.RemoveAt(1); 

        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(new string('-', 20));

        var node = linkedList.Find(2);
        linkedList.AddAfter(node, 4);

        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}
