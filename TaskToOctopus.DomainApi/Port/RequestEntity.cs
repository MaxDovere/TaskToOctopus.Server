using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TaskToOctopus.DomainApi.Port
{
    public class RequestEntity<T> : IRequestEntity<T> where T : class
    {
        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetSingle(string key)
        {
            throw new NotImplementedException();
        }

        public List<T> GetWhereList(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
