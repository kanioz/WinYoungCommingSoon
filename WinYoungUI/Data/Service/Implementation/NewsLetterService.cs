using WinYoungUI.Data.Repository;
using WinYoungUI.Data.Service.Abstract;
using WinYoungUI.Data.Service.Interface;
using WinYoungUI.Models.Entities;
using WinYoungUI.ViewModels;

namespace WinYoungUI.Data.Service.Implementation
{
    public class NewsLetterService : Service<NewsLetter>, INewsLetterService
    {
        public NewsLetterService(GenericRepository<NewsLetter> repository) : base(repository)
        {
        }

        public NewsLetterVm AddEditNewsLetter(NewsLetterVm model)
        {
            var newsLetter = new NewsLetter();
            if (model.Id > 0)
            {
                newsLetter = GetById(model.Id);
                if (newsLetter == null)
                    return model;
            }
            newsLetter.Email = model.Email;

            if (model.Id == 0)
            {
                Insert(newsLetter);
                Repository.DbContext.SaveChanges();
                model.Id = newsLetter.Id;
            }
            else
            {
                Repository.DbContext.SaveChanges();
            }
            return model;
        }
    }
}
