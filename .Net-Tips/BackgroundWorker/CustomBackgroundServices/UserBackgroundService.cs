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
        Func<CancellationToken, Task> workItem = await _backgroundTaskQueue.DequeueAsync(stoppingToken);

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