using BackgroundWorker.Queue;

namespace BackgroundWorker.Services;

public class UserService
{
    private readonly BackgroundTaskQueue _backgroundTaskQueue;

    public UserService(BackgroundTaskQueue backgroundTaskQueue)
    {
        _backgroundTaskQueue = backgroundTaskQueue;
    }

    public async Task ProcessUserAsync()
    {
        Console.WriteLine($"Processing user");

        List<int> users = [1, 2, 3];

        // Enqueue a background task
        _backgroundTaskQueue.QueueBackgroundWorkItem(async token =>
        {
            await SendEmail(users);
        });
    }

    public async Task SendEmail(IEnumerable<int> userIds)
    {
        foreach (var userId in userIds)
        {
            Console.WriteLine($"Send email for user - {userId}");
            await Task.Delay(1000);
        }
    }
}
