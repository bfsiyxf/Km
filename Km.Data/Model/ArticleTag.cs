using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.Model
{
    public  class ArticleTag
    {
        public int ArticlesId { get; set; }
        public int TagsId { get; set; }
        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
