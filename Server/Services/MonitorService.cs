using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Domain.Model;
using TaskToOctopus.Infrastructure.Interfaces;
using TaskToOctopus.Persistence.Logging;

namespace TaskToOctopus.Server.Services
{
    public class MonitorService : IMonitorService
    {
        private static INLogger<MonitorService> _logger = new NLogger<MonitorService>();

        private readonly IConsumeToNotifications _consumeNotify;
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly CancellationToken _cancellationToken;
        private readonly CancellationTokenSource controller = new CancellationTokenSource();
        private int hashCode = 0;

        public MonitorService(IConsumeToNotifications consume,
            IBackgroundTaskQueue taskQueue,
            IHostApplicationLifetime applicationLifetime)
        {
            _consumeNotify = consume;
            _taskQueue = taskQueue;
            _cancellationToken = applicationLifetime.ApplicationStopping;
        }

        public void StartMonitorLoop(CancellationToken cancellationToken)
        {
            cancellationToken.Register(() =>
            {
                StopMonitorLoop(_cancellationToken, "Request cancelled!");
            });
            /*
             * Accettarsi che la connessione sia corretta validando il contatto con il database eventuale 
            */
            try
            {
                if(!_consumeNotify.IsValidConnection())
                    controller.CancelAfter(1); //valore in millesecondi.
            }
            catch (Exception e)
            {
                _logger.LogFatal(e.Message);
                throw;
            }
            _logger.LogInformation("MonitorAsync Loop is starting.");
            // Run a console user input loop in a background thread
            Task.Run(async () => await MonitorAsync()).Wait();
        }

        public void StopMonitorLoop(CancellationToken cancellationToken, string message)
        {
            _logger.LogInformation(message);
            controller.Dispose();
        }
        private Task<List<WorkerModel>> WorkerJob(IConsumeToNotifications notify, CancellationToken _cancellationToken)
        {
            return Task.Run( () =>
            {
                try
                {
                    lock (notify)
                    {
                        //Thread.Sleep(1000);
                        return notify.GetWorkerNotificator(_cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
                return default;
            });
            //return (Task<List<WorkerModel>>)Task.CompletedTask;
        }
        private async ValueTask MonitorAsync()
        {            
            try
            {
                var job = WorkerJob(_consumeNotify, _cancellationToken);

                while (!_cancellationToken.IsCancellationRequested)
                {
                    List<WorkerModel> workers = new List<WorkerModel>();
                    
                    _logger.LogInformation("Worker Job wait Any result.");

                    workers = await Task.WhenAny(job).Result;

                    //Task.Run(
                    //        () => _consumeNotify.GetWorkerNotificator(_cancellationToken)
                    //).Result;

                    if (workers.Any() && workers.GetHashCode() != hashCode)
                    {
                        hashCode = workers.GetHashCode();
                        foreach (var work in workers)
                        {
                            string userid = work.UserId;
                            if (_consumeNotify.WorkersToNotify.ContainsKey(userid))
                            {
                                _consumeNotify.WorkersToNotify.Remove(userid);
                            }
                            string json = JsonConvert.SerializeObject(work);
                            _consumeNotify.WorkersToNotify.Add(userid, json);

                            _logger.LogInformation("Enqueue a background Worker notify.");
                            await _taskQueue.QueueBackgroundWorkItemAsync(_consumeNotify.BuildWorkNotify);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}
