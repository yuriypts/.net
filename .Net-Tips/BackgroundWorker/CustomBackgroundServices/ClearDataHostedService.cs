using Microsoft.Extensions.Hosting;

namespace BackgroundWorker.CustomBackgroundServices;

public class ClearDataHostedService : IHostedService, IDisposable
{
    public ClearDataHostedService()
    {
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        //while (!cancellationToken.IsCancellationRequested)
        //{
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"ClearDataHostedService is running for the {i + 1} time.");
                await Task.Delay(1000, cancellationToken); // Simulate work
            }
        //}
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
    
    public void Dispose()
    {
        // Dispose of any resources if necessary.
        Console.WriteLine("ClearDataHostedService disposed.");
    }
}
