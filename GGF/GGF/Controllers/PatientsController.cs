using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GGF.Common;
using GGF.Models;

namespace GGF.Controllers
{
    public class PatientsController : BaseController
    {
        public ActionResult Index()
        {
            List<GetPatientsByTherapist_Result> model = new List<GetPatientsByTherapist_Result>();

            try
            {
                model = context.GetPatientsByTherapist(GetUserId()).ToList();
            }
            catch (Exception ex)
            {
                CommonCode.Log(ex);
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