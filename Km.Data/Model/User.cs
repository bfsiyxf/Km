using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Km.Data.Model
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            CreateOn = DateTime.Now;
        }
        public DateTime CreateOn { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicturePath { get; set; }
        /// <summary>
        /// 文章总数
        /// </summary>
        public int AricleCount { get; set; }
        /// <summary>
        /// 浏览总量
        /// </summary>
        public int BrowseCount { get; set; }

    }
}
