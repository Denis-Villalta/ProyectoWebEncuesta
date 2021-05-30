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
    public class CamposController : Controller
    {
        private Db_EncuestasEntities db = new Db_EncuestasEntities();

        // GET: Campos
        public ActionResult Index()
        {

            if (Session["usuario"] == null)
            {
                return RedirectToAction("login", "login");
            }

            var campos = db.Campos.Include(c => c.Encuesta);
            return View(campos.ToList());
        }

        // GET: Campos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campos campos = db.Campos.Find(id);
            if (campos == null)
            {
                return HttpNotFound();
            }
            return View(campos);
        }

        // GET: Campos/Create
        public ActionResult Create()
        {
            ViewBag.id_encuesta = new SelectList(db.Encuesta, "id", "nombre");
            return View();
        }

        // POST: Campos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_encuesta,nombre,titulo,requerido,tipo")] Campos campos)
        {
            if (ModelState.IsValid)
            {
                db.Campos.Add(campos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_encuesta = new SelectList(db.Encuesta, "id", "nombre", campos.id_encuesta);
            return View(campos);
        }

        // GET: Campos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campos campos = db.Campos.Find(id);
            if (campos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_encuesta = new SelectList(db.Encuesta, "id", "nombre", campos.id_encuesta);
            return View(campos);
        }

        // POST: Campos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_encuesta,nombre,titulo,requerido,tipo")] Campos campos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_encuesta = new SelectList(db.Encuesta, "id", "nombre", campos.id_encuesta);
            return View(campos);
        }

        // GET: Campos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campos campos = db.Campos.Find(id);
            if (campos == null)
            {
                return HttpNotFound();
            }
            return View(campos);
        }

        // POST: Campos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campos campos = db.Campos.Find(id);
            db.Campos.Remove(campos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public PartialViewResult Listado(string id)
        {

            if (Session["usuario"] == null)
            {
              
            }

            Models.CamposViewModel modelo = new CamposViewModel();
            modelo.lst_campos = new List<Campos>();

            List<Campos> lst_campos = new List<Campos>();
            int idencuesta = Convert.ToInt32(id);
            lst_campos = db.Campos.Where(x => x.id_encuesta == idencuesta).ToList();

            modelo.lst_campos = lst_campos;
            modelo.id_encuesta = Convert.ToInt32(id);
            Session["id_encuesta"] = idencuesta;
      



            return PartialView(modelo);
        }

        public JsonResult ingresar(string nombre,string titulo,bool requerido , string tipo)
        {

            Campos entidad = new Campos();

            entidad.nombre = nombre;
            entidad.titulo = titulo;
            entidad.requerido = requerido;
            entidad.tipo = Convert.ToByte(tipo);
            entidad.id_encuesta = Convert.ToInt32(Session["id_encuesta"].ToString());

            db.Campos.Add(entidad);
            db.SaveChanges();

            

            return Json("ok",JsonRequestBehavior.AllowGet);
        }

        public JsonResult eliminar(string id)
        {
            

            Campos entidad = new Campos();
            entidad.id = Convert.ToInt32(id);

            Campos busquedas = new Campos();
            if(db.Campos.Where(x => x.id == entidad.id).Count()>0)
            busquedas = db.Campos.Where(x => x.id == entidad.id).First();

            if(busquedas!=null)
            { 
            db.Campos.Remove(busquedas);
            db.SaveChanges();
            }



            return Json("ok", JsonRequestBehavior.AllowGet);
        }




    }
}
