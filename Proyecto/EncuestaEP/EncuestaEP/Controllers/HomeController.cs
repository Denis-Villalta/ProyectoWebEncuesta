
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EncuestaEP.Models;

namespace EncuestaEP.Controllers
{
    public class HomeController : Controller
    {
        private Models.Db_EncuestasEntities db = new Db_EncuestasEntities();
        public ActionResult Index(Usuarios usuario)
        {

            Usuarios usuario1 = new Usuarios();

            if (db.Usuarios.Where(x => x.password == usuario.password && x.username == usuario.username).Count()>0)
            { 
                usuario1 = db.Usuarios.Where(x => x.password == usuario.password && x.username == usuario.username).First();

                Session["usuario"] = usuario1;

            }
            else
            {
                return RedirectToAction("login", "login");
            }

            
            
            


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}