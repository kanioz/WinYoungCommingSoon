using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WinYoungUI.Extensions;

namespace WinYoungUI.Areas.Administration.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public void SetBreadCrumbs(string url, string text)
        {
            ViewBag.BreadCrumbs = new Dictionary<string, string> { { text, url } };
        }
        public bool PathRequired(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);
            string[] extensions = { ".exe", ".ink", ".inf", ".db" };
            return !extensions.Contains(fileExtension.ToLower());
        }

        public string GetRandomPathName(IFormFile file)
        {
            string filename = Guid.NewGuid().ToString();
            string fileExtension = Path.GetExtension(file.FileName);
            return filename + fileExtension;
        }
        public string ConvertImageExtension(string imageName)
        {
            string convertedExtension = imageName.Replace(Path.GetExtension(imageName), ".jpg");
            return convertedExtension;
        }
        public bool ImageRequired(string photoFileName)
        {
            string fileExtension = Path.GetExtension(photoFileName);
            string[] extensions = { ".jpg", ".jpeg", ".png" };
            return extensions.Contains(fileExtension.ToLower());
        }
        public void FixedSize(Image imgPhoto, int width, int Height, string path, bool isResize)
        {
            if (isResize)
            {
                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;
                int sourceX = 0;
                int sourceY = 0;
                int destX = 0;
                int destY = 0;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;

                nPercentW = ((float)width / (float)sourceWidth);
                nPercentH = ((float)Height / (float)sourceHeight);
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = System.Convert.ToInt16((width -
                                  (sourceWidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = System.Convert.ToInt16((Height -
                                  (sourceHeight * nPercent)) / 2);
                }

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);

                Bitmap bmPhoto = new Bitmap(width, Height,
                                  PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                 imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                //grPhoto.Clear(System.Drawing.Color.White);
                grPhoto.InterpolationMode =
                        InterpolationMode.HighQualityBicubic;

                grPhoto.DrawImage(imgPhoto,
                    new System.Drawing.Rectangle(destX, destY, destWidth, destHeight),
                    new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);
                bmPhoto.Save(path);
                grPhoto.Dispose();
                bmPhoto.Dispose();
            }
            else
            {
                imgPhoto.Save(path);
            }
        }
        public void SetMessage(MessageType type, string message)
        {
            TempData["MessageType"] = (int)type;
            TempData["MessageTitle"] = type.GetDescription();
            TempData["Message"] = message;
        }
       
        //private async Task<string> RenderRazorViewToString(string viewName, object model)
        //{
        //    if (string.IsNullOrEmpty(viewName))
        //        viewName = ControllerContext.ActionDescriptor.ActionName;

        //    ViewData.Model = model;

        //    using (var writer = new StringWriter())
        //    {
        //        //ViewEngineResult viewResult =
        //        //    _viewEngine.FindView(ControllerContext, viewName, false);

        //        //ViewContext viewContext = new ViewContext(
        //        //    ControllerContext,
        //        //    viewResult.View,
        //        //    ViewData,
        //        //    TempData,
        //        //    writer,
        //        //    new HtmlHelperOptions()
        //        //);

        //        //await viewResult.View.RenderAsync(viewContext);

        //        //return writer.GetStringBuilder().ToString();
        //    }
        //}

        public enum MessageType
        {
            [Description("Bilgi")]
            Success = 3,
            [Description("Hata")]
            Danger = 5,
            [Description("Uyarý")]
            Warning = 4
        }
    }
}