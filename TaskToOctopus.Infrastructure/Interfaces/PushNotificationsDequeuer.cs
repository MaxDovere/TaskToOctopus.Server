using System;
using System.Threading;
using System.Threading.Tasks;

namespace CRMWebApp.PushNotifications
{
    internal class PushNotificationsDequeuer : IHostedNotificationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPushNotificationsQueue _messagesQueue;
        private readonly IPushNotificationService _notificationService;
        private readonly CancellationTokenSource _stopTokenSource = new CancellationTokenSource();

        private Task _dequeueMessagesTask;

        public PushNotificationsDequeuer(IServiceProvider serviceProvider,
            IPushNotificationsQueue messagesQueue, IPushNotificationService notificationService)
        {
            _serviceProvider = serviceProvider;
            _messagesQueue = messagesQueue;
            _notificationService = notificationService;
        }

        public event NotificationService.NotificatorHandler Notificator;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _dequeueMessagesTask = Task.Run(DequeueMessagesAsync);

            return Task.FromResult<bool>(true); // CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _stopTokenSource.Cancel();

            return Task.WhenAny(_dequeueMessagesTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }

        public void Subscribe(NotificationService.NotificatorHandler notificator)
        {
            throw new NotImplementedException();
        }

        private async Task DequeueMessagesAsync()
        {
            while (!_stopTokenSource.IsCancellationRequested)
            {
                PushMessage message = await _messagesQueue.DequeueAsync(_stopTokenSource.Token);

                if (!_stopTokenSource.IsCancellationRequested)
                {
                    //using (IServiceScope serviceScope = _serviceProvider.CreateScope())
                    //{
                    //    IPushSubscriptionStore subscriptionStore =
                    //        serviceScope.ServiceProvider.GetRequiredService<IPushSubscriptionStore>();

                    //    await subscriptionStore.ForEachSubscriptionAsync(
                    //        (PushSubscription subscription) =>
                    //        {
                    //            _notificationService.SendNotificationAsync(subscription, message,
                    //                _stopTokenSource.Token);
                    //        },
                    //        _stopTokenSource.Token
                    //    );
                    //}

                }
            }

        }
    }
}