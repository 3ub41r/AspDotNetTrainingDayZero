using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetTraining.Controllers
{
    public class AbsoluteController : Controller
    {
        // GET: Absolute
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(UploadsCustomViewModel model, HttpPostedFileBase file)
        {
            const string basePath = @"D:\temp\Uploads";

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                if (fileName != null)
                {
                    // Generate a unique GUID for filename
                    fileName = Guid.NewGuid() + Path.GetExtension(fileName);

                    // Create directory if does not already exist
                    Directory.CreateDirectory(basePath);

                    // Save file
                    var filePath = Path.Combine(basePath, fileName);
                    file.SaveAs(filePath);

                    // Map to model - and maybe store in database
                    model.Path = Url.Content(Path.Combine(basePath, fileName));
                }
            }

            return View(model);
        }

        public ActionResult Show(string filePath)
        {
            const string basePath = @"D:\temp\Uploads";

            var fileName = Path.GetFileName(filePath);

            if (fileName == null) return HttpNotFound("File Not Found");

            // Get MIME type
            var mimeType = MimeMapping.GetMimeMapping(fileName);

            var destinationPath = Path.Combine(basePath, fileName);

            return File(destinationPath, mimeType, fileName);
        }
    }
}