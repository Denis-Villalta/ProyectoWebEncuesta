using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EncuestaEP.Models;

namespace EncuestaEP.Controllers
{
    public class LoginController : Controller
    {

        private Db_EncuestasEntities db = new Db_EncuestasEntities();

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                using (LoginModel db = new LoginModel())
                {
                    var obj = db.UserProfile.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View("");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public PartialViewResult Listado(string id)
        {

            if (Session["usuario"] == null)
            {

            }

            Models.RespuestasViewModel modelo = new RespuestasViewModel();
            modelo.lst_encabezado = new List<Respuesta_Encabezado>();

            List<Respuesta_Encabezado> lst_encabezado = new List<Respuesta_Encabezado>();
            int idencuesta = Convert.ToInt32(id);
            lst_encabezado = db.Respuesta_Encabezado.Where(x => x.id_encuesta == idencuesta).ToList();

            modelo.lst_encabezado = lst_encabezado;
            modelo.id_encuesta = Convert.ToInt32(id);
            Session["id_encuesta"] = idencuesta;




            return PartialView(modelo);
        }

        public JsonResult ingresar(int id_encuesta, DateTime fecha)
        {

            Respuesta_Encabezado entidad = new Respuesta_Encabezado();

            entidad.id_encuesta = id_encuesta;
            entidad.fecha = fecha;
            entidad.id_encuesta = Convert.ToInt32(Session["id_encuesta"].ToString());

            db.Respuesta_Encabezado.Add(entidad);
            db.SaveChanges();



            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public JsonResult eliminar(string id)
        {


            Respuesta_Encabezado entidad = new Respuesta_Encabezado();
            entidad.id = Convert.ToInt32(id);

            Respuesta_Encabezado busquedas = new Respuesta_Encabezado();
            if (db.Respuesta_Encabezado.Where(x => x.id == entidad.id).Count() > 0)
                busquedas = db.Respuesta_Encabezado.Where(x => x.id == entidad.id).First();

            if (busquedas != null)
            {
                db.Respuesta_Encabezado.Remove(busquedas);
                db.SaveChanges();
            }



            return Json("ok", JsonRequestBehavior.AllowGet);
        }
    }
}