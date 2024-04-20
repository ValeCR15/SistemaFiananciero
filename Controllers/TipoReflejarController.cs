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
    public class TipoReflejarController : Controller
    {
        private SFEntities db = new SFEntities();

        // GET: TipoReflejar
        public ActionResult Index()
        {
            return View(db.TipoReflejars.ToList());
        }

        // GET: TipoReflejar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoReflejar tipoReflejar = db.TipoReflejars.Find(id);
            if (tipoReflejar == null)
            {
                return HttpNotFound();
            }
            return View(tipoReflejar);
        }

        // GET: TipoReflejar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoReflejar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTiporegistro,nombre,numero")] TipoReflejar tipoReflejar)
        {
            if (ModelState.IsValid)
            {
                db.TipoReflejars.Add(tipoReflejar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoReflejar);
        }

        // GET: TipoReflejar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoReflejar tipoReflejar = db.TipoReflejars.Find(id);
            if (tipoReflejar == null)
            {
                return HttpNotFound();
            }
            return View(tipoReflejar);
        }

        // POST: TipoReflejar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTiporegistro,nombre,numero")] TipoReflejar tipoReflejar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoReflejar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoReflejar);
        }

        // GET: TipoReflejar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoReflejar tipoReflejar = db.TipoReflejars.Find(id);
            if (tipoReflejar == null)
            {
                return HttpNotFound();
            }
            return View(tipoReflejar);
        }

        // POST: TipoReflejar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoReflejar tipoReflejar = db.TipoReflejars.Find(id);
            db.TipoReflejars.Remove(tipoReflejar);
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
