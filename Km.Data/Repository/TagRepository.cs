using Km.Data.IRepository;
using Km.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.Repository
{
    public class TagRepository:BaseRepository<Tag>,ITagRepository

    {
        public TagRepository(KmContext db):base(db)
        {

        }
    }
}
