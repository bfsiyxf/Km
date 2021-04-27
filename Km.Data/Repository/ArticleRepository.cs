using Km.Data.IRepository;
using Km.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Km.Data.Repository
{
    public class ArticleRepository : CoreRepository<Article>, IArticleRepository
    {
        private readonly KmContext _db;
        public ArticleRepository(KmContext db) : base(db) => _db = db;


       public async Task<Article> CreateAsync(Article article,IEnumerable<string> tagNames)
        {
            if(!tagNames.IsNullOrEmpty())
            {
                //去除空字符和重复字符
                tagNames=tagNames.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct();
                var tags = _db.Set<Tag>();
                foreach(var name in tagNames)
                {
                    var tag = tags.First(t => t.TagName.ToUpper() == name.ToUpper());
                    article.ArticleTags.Add(new ArticleTag { Article = article, Tag = tag });

                }              
            }
            await _entityes.AddAsync(article);
            await _db.SaveChangesAsync();
            return article;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> FindAsync(Expression<Func<Article, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Article obj)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<Article> objs)
        {
            throw new NotImplementedException();
        }
    }


}
