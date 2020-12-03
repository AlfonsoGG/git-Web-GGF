using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GGF.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patients
        public ActionResult Index()
        {
            return View();
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