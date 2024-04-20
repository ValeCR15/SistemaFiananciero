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
    public class OrdenProduccionController : Controller
    {
        private SFEntities db = new SFEntities();

        // GET: OrdenProduccion
        public ActionResult Index()
        {
            var ordenProduccions = db.OrdenProduccions.Include(o => o.CuentaContable);
            return View(ordenProduccions.ToList());
        }

        // GET: OrdenProduccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenProduccion ordenProduccion = db.OrdenProduccions.Find(id);
            if (ordenProduccion == null)
            {
                return HttpNotFound();
            }
            return View(ordenProduccion);
        }

        // GET: OrdenProduccion/Create
        public ActionResult Create()
        {
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo");
            return View();
        }

        // POST: OrdenProduccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha_inicio,fecha_fin,costo_total,estado,cuenta_contable_id,fecha_creacion,fecha_actualizacion")] OrdenProduccion ordenProduccion)
        {
            if (ModelState.IsValid)
            {
                db.OrdenProduccions.Add(ordenProduccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", ordenProduccion.cuenta_contable_id);
            return View(ordenProduccion);
        }

        // GET: OrdenProduccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenProduccion ordenProduccion = db.OrdenProduccions.Find(id);
            if (ordenProduccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", ordenProduccion.cuenta_contable_id);
            return View(ordenProduccion);
        }

        // POST: OrdenProduccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha_inicio,fecha_fin,costo_total,estado,cuenta_contable_id,fecha_creacion,fecha_actualizacion")] OrdenProduccion ordenProduccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenProduccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", ordenProduccion.cuenta_contable_id);
            return View(ordenProduccion);
        }

        // GET: OrdenProduccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenProduccion ordenProduccion = db.OrdenProduccions.Find(id);
            if (ordenProduccion == null)
            {
                return HttpNotFound();
            }
            return View(ordenProduccion);
        }

        // POST: OrdenProduccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenProduccion ordenProduccion = db.OrdenProduccions.Find(id);
            db.OrdenProduccions.Remove(ordenProduccion);
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
