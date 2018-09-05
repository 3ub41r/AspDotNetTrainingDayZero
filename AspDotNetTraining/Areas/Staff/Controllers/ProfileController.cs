using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetTraining.Areas.Staff.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Staff/Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return Content("Create Staff Profile");
        }
    }
}