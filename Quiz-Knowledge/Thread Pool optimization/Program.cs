namespace Thread_Pool_optimization
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");

            CustomTask.RunTaskAsync(ShowResult1);

            Console.WriteLine("End");
        }

        static string ShowResult()
        {
            Console.WriteLine("Result from async method");

            return "Hello from ShowResult!";
        }

        static int ShowResult1()
        {
            Console.WriteLine("Result from async method");

            return 1;
        }
    }

    public class CustomTask
    {
        public static Task<Output> RunTaskAsync<Output>(Func<Output> action)
        {
            var tcs = new TaskCompletionSource<Output>();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    var result = action(); // Execute the action with default value of T
                    tcs.SetResult(result); // Indicate that the task completed successfully
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex); // Set the exception if the action fails
                    throw;
                }
            });

            return tcs.Task;
        }
    }
}
