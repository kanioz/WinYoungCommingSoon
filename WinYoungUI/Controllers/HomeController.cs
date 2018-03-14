using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using WinYoungUI.Data.Service.Interface;
using WinYoungUI.Models;
using WinYoungUI.Models.Entities;
using WinYoungUI.ViewModels;

namespace WinYoungUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsLetterService _newsLetterService;

        public HomeController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveEmail(NewsLetterVm model)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new {Saved = false, Message = "Enter valid email!"});
            try
            {
                _newsLetterService.AddEditNewsLetter(model);
                return new JsonResult(new { Saved = true, Message = "Saved successfully" });
            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(ex);
                return new JsonResult(new { Saved = false, Message = "An error occured while saving. Please try again later." });
            }
        }
    }
}

