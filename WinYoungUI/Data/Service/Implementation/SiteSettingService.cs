using System.Linq;
using WinYoungUI.Data.Repository;
using WinYoungUI.Data.Service.Abstract;
using WinYoungUI.Data.Service.Interface;
using WinYoungUI.Models.Entities;

namespace WinYoungUI.Data.Service.Implementation
{
    public class SiteSettingService : Service<SiteSetting>, ISiteSettingService
    {
        public SiteSettingService(GenericRepository<SiteSetting> repository) : base(repository)
        {
        }

        public SiteSetting GetSetting()
        {
            var setting = Repository.GetQueryable().FirstOrDefault() ?? new SiteSetting();
            return setting;
        }

        public SiteSetting AddEditSetting(SiteSetting model)
        {
            var setting = GetSetting();

            setting.MetaKey = model.MetaKey;
            setting.MetaDesc = model.MetaDesc;
            setting.Mobile = model.Mobile;
            setting.YouTube = model.YouTube;
            setting.Adress = model.Adress;
            setting.Email = model.Email;
            setting.Facebook = model.Facebook;
            setting.Twitter = model.Twitter;
            setting.Fax = model.Fax;
            setting.GoogleAnalytics = model.GoogleAnalytics;
            setting.Linkedin = model.Linkedin;
            setting.Logo = model.Logo;
            setting.Name = model.Name;
            setting.Title = model.Title;
            setting.Map = model.Map;
            setting.Phone = model.Phone;
            setting.Phone2 = model.Phone2;
            if (setting.Id == 0)
            {
                Repository.Insert(setting);
            }

            Repository.DbContext.SaveChanges();
            return setting;
        }
    }
}
