using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetTraining.Controllers
{
    public class ChartsController : Controller
    {
        // GET: Charts
        public ActionResult Index()
        {
            var model = new ChartsCustomViewModel
            {
                ChartsDatas = new List<ChartsData>
                {
                    new ChartsData
                    {
                        country = "Malaysia",
                        visits = 12
                    },
                    new ChartsData
                    {
                        country = "USA",
                        visits = 4254
                    },
                    new ChartsData
                    {
                        country = "China",
                        visits = 1882
                    },
                    new ChartsData
                    {
                        country = "Japan",
                        visits = 1809
                    },
                    new ChartsData
                    {
                        country = "Germany",
                        visits = 1322
                    }
                }
            };

            return View(model);
        }
    }

    public class ChartsData
    {
        public string country { get; set; }
        public int visits { get; set; }
    }

    public class ChartsCustomViewModel
    {
        public List<ChartsData> ChartsDatas { get; set; }
    }
}