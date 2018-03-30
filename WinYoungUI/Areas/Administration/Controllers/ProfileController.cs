using Microsoft.AspNetCore.Mvc;

namespace WinYoungUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class ProfileController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}