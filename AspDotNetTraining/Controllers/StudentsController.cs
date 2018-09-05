using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspDotNetTraining.Models;
using AspDotNetTraining.ViewModels;
using Dapper;

namespace AspDotNetTraining.Controllers
{
    public class StudentsController : Controller
    {
        public ActionResult Dapper()
        {
            var sql = @"SELECT * FROM Student";

            var connectionString = ConfigurationManager.ConnectionStrings["Database"].ToString();


            using (var connection = new SqlConnection(connectionString))
            {
                var students = connection.Query<Student>(sql);
                return View(students);
            }
        }












        public ActionResult List()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\temp\AspNetMvc\Dayzero\AspDotNetTraining\AspDotNetTraining\App_Data\AspDotNetTraining.mdf;Integrated Security=True";
            var output = "";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT Name, IcNumber FROM Student", connection);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        output += reader.GetString(0) + "  - " + reader.GetString(1) + ", ";
                    }
                }
            }

            return Content(output);
        }


        // /students/payments
        public ActionResult Payments()
        {
            var viewModel = new StudentsIndexViewModel
            {
                Student = new Student
                {
                    Name = "Pelajar 3",
                    IcNumber = "121212121213",
                    MatricNumber = "A1234567891"
                },
                Payments = new List<Payment>
                {
                    new Payment
                    {
                        Amount = 100,
                        Description = "Yuran Pendaftaran"
                    },
                    new Payment
                    {
                        Amount = 200,
                        Description = "Yuran Penilaian"
                    },
                    new Payment
                    {
                        Amount = 300,
                        Description = "Yuran Peperiksaan"
                    },
                }
            };

            return View(viewModel);
        }











        public ActionResult Index()
        {
            var viewModel = new StudentsIndexViewModel
            {
                Student = new Student
                {
                    Name = "Pelajar 2",
                    IcNumber = "121212121212",
                    MatricNumber = "A1234567890"
                },
                Payments = new List<Payment>
                {
                    new Payment
                    {
                        Amount = 100,
                        Description = "Yuran Pendaftaran"
                    },
                    new Payment
                    {
                        Amount = 200,
                        Description = "Yuran Penilaian"
                    },
                    new Payment
                    {
                        Amount = 300,
                        Description = "Yuran Peperiksaan"
                    },
                }
            };

            return View(viewModel);
        }






        // /students/about
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Show(int x, int y)
        {
            return Content("x + y = " + (x + y));
        }
    }
}