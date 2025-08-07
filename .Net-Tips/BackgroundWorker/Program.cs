using BackgroundWorker.CustomBackgroundServices;
using BackgroundWorker.Queue;
using BackgroundWorker.Services;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting;

namespace BackgroundWorker
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Difference between Hosted Service and BackgroundService - is that BackgroundService is an abstract class that provides a base implementation for long-running services,
            // while Hosted Service is a more general term that can refer to any service registered with the host.
            // Also Hosted Service will bock the Application startup, but BackgroundService will not (Reason is .Net Runtime)

            await StableOption(args);
            //await Option1(args);
            //await Option2();
            //await Option3();
        }

        /// <summary>
        /// Stable method to run the background service
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task StableOption(string[] args)
        {
            Console.WriteLine("Main started");

            // CreateApplicationBuilder is used to configure the application and its services
            var builder = Host.CreateApplicationBuilder(args);

            // Register Services
            //builder.Services.AddHostedService<ClearDataBackgroundService>();
            //builder.Services.AddHostedService<ClearDataHostedService>();
            builder.Services.AddHostedService<UserBackgroundService>();

            builder.Services.AddSingleton<BackgroundTaskQueue>();
            builder.Services.AddScoped<UserService>();

            // Build the host, which includes the configured services
            using IHost host = builder.Build();

            Console.WriteLine("Main working");

            IServiceProvider serviceProvider = host.Services;
            UserService userService = serviceProvider.GetRequiredService<UserService>();
            await userService.ProcessUserAsync();

            // Run the host, which starts the background services
            await host.RunAsync();
        }

        /// <summary>
        /// Use CreateHostBuilder
        /// </summary>
        /// <returns></returns>
        static async Task Option1(string[] args)
        {
            Console.WriteLine("Main started");
            
            // CreateApplicationBuilder is used to configure the application and its services
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<ClearDataBackgroundService>();
                })
                .Build();
            
            // Start the host
            await host.StartAsync();
            
            await Task.Delay(1000);
            
            Console.WriteLine("Main finishing, stopping background service...");

            // Stop the host
            await host.StopAsync();
            
            Console.WriteLine("Background service stopped. Exiting.");
        }

        /// <summary>
        /// Use Task.Run
        /// </summary>
        /// <returns></returns>
        static async Task Option2()
        {
            Console.WriteLine("Main started");

            // Start background task
            Task backgroundTask = Task.Run(async () =>
            {
                Console.WriteLine($"Background running at {DateTime.Now}");
                await Task.Delay(1000); // Simulate initial delay
            });

            await Task.Delay(2000);

            Console.WriteLine("Background task stopped. Exiting.");
        }

        /// <summary>
        /// Manually create and use a BackgroundService
        /// </summary>
        /// <returns></returns>
        static async Task Option3()
        {
            var service = new ClearDataBackgroundService();

            await service.StartAsync(CancellationToken.None);

            await Task.Delay(3000);

            await service.StopAsync(CancellationToken.None);
        }
    }
}
