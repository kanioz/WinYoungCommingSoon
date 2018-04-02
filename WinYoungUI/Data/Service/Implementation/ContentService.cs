using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteContentById(int id)
        {
            throw new NotImplementedException();
        }

        public Content AddEditContent(Content model)
        {
            if (model.Id == 0)
                Repository.Insert(model);
            else
                Repository.Update(model);
            Repository.DbContext.SaveChanges();
            return model;
        }

        public Content GetContentById(int id)
        {
            var result = Repository.GetById(id);
            return result;
        }

        public List<Content> GetContentList()
        {
            var result = Repository.GetQueryable().ToList();
            return result;
        }
    }
}
