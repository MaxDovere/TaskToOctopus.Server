using System.Collections.Generic;
using TaskToOctopus.Domain.Model;

namespace TaskToOctopus.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        bool IsValidateDB();
        IEnumerable<DealerInfoModel> GetActiveDealerInfo();
        bool IsThereNotifications();
    }
}
