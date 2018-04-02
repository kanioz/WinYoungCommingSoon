using System.Collections.Generic;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WinYoungUI.Data.Service.Interface;
using WinYoungUI.Extensions;
using WinYoungUI.Models.Entities;

namespace WinYoungUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class ContentController : BaseController
    {
        private readonly IContentCategoryService _contentCategoryService;
        private readonly IContentService _contentService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ContentController(IContentCategoryService contentCategoryService, IContentService contentService, IHostingEnvironment hostingEnvironment)
        {
            _contentCategoryService = contentCategoryService;
            _contentService = contentService;
            _hostingEnvironment = hostingEnvironment;
        }
        public ContentResult GetSeoUrl(string SeoUrl)
        {
            var returnValue = SeoUrl.ToSeoFriendly();
            return Content(returnValue);
        }

        #region Category

        public ActionResult Category()
        {
            ViewBag.Title = "İçerik Kategorileri";
            ViewBag.Description = "İçerik Kategori Listesi";
            List<ContentCategory> contentCategories = _contentCategoryService.GetContentCategoryList();

            return View(contentCategories);
        }

        [HttpGet]
        public ActionResult CategoryEdit(int? id)
        {
            ViewBag.Title = id.HasValue ? "İçerik Kategorisi Düzenle" : "Yeni İçerik Kategorisi Ekle";
            ViewBag.Description = "İçerik Kategori Bilgileri";
            SetBreadCrumbs(Url.Action("Category"), "İçerik Kategorileri");
            var contentCategory = id.HasValue
                ? _contentCategoryService.GetContentCategoryById(id.Value)
                : new ContentCategory();
            var categories = _contentCategoryService.GetContentCategoryList();
            ViewBag.AllCategories = new SelectList(categories, "Id", "Title",
                 contentCategory.RootCategory == null ? 0 : contentCategory.RootCategory.Id);
            return View(contentCategory);
        }

        [HttpPost]
        public ActionResult CategoryEdit(ContentCategory contentCategory, string thumbnail)
        {
            ContentCategory data;
            var rootCategory = contentCategory.RootCategory.Id == 0 ? null : _contentCategoryService.GetContentCategoryById(contentCategory.RootCategory.Id);
            if (contentCategory.Id != 0)
            {
                data = _contentCategoryService.GetContentCategoryById(contentCategory.Id);
                data.Description = contentCategory.Description;
                data.MetaTags = contentCategory.MetaTags;
                data.Text = contentCategory.Text;
                //data.ThumbnailUrl = contentCategory.ThumbnailUrl;
                data.Title = contentCategory.Title;
                //data.ViewCount = contentCategory.ViewCount;
                data.IsActive = contentCategory.IsActive;
            }
            else
                data = contentCategory;
            if (!string.IsNullOrEmpty(thumbnail))
            {
                Image img = AttachmentOperations.FromBase64(thumbnail);
                data.ThumbnailUrl = img.Save(_hostingEnvironment, data.Title, Enums.AttachmentType.ContentCategory);
            }
            data.RootCategory = rootCategory;
            _contentCategoryService.AddEditCategory(data);
            SetMessage(MessageType.Success, "Kategori Başarıyla Kaydedildi");
            return RedirectToAction("Category");
        }

        public RedirectToActionResult CategoryDelete(int id)
        {
            _contentCategoryService.DeleteCategoryById(id);
            SetMessage(MessageType.Success, "Kategori Başarıyla Silindi");
            return RedirectToAction("Category");
        }

        #endregion

    }
}