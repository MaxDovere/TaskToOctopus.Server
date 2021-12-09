using SignalRDbUpdates.Models;
using System.Collections.Generic;

namespace SignalRDbUpdates.Repositories
{
    public interface IUnitOfWork
    {
        IEnumerable<AspNetUsersNot> GetMessagesToNotify(string userid);
        int SetMessageReceived(string userid);
        bool SubscribeUserHubConnectionId(string userid, string connectionid);
        bool UnSubscribeUserHubConnectionId(string userid, string connectionid);
        IEnumerable<AspUsersHubConnection> GetUserHubConnections(string userid);
    }
}
