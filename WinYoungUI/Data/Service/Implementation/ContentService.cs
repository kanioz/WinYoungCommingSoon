using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinYoungUI.Data.Repository;
using WinYoungUI.Data.Service.Abstract;
using WinYoungUI.Data.Service.Interface;
using WinYoungUI.Models.Entities;

namespace WinYoungUI.Data.Service.Implementation
{
    public class ContentService : Service<Content>, IContentService
    {
        public ContentService(GenericRepository<Content> repository) : base(repository)
        {

        }
    }
}
