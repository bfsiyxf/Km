using Km.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Km.Data.IService;

namespace Km.Data.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected IBaseRepository<T> _iBaseRepository;

        public async  Task<T> CreateAsync(T obj)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IBaseService<T>.CreateRangeAsync(IEnumerable<T> objs)
        {
            throw new NotImplementedException();
        }

        Task IBaseService<T>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IBaseService<T>.FindAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<T> IBaseService<T>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IBaseService<T>.UpdateAsync(T obj)
        {
            throw new NotImplementedException();
        }

        Task IBaseService<T>.UpdateAsync(IEnumerable<T> objs)
        {
            throw new NotImplementedException();
        }
    }
}
