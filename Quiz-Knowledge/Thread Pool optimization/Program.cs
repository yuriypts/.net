namespace Thread_Pool_optimization
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");

            await CustomTask.Run(ShowResultAsync);
            await Task.Run(ShowResultAsync);
            
            CustomTask.Run(ShowResult);
            Task.Run(ShowResult);

            Thread thread = new(ShowResultThread);
            thread.Start("Thread"); 

            Thread.Sleep(2000);

            Console.WriteLine("End");
            Console.WriteLine("More End");
        }

        static string ShowResultAsync()
        {
            Console.WriteLine("Result from async method");

            return "Hello from ShowResult!";
        }

        static int ShowResult()
        {
            Console.WriteLine("Result from non-async method");

            return 1;
        }

        static void ShowResultThread(object test)
        {
            Console.WriteLine("Result from thread method - {0}", test);
            Thread.Sleep(3000);
        }
    }

    public class CustomTask
    {
        public static Task<TResult> Run<TResult>(Func<TResult> function)
        {
            var tcs = new TaskCompletionSource<TResult>();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    var result = function(); // Execute the action with default value of T
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
