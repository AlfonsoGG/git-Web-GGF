using GGF.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTest
{
    public class TerapeutaTest
    {
        [Fact]
        public void TerapeutaEditable()
        {
            var patientsList = Patients.GetPatientsList(1);

            int errors = 0;
            foreach(var item in patientsList)
            {
                if(item.Status == "Activo" && item.isEditable == false)
                {
                    errors++;
                }
            }
            Assert.Equal(0, errors);
        }

        [Fact]
        public void TerapeutaOrdenDescendente()
        {
            var patientsList = Patients.GetPatientsList(1);
            var patientsOrdered = patientsList.OrderByDescending(x => x.EdicionFecha).ToList();

            int errors = 0;
            for(int i = 0; i < patientsList.Count; i++)
            {
                if (patientsList[i].EdicionFecha == patientsOrdered[i].EdicionFecha)
                {
                    errors++;
                }
            }
            Assert.Equal(0, errors);
        }


    }
}
