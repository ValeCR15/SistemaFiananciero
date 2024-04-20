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
    public class ProyeccionVentasController : Controller
    {
        private SFEntities db = new SFEntities();

        // GET: ProyeccionVentas
        public ActionResult Index()
        {
            var proyeccionVentas = db.ProyeccionVentas.Include(p => p.CuentaContable);
            return View(proyeccionVentas.ToList());
        }

        // GET: ProyeccionVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProyeccionVenta proyeccionVenta = db.ProyeccionVentas.Find(id);
            if (proyeccionVenta == null)
            {
                return HttpNotFound();
            }
            return View(proyeccionVenta);
        }

        // GET: ProyeccionVentas/Create
        public ActionResult Create()
        {
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo");
            return View();
        }

        // POST: ProyeccionVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,monto_proyectado,producto,cuenta_contable_id,fecha_creacion,fecha_actualizacion")] ProyeccionVenta proyeccionVenta)
        {
            if (ModelState.IsValid)
            {
                db.ProyeccionVentas.Add(proyeccionVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", proyeccionVenta.cuenta_contable_id);
            return View(proyeccionVenta);
        }

        // GET: ProyeccionVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProyeccionVenta proyeccionVenta = db.ProyeccionVentas.Find(id);
            if (proyeccionVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", proyeccionVenta.cuenta_contable_id);
            return View(proyeccionVenta);
        }

        // POST: ProyeccionVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,monto_proyectado,producto,cuenta_contable_id,fecha_creacion,fecha_actualizacion")] ProyeccionVenta proyeccionVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyeccionVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", proyeccionVenta.cuenta_contable_id);
            return View(proyeccionVenta);
        }

        // GET: ProyeccionVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProyeccionVenta proyeccionVenta = db.ProyeccionVentas.Find(id);
            if (proyeccionVenta == null)
            {
                return HttpNotFound();
            }
            return View(proyeccionVenta);
        }

        // POST: ProyeccionVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProyeccionVenta proyeccionVenta = db.ProyeccionVentas.Find(id);
            db.ProyeccionVentas.Remove(proyeccionVenta);
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
