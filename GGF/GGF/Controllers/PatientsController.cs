using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GGF.Models;
using GGF.Models.Class;

namespace GGF.Controllers
{
    public class PatientsController : Controller
    {
        public ActionResult Index()
        {
            List<GetPatientsByTherapist_Result> model = Patients.GetPatientsList(1);
            return View(model);
        }

        public ActionResult Edit(int id = 1)
        {
            return View();
        }

        public ActionResult DataShow(int id = 1)
        {
            return View();
        }

    }
}