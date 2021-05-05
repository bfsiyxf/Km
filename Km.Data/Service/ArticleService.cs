using Km.Data.IRepository;
using Km.Data.IService;
using Km.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.Service
{
    public  class ArticleService:BaseService<Article>,IArticleService

    {
        private readonly IArticleRepository _iArticleRepository;

        public ArticleService(IArticleRepository iArticleRepository)
        {
            base._iBaseRepository = iArticleRepository;
            _iArticleRepository = iArticleRepository;
        }
    }
}
