using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGF.Models.Views
{
    public class PatientBrowserModel
    {
        string name { get; set; }
        DateTime creationDate { get; set; }
        string status { get; set; }
        bool isEditable { get; set; }
        bool canDisabled { get; set; }
        bool showStatistics { get; set; }
        bool canCreateToken { get; set; }
    }
}
