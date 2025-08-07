using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Channels;
using static System.Net.WebRequestMethods;

namespace BackgroundWorker.Queue;

/// <summary>
/// BackgroundTaskQueue is a custom implementation of a task queue, designed to:
//  Queue up long-running or non-critical tasks
//  Run them in the background, separate from the HTTP request lifecycle
//  Avoid blocking the main request thread
//  Ensure execution even after the API request finishes
//  Safely handle cancellation and shutdown
/// </summary>
public class BackgroundTaskQueue
{
    // Thread-safe Channel<T> to hold tasks
    private readonly Channel<Func<CancellationToken, Task>> _queue;

    public BackgroundTaskQueue()
    {
        _queue = Channel.CreateUnbounded<Func<CancellationToken, Task>>();
    }

    public void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem)
    {
        if (workItem == null)
        {
            throw new ArgumentNullException(nameof(workItem));
        }

        _queue.Writer.TryWrite(workItem);
    }

    public async Task<Func<CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken)
    {
        var workItem = await _queue.Reader.ReadAsync(cancellationToken);
        return workItem;
    }
}
