using Microsoft.Extensions.Hosting;

namespace BackgroundWorker.CustomBackgroundServices;

public class ClearDataBackgroundService : BackgroundService
{
    public ClearDataBackgroundService()
    {
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        //while (!cancellationToken.IsCancellationRequested)
        //{
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"ClearDataBackgroundService is running for the {i + 1} time.");
                await Task.Delay(1000, cancellationToken); // Simulate work
            }
        //}
    }
}
