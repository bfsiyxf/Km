using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.Model
{
    /// <summary>
    /// 实体类都从这里继承，自动拥有id属性
    /// </summary>
    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public static implicit operator Entity(Role r)
        {
            return new Entity() { Id = r.Id };
        }
    }
}
