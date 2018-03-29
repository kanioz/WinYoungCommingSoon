using WinYoungUI.Models.Entities;

namespace WinYoungUI.Data.Service.Interface
{
    public interface ISiteSettingService
    {
        SiteSetting GetSetting();
        SiteSetting AddEditSetting(SiteSetting model);
    }
}
