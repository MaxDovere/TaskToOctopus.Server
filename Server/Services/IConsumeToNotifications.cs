using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Server.Models;

namespace TaskToOctopus.Server.Services
{
    public interface IConsumeToNotifications
    {
        SortedDictionary<string, string> WorkersToNotify { get; set; }
        Task CallNotificationMessages(string userid, WorkerModel work);
        Task<List<WorkerModel>> GetWorkerNotificator(CancellationToken token);
        ValueTask BuildWorkNotify(string json, CancellationToken token);

    }
}