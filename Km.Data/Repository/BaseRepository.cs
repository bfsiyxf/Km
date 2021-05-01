using Km.Data.IRepository;
using Km.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.Repository
{
    public  class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly DbSet<T> _entityes;
        protected readonly DbContext _db;

        public BaseRepository(DbContext context)
        {
            this._entityes = context.Set<T>();
            this._db = context;
        }
        public virtual async Task<T> CreateAsync(T obj)
        {
            try
            {
                await _entityes.AddAsync(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateException dbUpdEx)
            {
                throw new NotImplementedException();
            }
        }

        public virtual async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> objs)
        {
            _entityes.AddRange(objs);
            await _db.SaveChangesAsync();
            return objs;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _entityes.SingleAsync(e => e.Id == id);
            _entityes.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entityes.Where(predicate).ToListAsync();
        }


        public virtual async Task<T> GetAsync(int id) => await _entityes.SingleOrDefaultAsync(e => e.Id == id);

        public virtual async Task UpdateAsync(T obj)
        {
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException DbUpEx)
            {
                throw GetExceptionForUniqueConstraint(DbUpEx);
            }
        }

        public virtual async Task UpdateAsync(IEnumerable<T> objs)
        {
            await _db.SaveChangesAsync();
        }


        private Exception GetExceptionForUniqueConstraint(DbUpdateException dbUpdEx)
        {
            //if (dbUpdEx.InnerException != null)
            //{
            //    var message = dbUpdEx.InnerException.Message;
            //    if (message.Contains("UniqueConstraint", StringComparison.OrdinalIgnoreCase)
            //        || message.Contains("Unique Constraint", StringComparison.OrdinalIgnoreCase))
            //        return new FanException(EExceptionType.DuplicateRecord, dbUpdEx);

            //    if (dbUpdEx.InnerException.InnerException != null)
            //    {
            //        message = dbUpdEx.InnerException.InnerException.Message;
            //        if (message.Contains("UniqueConstraint", StringComparison.OrdinalIgnoreCase)
            //            || message.Contains("Unique Constraint", StringComparison.OrdinalIgnoreCase))
            //            return new FanException(EExceptionType.DuplicateRecord, dbUpdEx);
            //    }
            //}

            return dbUpdEx;
        }

        Task<IEnumerable<T>> IBaseRepository<T>.CreateRangeAsync(IEnumerable<T> objs)
        {
            throw new NotImplementedException();
        }
    }
}
