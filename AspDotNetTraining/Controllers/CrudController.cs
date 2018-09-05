using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspDotNetTraining.Models;
using AspDotNetTraining.Services;
using Dapper;

namespace AspDotNetTraining.Controllers
{
    public class CrudController : Controller
    {
        // GET: Crud
        public ActionResult Index()
        {
            var students = new StudentService().GetAll();

            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(Student student)
        {
            new StudentService().Insert(student);

            return RedirectToAction("Create");
        }
    }
}