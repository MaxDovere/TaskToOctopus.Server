using System.Threading;

namespace TaskToOctopus.Server.Services
{
    public interface IMonitorService
    {
        void StartMonitorLoop(CancellationToken cancellationToken);
        void StopMonitorLoop(CancellationToken cancellationToken, string message);
    }
}