using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetTraining.Controllers
{
    [RoutePrefix("admin/students")]
    [Route("{action=Create}")]
    public class AdminStudentController : Controller
    {
        // GET: /admin/students
        public ActionResult Index(int id)
        {
            return Content("Id is " + id);
        }

        public ActionResult Create()
        {
            return Content("Create student record.");
        }

        // /admin/students/display/{id}
        public ActionResult Display(int studentId)
        {
            return Content("Showing student: " + studentId);
        }

        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Content("Editing student: " + id);
        }

        public ActionResult Delete(int id)
        {
            return Content("Deleting student: " + id);
        }
    }
}