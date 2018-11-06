using ProyectoVuelaSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoVuelaSA.Controllers
{
    public class HomeController : Controller
    {
        private ProyectoRequeEntities db = new ProyectoRequeEntities();

        public ActionResult Index()
        {
            return View();
        }

        //ViewBag.idfederacion = new SelectList(db.federacion, "idfederacion", "idfederacion");

        [HttpPost]
        public ActionResult Index(usuario usuarioLogIn){

            usuario usuario = db.usuario.Where(u=> u.idusuario == usuarioLogIn.idusuario && u.contrasena == usuarioLogIn.contrasena).FirstOrDefault();
            if(usuario != null)
            {
                Session["IDUsuario"] = usuario.idusuario;
                if(usuario.pasaporte != null)
                {
                    return RedirectToAction("Cliente");
                }
                else
                {
                    return RedirectToAction("Administrador");
                }
            }
            else
            {
                ModelState.AddModelError("", "Usuario no valido");
            }
            return View();
        }

        public ActionResult Cliente()
        {
            if(Session["IDUsuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Administrador()
        {
            if (Session["IDUsuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}

/*<div class="form-group">
            @Html.LabelFor(model => model.idfederacion, "idfederacion", htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownList("idfederacion", null, htmlAttributes: new { @class = "form-control", style = "height: 50px;" })
                @Html.ValidationMessageFor(model => model.idfederacion, "", new { @class = "text-danger" })
            </div>
        </div>*/
