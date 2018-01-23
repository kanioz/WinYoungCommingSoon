using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinYoungUI.Models;

namespace WinYoungUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly WinYoungContext _context;
        public HomeController(WinYoungContext context)
        {
            _context = context;
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
                _context.NewsLetters.Add(new NewsLetter { CreateTime = DateTime.Now, Email = model.Email });
                _context.SaveChanges();
                return new JsonResult(new { Saved = true, Message = "Saved successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Saved = false, Message = "An error occured while saving. Please try again later." });
            }
        }




    }
}

