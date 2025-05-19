namespace In_Ref_Out_None
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestCount testCount = new();

            int countA = 1;
            int countB = 2;
            int countC = 3;
            int countD = 4;

            testCount.GetCountWith(countA, in countB, ref countC, out countD);

            Console.WriteLine("countA - {0}", countA);
            Console.WriteLine("countB - {0}", countB);
            Console.WriteLine("countC - {0}", countC);
            Console.WriteLine("countD - {0}", countD);

            Console.WriteLine(new string('-', 50));

            int countE = 1;
            int countF = 2;
            int countG = 3;

            testCount.GetCountWithout(countE, countF, countG);

            Console.WriteLine("countE - {0}", countE);
            Console.WriteLine("countF - {0}", countF);
            Console.WriteLine("countG - {0}", countG);

            Console.WriteLine("End");
        }
    }

    /// <summary>
    /// Feature / Modifier	            in	                                    ref	                                out	                                    (none) (by value)

    /// Passing Method              By reference                             By reference                        By reference                            By value(copy)

    /// Input Required          ✅ Must be assigned before call	        ✅ Must be assigned before call	    ❌ Can be unassigned before call	        ✅ Must be assigned before call

    /// Modified in Method	    ❌ Not allowed(read-only)               ✅ Can be modified	                ✅ Must be assigned before method returns   ❌ Local copy only

    /// Returned to Caller      ❌ Changes not seen	                    ✅ Changes are seen	                ✅ Assigned value is returned	            ❌ Changes are not seen

    /// Use Case                Large structs read-only                 Modify and return input             Return multiple outputs                     Simple input, safe defaults

    /// Example Usage           Method(in value)                        Method(ref value)                   Method(out value)                           Method(value)

    /// Performance	            ✅ Avoids copy for large structs       ✅ Avoids copy + allows update      ✅ Output without return	                ❌ Copy cost(negligible for small types)

    /// Restriction             Cannot assign inside                    Must be assigned before and after   Must assign before return	                No rest
    /// </summary>
    public class TestCount
    {
        private int Count { get; set; } = 0;

        public void GetCountWith(int countA, in int countB, ref int countC, out int countD)
        {
            countA++;
            // countB++; Compilation error
            countC = countB + countA;
            countC = ++countA;
            countD = countA + 100;
        }

        public void GetCountWithout(int countA, int countB, int countC)
        {
            countA++;
            countB++;
            countC = countA + 100;
        }

        public void GetCountIn(in short count, out short result)
        {
            // count++; Compilation error
            result = (short)(Count + count);
        }

        public void GetCountRef(ref short count, out short result)
        {
            count++;
            result = (short)(Count + count);
        }

        public void GetCountWithout(short count, out short result)
        {
            count++;
            result = (short)(Count + count);
        }
    }
}
