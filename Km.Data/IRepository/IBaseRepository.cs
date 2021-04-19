using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.IRepository
{
    interface IBaseRepository<T> where T : class
    {
        
        /// <summary>
        /// 创建一个实体对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T obj);
        /// <summary>
        /// 创建一组对象
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> objs);
        Task DeleteAsync(int id);
        /// <summary>
        /// 返回一组符合搜索条件的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 根据id得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(int id);
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task UpdateAsync(T obj);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        Task UpdateAsync(IEnumerable<T> objs);
    
    }
}
