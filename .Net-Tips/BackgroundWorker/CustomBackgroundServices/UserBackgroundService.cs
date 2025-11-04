using BackgroundWorker.Queue;
using Microsoft.Extensions.Hosting;

namespace BackgroundWorker.CustomBackgroundServices;

public class UserBackgroundService : BackgroundService
{
    private readonly BackgroundTaskQueue _backgroundTaskQueue;

    public UserBackgroundService(BackgroundTaskQueue backgroundTaskQueue)
    {
        _backgroundTaskQueue = backgroundTaskQueue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Started listening");
        Func<CancellationToken, Task> workItem = await _backgroundTaskQueue.DequeueAsync(stoppingToken);
        Console.WriteLine("Listening");

        try
        {
            await workItem(stoppingToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred executing background task.");
        }
    }
}