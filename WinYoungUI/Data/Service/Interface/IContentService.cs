using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinYoungUI.Models.Entities;

namespace WinYoungUI.Data.Service.Interface
{
    public interface IContentService
    {
        void DeleteContentById(int id);
        Content AddEditContent(Content data);
        Content GetContentById(int id);
        List<Content> GetContentList();
    }
}
