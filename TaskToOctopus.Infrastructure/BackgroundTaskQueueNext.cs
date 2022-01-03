using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using TaskToOctopus.Infrastructure.Interfaces;

namespace TaskToOctopus.Infrastructure
{
    public class BackgroundTaskQueueNext: IBackgroundTaskQueueNext
    {
        //private readonly INLogger<BackgroundTaskQueue> _logger = new NLogger<BackgroundTaskQueue>();
        private readonly Channel<Func<CancellationToken, ValueTask>> _queue;

        public BackgroundTaskQueueNext(int capacity)
        {
            /*
            * La capacità deve essere impostata in base al carico previsto dell'applicazione e
            * numero di thread simultanei che accedono alla coda.            
            * BoundedChannelFullMode.Wait farà sì che le chiamate a WriteAsync() restituiscano un'attività,
            * che si completa solo quando lo spazio diventa disponibile.Questo porta alla contropressione,
            * nel caso in cui tropp chiamate inizino ad accumularsi.
             */
            var options = new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            _queue = Channel.CreateBounded<Func<CancellationToken, ValueTask>>(options);
        }

        public async ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            await _queue.Writer.WriteAsync(workItem);

            await Task.Delay(5000);

            var stoppingToken = new CancellationToken();

            var work = await DequeueAsync(stoppingToken);
            if (work != null) await work(stoppingToken);
        }

        public async ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken)
        {

            var workItem = await _queue.Reader.ReadAsync(cancellationToken);

            return workItem;
        }
    }
}
