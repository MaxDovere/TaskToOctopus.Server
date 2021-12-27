using System.Collections.Generic;
using TaskToOctopus.Domain.Model;

namespace TaskToOctopus.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        bool IsValidateDB();
        //bool SetMessageReader(AspNetUsersNot message);
        IEnumerable<AspNetUsersNot> GetMessagesToNotifiction();
        bool IsThereNotifications();
        //bool SubscribeUserHubConnectionId(string userid, string connectionid);
        //bool UnSubscribeUserHubConnectionId(string userid, string connectionid);
        //IEnumerable<AspUsersHubConnection> GetUserHubConnections(string userid);
    }
}
