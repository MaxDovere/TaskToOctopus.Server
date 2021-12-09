using System.Collections.Generic;
using TaskToOctopus.Server.ActionModels;

namespace TaskToOctopus.Server.Repositories
{
    public interface IUnitOfWork
    {        
        bool SetMessageReader(AspNetUsersNot message);
        IEnumerable<AspNetUsersNot> GetMessagesToNotifiction();
        bool IsThereNotifications();
        bool SubscribeUserHubConnectionId(string userid, string connectionid);
        bool UnSubscribeUserHubConnectionId(string userid, string connectionid);
        IEnumerable<AspUsersHubConnection> GetUserHubConnections(string userid);
    }
}
