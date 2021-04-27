using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.Model
{
    public class Article : Entity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [StringLength(maximumLength: 256)]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 作者id
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// 审核，是否普通用户可见
        /// </summary>
        public bool Activited { get; set; } = false;
        /// <summary>
        /// 浏览量
        /// </summary>
        public int BrowseCount { get; set; }
        /// <summary>
        /// 点赞量
        /// </summary>
        public int Upvote { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [NotMapped]
        public User Author { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }
        public  ICollection<Tag> Tags { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; }

    }
}
