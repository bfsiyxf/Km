using Km.Data.IRepository;
using Km.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Km.Data.Repository
{
   public  class RoleRepository : BaseRepository<Role>,IRoleRepository  

    {
        private readonly KmContext _db;
        public RoleRepository(KmContext db ):base(db)
        {
            _db = db;
        }
    }
}
