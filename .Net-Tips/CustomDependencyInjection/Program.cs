using Microsoft.Extensions.DependencyInjection;

namespace CustomDependencyInjection
{
    class B : IDisposable
    {
        ~B()
        {
            Console.WriteLine("");
        }

        public void Dispose() { }
    }

    class BAs : IAsyncDisposable
    {
        public void Dispose() { }

        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }
    }


    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var log = new LogClass();
            //var serilogLogClass = new SerilogLogClass();
            //var dbConnection = new DbConnection(log);
            //Base baseCustomClass = new(serilogLogClass, dbConnection);
            //baseCustomClass.Show();


            ServiceCollection services = new();
            services.AddTransient<Base>();
            services.AddSingleton<ILogClass, SerilogLogClass>();
            services.AddTransient<DbConnection>();
            using ServiceProvider provider = services.BuildServiceProvider();

            using (var scope = provider.CreateScope())
            {
                var baseService = scope.ServiceProvider.GetRequiredService<Base>();
                baseService.Show();
            }

            Console.WriteLine(new string('-', 50));

            Base baseClass = provider.GetRequiredService<Base>()!;
            baseClass.Show();

            // The code below, following the IoC pattern, is typically only aware of the IMessageWriter interface, not the implementation.
            //DbConnection dbConnection = provider.GetRequiredService<DbConnection>()!;
            //dbConnection.ShowGuid();

            //var scope11 = provider.CreateScope();
            //try
            //{
            //    var service = scope11.ServiceProvider.GetRequiredService<Base>();
            //    service.Show();
            //}
            //finally
            //{
            //    scope11.Dispose();
            //}

            using (var b = new B())
            { }

            var b1 = new B();
            try
            {
                // Some code that might throw an exception
            }
            catch (Exception)
            {
                b1.Dispose();
            }

            //using (var scope = provider.CreateAsyncScope())
            //{
            //    var service = scope.ServiceProvider.GetRequiredService<Base>();
            //    service.Show();
            //}

            //await using (var b = new BAs())
            //{ }
        }
    }
}
