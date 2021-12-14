using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskToOctopus.Domain.Port;
using TaskToOctopus.Persistence.Context;

namespace TaskToOctopus.Infrastructure.Repositories
{
    public class EntityDomain<T> : IRequestEntity<T> where T: class
    {
        private readonly DbSet<T> table;

        public EntityDomain(CRMSSODbContext dbContext)
        {
            CRMSSODbContext _dbContext;
            _dbContext = dbContext;
            table = _dbContext.Set<T>();
        }

        List<T> IRequestEntity<T>.GetAll()
        {
            return table.ToList();
        }

        public List<T> GetWhereList(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).ToList();
        }

        T IRequestEntity<T>.GetSingle(string key)
        {
            return table.Find(key);
        }

    }
}
