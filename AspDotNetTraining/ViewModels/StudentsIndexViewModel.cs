using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspDotNetTraining.Models;

namespace AspDotNetTraining.ViewModels
{
    public class StudentsIndexViewModel
    {
        public Student Student { get; set; }
        public List<Payment> Payments { get; set; }
    }
}