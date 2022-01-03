using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Domain.Model;

namespace TaskToOctopus.Infrastructure.Interfaces
{
    public interface IConsumeToNotifications
    {
        SortedDictionary<string, string> WorkersToNotify { get; set; }
        Task CallNotificationMessages(string userid, WorkerModel work);
        Task<List<WorkerModel>> GetWorkerNotificator(CancellationToken token);
        ValueTask BuildWorkNotify(string parameter, CancellationToken token);

        bool IsValidConnection();

    }
}