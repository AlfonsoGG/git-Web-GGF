using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGF.Models.Class
{
    public class Patients
    {
        public static List<GetPatientsByTherapist_Result> GetPatientsList(int therapistId)
        {
            List<GetPatientsByTherapist_Result> model = new List<GetPatientsByTherapist_Result>();
            using (var context = new GiveGoodFaceEntities())
            {
                model = context.GetPatientsByTherapist(1).ToList();
            }
            return model;
        }
    }
}