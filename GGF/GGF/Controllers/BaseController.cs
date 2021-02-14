using GGF.Common;
using GGF.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace GGF.Controllers
{
    //public string empresaCliente = ConfigurationManager.AppSettings["EmpresaCliente"];
    
    public class BaseController : Controller
    {
        protected static string DateFormat = @"dd/MM/yyyy";

        protected GiveGoodFaceEntities context;
        public BaseController()
        {
            context = new GGF.Models.GiveGoodFaceEntities();
        }

        protected int GetUserId()
        {
            return (int)(Session["userId"] ?? 0) ;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                #region Language selection
                //string culture = (Session["culture"] != null && Session["culture"].ToString() != string.Empty) ? Session["culture"].ToString() : "es-MX";
                string culture = "es-MX";

                try
                {
                    //string culture = Session["culture"].ToString();
                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
                }
                catch (Exception ex)
                {
                    CommonCode.Log(ex);
                    //Session["culture"] = "es-MX";
                    culture = "es-MX"; //Session["culture"].ToString();
                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
                }
                #endregion

                #region User Logged in
                try
                {
                    if (System.Web.HttpContext.Current.Session["userId"] == null)
                    {
                        if (HttpContext.Request.RequestContext.RouteData.Values["Controller"] != null && HttpContext.Request.RequestContext.RouteData.Values["Controller"].ToString() != "Account")
                        {
                            if (filterContext.HttpContext.Request.IsAjaxRequest())
                            {
                                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Conflict;
                                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                                filterContext.Result = new JsonResult { Data = "Index/Login", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                            }
                            else
                            {
                                filterContext.Result = RedirectToAction("Index", "Login");
                                Dispose();
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonCode.Log(ex);
                }
                #endregion

                #region Dropdowns modal configuration
                //DGG 20201124 Viewbags para configuracion
                //if (!Request.IsAjaxRequest())
                //{
                //    #region CRM
                //    var paramCRM = gEntity.Parametros_CRM.First();

                //    if (!paramCRM.TipoTelefono_id.HasValue)
                //        ViewBag.isNull_tipoTelefono = true;

                //    if (!paramCRM.TipoProyecto_ID.HasValue)
                //        ViewBag.isNull_tipoSistema = true;

                //    if (!paramCRM.Rol_Admin.HasValue)
                //        ViewBag.isNull_rolAdmin = true;

                //    if (!paramCRM.Rol_Gerente.HasValue)
                //        ViewBag.isNull_rolGerente = true;

                //    if (!paramCRM.Rol_Vendedor.HasValue)
                //        ViewBag.isNull_rolVendedor = true;

                //    ViewBag.dropdown_tipoTelefono = new SelectList(gEntity.TIPO_TELEFONO.OrderBy(x => x.ORDENAPARECE), "NUMERO", "NOMBRE", paramCRM.TipoTelefono_id).ToList();
                //    ViewBag.dropdown_tipoSistema = new SelectList(gEntity.Tipo_Sistema, "Numero", "Nombre", paramCRM.TipoProyecto_ID).ToList();
                //    ViewBag.dropdown_rolesAdmin = new SelectList(gEntity.Roles_Sistema, "Numero", "Nombre", paramCRM.Rol_Admin).ToList();
                //    ViewBag.dropdown_rolesGerente = new SelectList(gEntity.Roles_Sistema, "Numero", "Nombre", paramCRM.Rol_Gerente).ToList();
                //    ViewBag.dropdown_rolesVendedor = new SelectList(gEntity.Roles_Sistema, "Numero", "Nombre", paramCRM.Rol_Vendedor).ToList();

                //    //DGG 20201218
                //    if (string.IsNullOrEmpty(paramCRM.PaginaInicio))
                //        ViewBag.isNull_paginaInicio = true;

                //    List<SelectListItem> selectListItems = new List<SelectListItem>();
                //    selectListItems.Add(new SelectListItem() { Text = "Página en blanco", Value = "1", Selected = paramCRM.PaginaInicio == "P" });
                //    selectListItems.Add(new SelectListItem() { Text = "Control diario", Value = "2", Selected = paramCRM.PaginaInicio == "C" });
                //    selectListItems.Add(new SelectListItem() { Text = "Dashboard", Value = "3", Selected = paramCRM.PaginaInicio == "D" });
                //    ViewBag.dropdown_paginaInicio = selectListItems;
                //    ViewBag.input_tiempoSesion = paramCRM.SessionTimeOut ?? 20;

                //    #endregion
                //}
                //Fin DGG 20201124
                #endregion

                //No sirve implementado de esta manera
                #region Redirect on end session
                if (!Request.IsAjaxRequest())
                {
                    ViewBag.TimeOutMins = Session.Timeout;
                    //Response.AddHeader("Refresh", Convert.ToString(Session.Timeout * 60));
                }
                #endregion
            }
            catch (Exception ex)
            {
                CommonCode.Log(ex);
            }
        }

    }
}