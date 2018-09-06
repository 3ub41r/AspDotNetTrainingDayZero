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
        [HttpPost]
        public ActionResult Delete(int id)
        {
            new StudentService().Delete(id);

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult Update(Student student)
        {
            new StudentService().Update(student);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var student = new StudentService().Find(id);

            return View("Create", student);
        }

        // GET: Crud
        public ActionResult Index()
        {
            var students = new StudentService().GetAll();

            return View(students);
        }

        public ActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Store(Student student)
        {
            new StudentService().Insert(student);

            return RedirectToAction("Create");
        }
    }
}