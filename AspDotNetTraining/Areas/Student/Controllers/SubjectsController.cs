using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetTraining.Areas.Student.Controllers
{
    [RouteArea("Student")]
    [RoutePrefix("Subjects")]
    [Route("{action}")]
    public class SubjectsController : Controller
    {
        // GET: Student/Subjects
        public ActionResult Index()
        {
            return View();
        }

        // /Student/Subjects/Register
        public ActionResult Register()
        {
            return View();
        }
    }
}