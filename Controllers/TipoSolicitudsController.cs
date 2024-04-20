using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaFinanciero.Models;

namespace SistemaFinanciero.Controllers
{
    public class TipoSolicitudsController : Controller
    {
        private SFEntities db = new SFEntities();

        // GET: TipoSolicituds
        public ActionResult Index()
        {
            return View(db.TipoSolicituds.ToList());
        }

        // GET: TipoSolicituds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSolicitud tipoSolicitud = db.TipoSolicituds.Find(id);
            if (tipoSolicitud == null)
            {
                return HttpNotFound();
            }
            return View(tipoSolicitud);
        }

        // GET: TipoSolicituds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoSolicituds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoSolicitud,Descripcion")] TipoSolicitud tipoSolicitud)
        {
            if (ModelState.IsValid)
            {
                db.TipoSolicituds.Add(tipoSolicitud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoSolicitud);
        }

        // GET: TipoSolicituds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSolicitud tipoSolicitud = db.TipoSolicituds.Find(id);
            if (tipoSolicitud == null)
            {
                return HttpNotFound();
            }
            return View(tipoSolicitud);
        }

        // POST: TipoSolicituds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoSolicitud,Descripcion")] TipoSolicitud tipoSolicitud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoSolicitud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoSolicitud);
        }

        // GET: TipoSolicituds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSolicitud tipoSolicitud = db.TipoSolicituds.Find(id);
            if (tipoSolicitud == null)
            {
                return HttpNotFound();
            }
            return View(tipoSolicitud);
        }

        // POST: TipoSolicituds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoSolicitud tipoSolicitud = db.TipoSolicituds.Find(id);
            db.TipoSolicituds.Remove(tipoSolicitud);
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
