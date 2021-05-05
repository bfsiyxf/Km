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
    public  class TagService:BaseService<Tag>,ITagService
    {
        private readonly ITagRepository _iTagRepository;

        public TagService(ITagRepository iTagRepository)
        {
            base._iBaseRepository = iTagRepository;
            _iTagRepository = iTagRepository;
        }
    }
}
