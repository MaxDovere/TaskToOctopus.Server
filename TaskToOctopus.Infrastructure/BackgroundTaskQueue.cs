using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using TaskToOctopus.Infrastructure.Interfaces;

namespace TaskToOctopus.Infrastructure
{


    //public delegate bool TaskWorker(object[] args);
    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private readonly Channel<Func<string, CancellationToken, ValueTask>> _queue;

        public BackgroundTaskQueue(int capacity)
        {
            /*
            * La capacit� deve essere impostata in base al carico previsto dell'applicazione e
            * numero di thread simultanei che accedono alla coda.            
            * BoundedChannelFullMode.Wait far� s� che le chiamate a WriteAsync() restituiscano un'attivit�,
            * che si completa solo quando lo spazio diventa disponibile.Questo porta alla contropressione,
            * nel caso in cui tropp chiamate inizino ad accumularsi.
             */
            var options = new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            _queue = Channel.CreateBounded<Func<string, CancellationToken, ValueTask>> (options);
        }

        public async ValueTask QueueBackgroundWorkItemAsync(Func<string, CancellationToken, ValueTask> workItem)
        { 
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            await _queue.Writer.WriteAsync(workItem);
        }

        public async ValueTask<Func<string, CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken)
        {
            var workItem = await _queue.Reader.ReadAsync(cancellationToken);

            //Task work = new (() => { workItem("", cancellationToken); });
            //work.Start();

            return workItem;
        }
    }
}
