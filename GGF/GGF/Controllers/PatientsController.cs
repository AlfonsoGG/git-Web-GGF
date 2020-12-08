using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GGF.Models;

namespace GGF.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patients
        public ActionResult Index()
        {
            List<GetPatientsByTherapist_Result> model = new List<GetPatientsByTherapist_Result>();
            //Carga de usuario logueado
            using (var context = new GiveGoodFaceEntities())
            {
                model = context.GetPatientsByTherapist(1).ToList();
            }
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