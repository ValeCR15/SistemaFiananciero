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
    public class TipoMonedasController : Controller
    {
        private SFEntities db = new SFEntities();

        // GET: TipoMonedas
        public ActionResult Index()
        {
            return View(db.TipoMonedas.ToList());
        }

        // GET: TipoMonedas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMoneda tipoMoneda = db.TipoMonedas.Find(id);
            if (tipoMoneda == null)
            {
                return HttpNotFound();
            }
            return View(tipoMoneda);
        }

        // GET: TipoMonedas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoMonedas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoMoneda,Descripcion")] TipoMoneda tipoMoneda)
        {
            if (ModelState.IsValid)
            {
                db.TipoMonedas.Add(tipoMoneda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoMoneda);
        }

        // GET: TipoMonedas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMoneda tipoMoneda = db.TipoMonedas.Find(id);
            if (tipoMoneda == null)
            {
                return HttpNotFound();
            }
            return View(tipoMoneda);
        }

        // POST: TipoMonedas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoMoneda,Descripcion")] TipoMoneda tipoMoneda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoMoneda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoMoneda);
        }

        // GET: TipoMonedas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMoneda tipoMoneda = db.TipoMonedas.Find(id);
            if (tipoMoneda == null)
            {
                return HttpNotFound();
            }
            return View(tipoMoneda);
        }

        // POST: TipoMonedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoMoneda tipoMoneda = db.TipoMonedas.Find(id);
            db.TipoMonedas.Remove(tipoMoneda);
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
