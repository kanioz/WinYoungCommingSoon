using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using WinYoungUI.Data.Service.Interface;
using WinYoungUI.Extensions;
using WinYoungUI.Models.Entities;

namespace WinYoungUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class HomeController : BaseController
    {
        private readonly ISiteSettingService _service;

        public HomeController(ISiteSettingService service, IHostingEnvironment hostingEnvironment)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Settings()
        {
            var setting = _service.GetSetting();
            return View(setting);
        }

        [HttpPost]
        public IActionResult Settings(SiteSetting site)
        {
            _service.AddEditSetting(site);
            SetMessage(MessageType.Success, "Ayarlar Başarıyla Kaydedildi");
            return RedirectToAction("Index");
        }

    }
}