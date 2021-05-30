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
    public class Respuesta_DetalleController : Controller
    {
        private Db_EncuestasEntities db = new Db_EncuestasEntities();

        // GET: Respuesta_Detalle
        public ActionResult Index()
        {
            var respuesta_Detalle = db.Respuesta_Detalle.Include(r => r.Campos).Include(r => r.Respuesta_Encabezado);
            return View(respuesta_Detalle.ToList());
        }

        // GET: Respuesta_Detalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Detalle respuesta_Detalle = db.Respuesta_Detalle.Find(id);
            if (respuesta_Detalle == null)
            {
                return HttpNotFound();
            }
            return View(respuesta_Detalle);
        }

        // GET: Respuesta_Detalle/Create
        public ActionResult Create()
        {
            ViewBag.id_campo = new SelectList(db.Campos, "id", "nombre");
            ViewBag.id_encabezado = new SelectList(db.Respuesta_Encabezado, "id", "id");
            return View();
        }

        // POST: Respuesta_Detalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_campo,valor,id_encabezado")] Respuesta_Detalle respuesta_Detalle)
        {
            if (ModelState.IsValid)
            {
                db.Respuesta_Detalle.Add(respuesta_Detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_campo = new SelectList(db.Campos, "id", "nombre", respuesta_Detalle.id_campo);
            ViewBag.id_encabezado = new SelectList(db.Respuesta_Encabezado, "id", "id", respuesta_Detalle.id_encabezado);
            return View(respuesta_Detalle);
        }

        // GET: Respuesta_Detalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Detalle respuesta_Detalle = db.Respuesta_Detalle.Find(id);
            if (respuesta_Detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_campo = new SelectList(db.Campos, "id", "nombre", respuesta_Detalle.id_campo);
            ViewBag.id_encabezado = new SelectList(db.Respuesta_Encabezado, "id", "id", respuesta_Detalle.id_encabezado);
            return View(respuesta_Detalle);
        }

        // POST: Respuesta_Detalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_campo,valor,id_encabezado")] Respuesta_Detalle respuesta_Detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuesta_Detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_campo = new SelectList(db.Campos, "id", "nombre", respuesta_Detalle.id_campo);
            ViewBag.id_encabezado = new SelectList(db.Respuesta_Encabezado, "id", "id", respuesta_Detalle.id_encabezado);
            return View(respuesta_Detalle);
        }

        // GET: Respuesta_Detalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Detalle respuesta_Detalle = db.Respuesta_Detalle.Find(id);
            if (respuesta_Detalle == null)
            {
                return HttpNotFound();
            }
            return View(respuesta_Detalle);
        }

        // POST: Respuesta_Detalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respuesta_Detalle respuesta_Detalle = db.Respuesta_Detalle.Find(id);
            db.Respuesta_Detalle.Remove(respuesta_Detalle);
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
    }
}
