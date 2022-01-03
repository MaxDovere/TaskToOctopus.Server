using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskToOctopus.Infrastructure.Interfaces
{
    public interface IBackgroundTaskQueueNext
    {
        ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workItem);

        ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken);
    }
}
