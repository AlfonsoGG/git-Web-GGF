using GGF.Common;
using GGF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GGF.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string email, string password)
        {
            try
            {
                var hashPassword = CommonCode.HashPassword(password, CommonCode.GetSaltKey());
                using(var context = new GGF.Models.GiveGoodFaceEntities())
                {
                    var user = context.Usuarios.FirstOrDefault(x => x.CorreoElectronico == email && x.Contrasena == hashPassword && x.Activo == true);
                    if(user != null)
                    {
                        Session["userId"] = user.Usuario_Id;
                        return RedirectToAction("Index", "Patients");
                    }
                }
            }
            catch(Exception ex)
            {
                CommonCode.Log(ex);
            }
            ViewBag.msgLogIn = "Usuario o contraseña no validos";
            return View("Index");
        }

        [HttpPost]
        public ActionResult RegisterNew(string name, string email, string password, string passwordConfirm)
        {
            string message = string.Empty;
            try
            {
                using (GiveGoodFaceEntities context = new GGF.Models.GiveGoodFaceEntities())
                {
                    //Validacion de correo repetido
                    var user = context.Usuarios.FirstOrDefault(x => x.CorreoElectronico == email);
                    if(user != null)
                    {
                        message += "Usuario ya existente. ";
                    }

                    //Validacion de contraseñas correctas
                    if(password != passwordConfirm)
                    {
                        message += "Contraseña no coincide. ";
                    }
                    
                    if(message == string.Empty)
                    {
                        var hashPassword = CommonCode.HashPassword(password, CommonCode.GetSaltKey());
                        var rol = context.Roles.FirstOrDefault(x => x.Descripcion == "Terapeuta");

                        var newUser = new Usuarios { 
                            Rol_Id = rol.Rol_Id,
                            Nombre = name,
                            CorreoElectronico = email,
                            Contrasena = hashPassword,
                            Activo = true,
                            EdicionFecha = DateTime.Now,
                            EdicionUsuario = 0
                        };

                        context.Usuarios.Add(newUser);
                        context.SaveChanges();

                        Session["userId"] = newUser.Usuario_Id;
                        return RedirectToAction("Index", "Patients");
                    }
                }
            }
            catch (Exception ex)
            {
                CommonCode.Log(ex);
            }
            ViewBag.msgNewUser = message;
            ViewBag.RegisterModelName = new { name, email, password, passwordConfirm };
            ViewBag.RegisterModelEmail = new { name, email, password, passwordConfirm };
            return View("Index");
        }

        public ActionResult LogOff()
        {
            Session.Remove("userId");
            return RedirectToAction("Index", "Login");
        }

    }
}