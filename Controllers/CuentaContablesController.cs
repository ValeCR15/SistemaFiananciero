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
    public class CuentaContablesController : Controller
    {
        private SFEntities db = new SFEntities();

        // GET: CuentaContables
        public ActionResult Index()
        {
            var cuentaContables = db.CuentaContables.Include(c => c.TipoMoneda).Include(c => c.TipoReflejar).Include(c => c.TipoSolicitud);
            return View(cuentaContables.ToList());
        }

        // GET: CuentaContables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaContable cuentaContable = db.CuentaContables.Find(id);
            if (cuentaContable == null)
            {
                return HttpNotFound();
            }
            return View(cuentaContable);
        }

        // GET: CuentaContables/Create
        public ActionResult Create()
        {
            ViewBag.TipoMoneda_id = new SelectList(db.TipoMonedas, "idTipoMoneda", "Descripcion");
            ViewBag.TipoRegistro_id = new SelectList(db.TipoReflejars, "idTiporegistro", "nombre");
            ViewBag.TipoSolicitud_id = new SelectList(db.TipoSolicituds, "idTipoSolicitud", "Descripcion");
            return View();
        }

        // POST: CuentaContables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nombre,fecha_solicitud,MedioEnvio,EntidadSolicitante,Justificacion,Correo,TipoSolicitud_id,TipoMoneda_id,TipoRegistro_id")] CuentaContable cuentaContable)
        {
            if (ModelState.IsValid)
            {
                db.CuentaContables.Add(cuentaContable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoMoneda_id = new SelectList(db.TipoMonedas, "idTipoMoneda", "Descripcion", cuentaContable.TipoMoneda_id);
            ViewBag.TipoRegistro_id = new SelectList(db.TipoReflejars, "idTiporegistro", "nombre", cuentaContable.TipoRegistro_id);
            ViewBag.TipoSolicitud_id = new SelectList(db.TipoSolicituds, "idTipoSolicitud", "Descripcion", cuentaContable.TipoSolicitud_id);
            return View(cuentaContable);
        }

        // GET: CuentaContables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaContable cuentaContable = db.CuentaContables.Find(id);
            if (cuentaContable == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoMoneda_id = new SelectList(db.TipoMonedas, "idTipoMoneda", "Descripcion", cuentaContable.TipoMoneda_id);
            ViewBag.TipoRegistro_id = new SelectList(db.TipoReflejars, "idTiporegistro", "nombre", cuentaContable.TipoRegistro_id);
            ViewBag.TipoSolicitud_id = new SelectList(db.TipoSolicituds, "idTipoSolicitud", "Descripcion", cuentaContable.TipoSolicitud_id);
            return View(cuentaContable);
        }

        // POST: CuentaContables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,fecha_solicitud,MedioEnvio,EntidadSolicitante,Justificacion,Correo,TipoSolicitud_id,TipoMoneda_id,TipoRegistro_id")] CuentaContable cuentaContable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentaContable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoMoneda_id = new SelectList(db.TipoMonedas, "idTipoMoneda", "Descripcion", cuentaContable.TipoMoneda_id);
            ViewBag.TipoRegistro_id = new SelectList(db.TipoReflejars, "idTiporegistro", "nombre", cuentaContable.TipoRegistro_id);
            ViewBag.TipoSolicitud_id = new SelectList(db.TipoSolicituds, "idTipoSolicitud", "Descripcion", cuentaContable.TipoSolicitud_id);
            return View(cuentaContable);
        }

        // GET: CuentaContables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaContable cuentaContable = db.CuentaContables.Find(id);
            if (cuentaContable == null)
            {
                return HttpNotFound();
            }
            return View(cuentaContable);
        }

        // POST: CuentaContables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuentaContable cuentaContable = db.CuentaContables.Find(id);
            db.CuentaContables.Remove(cuentaContable);
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
