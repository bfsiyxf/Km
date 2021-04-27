using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.Model
{
    public class Tag : Entity
    {
        [Required]
        [StringLength(maximumLength: 256)]
        public string TagName { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
