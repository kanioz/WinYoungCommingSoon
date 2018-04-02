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
    public class ContentCategoryService : Service<ContentCategory>, IContentCategoryService
    {
        public ContentCategoryService(GenericRepository<ContentCategory> repository) : base(repository)
        {
        }

        public List<ContentCategory> GetContentCategoryList()
        {
            var result = Repository.GetQueryable().ToList();
            return result;
        }

        public ContentCategory GetContentCategoryById(int value)
        {
            var result = Repository.GetById(value);
            return result;
        }

        public void DeleteCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public ContentCategory AddEditCategory(ContentCategory model)
        {
            if (model.Id == 0)
                Repository.Insert(model);
            else
                Repository.Update(model);
            Repository.DbContext.SaveChanges();
            return model;
        }
    }
}
