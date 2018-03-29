using System;
using System.Collections.Generic;
using System.Drawing;
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
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ISiteSettingService service, IHostingEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
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
        public IActionResult Settings(SiteSetting site, string thumbnail)
        {
            if (!string.IsNullOrEmpty(thumbnail))
            {
                Image img = AttachmentOperations.FromBase64(thumbnail);
                site.Logo = img.Save(_hostingEnvironment, site.Title, Enums.AttachmentType.Site);
            }

            _service.AddEditSetting(site);
            SetMessage(MessageType.Success, "Ayarlar Başarıyla Kaydedildi");
            return RedirectToAction("Index");
        }

    }
}