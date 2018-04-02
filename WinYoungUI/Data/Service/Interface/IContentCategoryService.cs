using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinYoungUI.Models.Entities;

namespace WinYoungUI.Data.Service.Interface
{
    public interface IContentCategoryService
    {
        List<ContentCategory> GetContentCategoryList();
        ContentCategory GetContentCategoryById(int value);
        void DeleteCategoryById(int id);
        ContentCategory AddEditCategory(ContentCategory data);
    }
}
