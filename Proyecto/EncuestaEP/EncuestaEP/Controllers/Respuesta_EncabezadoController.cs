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
    public class Respuesta_EncabezadoController : Controller
    {
        private Db_EncuestasEntities db = new Db_EncuestasEntities();

        // GET: Respuesta_Encabezado
        public ActionResult Index()
        {
            var respuesta_Encabezado = db.Respuesta_Encabezado.Include(r => r.Encuesta);
            return View(respuesta_Encabezado.ToList());
        }

        // GET: Respuesta_Encabezado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Encabezado respuesta_Encabezado = db.Respuesta_Encabezado.Find(id);
            if (respuesta_Encabezado == null)
            {
                return HttpNotFound();
            }
            return View(respuesta_Encabezado);
        }

        // GET: Respuesta_Encabezado/Create
        public ActionResult Create()
        {
            ViewBag.id_encuesta = new SelectList(db.Encuesta, "id", "nombre");
            return View();
        }

        // POST: Respuesta_Encabezado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_encuesta,fecha")] Respuesta_Encabezado respuesta_Encabezado)
        {
            if (ModelState.IsValid)
            {
                db.Respuesta_Encabezado.Add(respuesta_Encabezado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_encuesta = new SelectList(db.Encuesta, "id", "nombre", respuesta_Encabezado.id_encuesta);
            return View(respuesta_Encabezado);
        }

        // GET: Respuesta_Encabezado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Encabezado respuesta_Encabezado = db.Respuesta_Encabezado.Find(id);
            if (respuesta_Encabezado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_encuesta = new SelectList(db.Encuesta, "id", "nombre", respuesta_Encabezado.id_encuesta);
            return View(respuesta_Encabezado);
        }

        // POST: Respuesta_Encabezado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_encuesta,fecha")] Respuesta_Encabezado respuesta_Encabezado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuesta_Encabezado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_encuesta = new SelectList(db.Encuesta, "id", "nombre", respuesta_Encabezado.id_encuesta);
            return View(respuesta_Encabezado);
        }

        // GET: Respuesta_Encabezado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Encabezado respuesta_Encabezado = db.Respuesta_Encabezado.Find(id);
            if (respuesta_Encabezado == null)
            {
                return HttpNotFound();
            }
            return View(respuesta_Encabezado);
        }

        // POST: Respuesta_Encabezado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respuesta_Encabezado respuesta_Encabezado = db.Respuesta_Encabezado.Find(id);
            db.Respuesta_Encabezado.Remove(respuesta_Encabezado);
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
