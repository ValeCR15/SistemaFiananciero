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
    public class ProyeccionGastosController : Controller
    {
        private SFEntities db = new SFEntities();

        // GET: ProyeccionGastos
        public ActionResult Index()
        {
            var proyeccionGastos = db.ProyeccionGastos.Include(p => p.CuentaContable);
            return View(proyeccionGastos.ToList());
        }

        // GET: ProyeccionGastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProyeccionGasto proyeccionGasto = db.ProyeccionGastos.Find(id);
            if (proyeccionGasto == null)
            {
                return HttpNotFound();
            }
            return View(proyeccionGasto);
        }

        // GET: ProyeccionGastos/Create
        public ActionResult Create()
        {
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo");
            return View();
        }

        // POST: ProyeccionGastos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,monto_proyectado,categoria,cuenta_contable_id,fecha_creacion,fecha_actualizacion")] ProyeccionGasto proyeccionGasto)
        {
            if (ModelState.IsValid)
            {
                db.ProyeccionGastos.Add(proyeccionGasto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", proyeccionGasto.cuenta_contable_id);
            return View(proyeccionGasto);
        }

        // GET: ProyeccionGastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProyeccionGasto proyeccionGasto = db.ProyeccionGastos.Find(id);
            if (proyeccionGasto == null)
            {
                return HttpNotFound();
            }
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", proyeccionGasto.cuenta_contable_id);
            return View(proyeccionGasto);
        }

        // POST: ProyeccionGastos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,monto_proyectado,categoria,cuenta_contable_id,fecha_creacion,fecha_actualizacion")] ProyeccionGasto proyeccionGasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyeccionGasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", proyeccionGasto.cuenta_contable_id);
            return View(proyeccionGasto);
        }

        // GET: ProyeccionGastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProyeccionGasto proyeccionGasto = db.ProyeccionGastos.Find(id);
            if (proyeccionGasto == null)
            {
                return HttpNotFound();
            }
            return View(proyeccionGasto);
        }

        // POST: ProyeccionGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProyeccionGasto proyeccionGasto = db.ProyeccionGastos.Find(id);
            db.ProyeccionGastos.Remove(proyeccionGasto);
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
