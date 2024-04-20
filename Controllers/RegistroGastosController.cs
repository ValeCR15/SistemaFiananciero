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
    public class RegistroGastosController : Controller
    {
        private SFEntities db = new SFEntities();

        // GET: RegistroGastos
        public ActionResult Index()
        {
            var registroGastos = db.RegistroGastos.Include(r => r.CuentaContable);
            return View(registroGastos.ToList());
        }

        // GET: RegistroGastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroGasto registroGasto = db.RegistroGastos.Find(id);
            if (registroGasto == null)
            {
                return HttpNotFound();
            }
            return View(registroGasto);
        }

        // GET: RegistroGastos/Create
        public ActionResult Create()
        {
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo");
            return View();
        }

        // POST: RegistroGastos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,descripcion,monto,proveedor,cuenta_contable_id,fecha_creacion,fecha_actualizacion")] RegistroGasto registroGasto)
        {
            if (ModelState.IsValid)
            {
                db.RegistroGastos.Add(registroGasto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", registroGasto.cuenta_contable_id);
            return View(registroGasto);
        }

        // GET: RegistroGastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroGasto registroGasto = db.RegistroGastos.Find(id);
            if (registroGasto == null)
            {
                return HttpNotFound();
            }
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", registroGasto.cuenta_contable_id);
            return View(registroGasto);
        }

        // POST: RegistroGastos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,descripcion,monto,proveedor,cuenta_contable_id,fecha_creacion,fecha_actualizacion")] RegistroGasto registroGasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroGasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cuenta_contable_id = new SelectList(db.CuentaContables, "id", "codigo", registroGasto.cuenta_contable_id);
            return View(registroGasto);
        }

        // GET: RegistroGastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroGasto registroGasto = db.RegistroGastos.Find(id);
            if (registroGasto == null)
            {
                return HttpNotFound();
            }
            return View(registroGasto);
        }

        // POST: RegistroGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroGasto registroGasto = db.RegistroGastos.Find(id);
            db.RegistroGastos.Remove(registroGasto);
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
