using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetTraining.Controllers
{
    public class UploadsController : Controller
    {
        // GET: Uploads
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(UploadsCustomViewModel model, HttpPostedFileBase file)
        {
            const string basePath = "~/Uploads";

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                if (fileName != null)
                {
                    // Generate a unique GUID for filename
                    fileName = Guid.NewGuid() + Path.GetExtension(fileName);

                    var absolutePath = Server.MapPath(basePath);

                    // Create directory if does not already exist
                    Directory.CreateDirectory(absolutePath);

                    // Save file
                    var filePath = Path.Combine(absolutePath, fileName);
                    file.SaveAs(filePath);

                    // Map to model - and maybe store in database
                    model.Path = Url.Content(Path.Combine(basePath, fileName));

                }
            }

            return View(model);
        }

        public ActionResult Download(string filePath)
        {
            const string basePath = "~/Uploads";
            
            var fileName = Path.GetFileName(filePath);

            if (fileName == null) return HttpNotFound("File Not Found");

            // Get MIME type
            var mimeType = MimeMapping.GetMimeMapping(fileName);

            var destinationPath = Path.Combine(Server.MapPath(basePath), fileName);

            return File(destinationPath, mimeType, fileName);
        }
    }

    public class UploadsCustomViewModel
    {
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}