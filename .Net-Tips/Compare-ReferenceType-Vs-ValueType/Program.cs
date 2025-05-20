namespace Compare_ReferenceType_Vs_ValueType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new()
            {
                PropClass = new A()
            };
            TestStruct teststruct = new()
            {
                PropClass = new BaseStruct()
            };


            Console.WriteLine("GetType vs GetType - {0}", test.PropClass.GetType() == new A().GetType());
            Console.WriteLine("GetType vs typeof - {0}", test.PropClass.GetType() == typeof(A));
            Console.WriteLine("Is - {0}", test.PropClass is A);
            Console.WriteLine("Is classA - {0}", test.PropClass is A classA); // Check with pattern matching and usage If you want to do something with A after the check:

            Console.WriteLine("== operand - {0}", test.PropClass == new A());
            Console.WriteLine("Equals method - {0}", test.Equals(new A()));

            Console.WriteLine(new string('-', 50));

            Console.WriteLine("GetType vs GetType - {0}", teststruct.PropClass.GetType() == new BaseStruct().GetType());
            Console.WriteLine("GetType vs typeof - {0}", teststruct.PropClass.GetType() == typeof(BaseStruct));
            Console.WriteLine("Is - {0}", teststruct.PropClass is BaseStruct);
            Console.WriteLine("Is classA - {0}", teststruct.PropClass is BaseStruct classB); // Check with pattern matching and usage If you want to do something with A after the check:

            //Console.WriteLine("== operand - {0}", teststruct.PropClass == new BaseStruct()); // Compile error: The operator '==' cannot be applied to operands of type 'BaseStruct' and 'BaseStruct'
            Console.WriteLine("Equals method - {0}", teststruct.PropClass.Equals(new BaseStruct()));
        }
    }

    public abstract class Base
    {

    }

    public class A : Base
    {

    }

    public class B : Base
    {

    }

    public class Test
    {
        public Base PropClass { get; set; }
    }



    public struct BaseStruct
    {

    }

    public struct TestStruct
    {
        public BaseStruct PropClass { get; set; }
    }
}
