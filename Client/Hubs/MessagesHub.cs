using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRDbUpdates.Repositories;
using System;
using System.Threading.Tasks;

namespace SignalRDbUpdates.Hubs
{
    public class MessagesHub : Hub
    {
        private readonly IUnitOfWork _uow;
        private static Guid _userId { get; set; }
        public MessagesHub()
        {
            _uow = new UnitOfWork();
        }

        [HubMethodName("requestToMessages")]
        public static void RequestToMessages(string connectionId)
        {
            IHubContext _context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            
            if (connectionId == "")
            {
                _context.Clients.All.notificationToMessages(_userId.ToString());
            }
            else
            {
                _context.Clients.Client(connectionId).notificationToMessages(_userId.ToString());
            }
        }
        public override Task OnConnected()
        {
            // Add your own code here.
            // For example: in a chat application, record the association between
            // the current connection ID and user name, and mark the user as online.
            // After the code in this method completes, the client is informed that
            // the connection is established; for example, in a JavaScript client,
            // the start().done callback is executed.
            _userId = Guid .Parse("949fcabb-2bdf-454e-bb87-ff47dc13b538"); // Guid.NewGuid();
            string connectionId = Context.ConnectionId;
            var result = _uow.SubscribeUserHubConnectionId(_userId.ToString(), connectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            // Add your own code here.
            // For example: in a chat application, mark the user as offline, 
            // delete the association between the current connection id and user name.
            string connectionId = Context.ConnectionId;
            var result = _uow.UnSubscribeUserHubConnectionId(_userId.ToString(), connectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            // Add your own code here.
            // For example: in a chat application, you might have marked the
            // user as offline after a period of inactivity; in that case 
            // mark the user as online again.
            string connectionId = Context.ConnectionId;
            var result = _uow.SubscribeUserHubConnectionId(_userId.ToString(), connectionId);
            return base.OnReconnected();
        }
    }
}