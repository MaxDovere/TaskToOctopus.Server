using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskToOctopus.Infrastructure.Interfaces
{
    public interface IBackgroundTaskQueue
    {
        ValueTask QueueBackgroundWorkItemAsync(Func<string, CancellationToken, ValueTask> workItem);

        ValueTask<Func<string, CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken);
    }
}
