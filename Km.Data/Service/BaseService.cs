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
            return await _iBaseRepository.CreateAsync(obj);
        }

        public async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> objs)
        {
            return await _iBaseRepository.CreateRangeAsync(objs);
        }

        public async Task DeleteAsync(int id)
        {
             await _iBaseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _iBaseRepository.FindAsync(predicate);
        }

         public  async Task<T> GetAsync(int id)
        {
            return await _iBaseRepository.GetAsync(id);
        }

        public async Task UpdateAsync(T obj)
        {
             await _iBaseRepository.UpdateAsync(obj);
        }

        public async  Task UpdateAsync(IEnumerable<T> objs)
        {
            await _iBaseRepository.UpdateAsync(objs);
        }
    }
}
