using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TaskToOctopus.DomainApi.Port
{
    public interface IRequestEntity<T>
    {
        List<T> GetAll();
        List<T> GetWhereList(Expression<Func<T, bool>> predicate);
        T GetSingle(string key);
    }
}
