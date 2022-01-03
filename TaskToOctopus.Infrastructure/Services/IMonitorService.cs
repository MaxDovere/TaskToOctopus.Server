using System.Threading;

namespace TaskToOctopus.Infrastructure.Services
{
    public interface IMonitorService
    {
        void StartMonitorLoop();
        void StopMonitorLoop(CancellationToken cancellationToken);
    }
}