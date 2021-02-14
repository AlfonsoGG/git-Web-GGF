using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GGF
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Sessions begin
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        void Session_Start(object sender, EventArgs e)
        {
            if (Session.IsNewSession && Session["User"] == null)
            {
                if (HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"] != null &&
                    HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString() != "Account" &&
                    HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString() != "ServiceControlBoards" &&
                    HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString() != "UploadFile"
                    )
                {
                    Response.Redirect("~/Account/LogOff");
                }
            }
        }
    }
}
