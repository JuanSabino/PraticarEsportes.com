using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PraticarEsportes.Models;

namespace PraticarEsportes.Controllers
{
    public class CuponsController : Controller
    {
        private Context db = new Context();

        // GET: Cupons
        public ActionResult Index()
        {
            return View(db.Cupons.ToList());
        }

        // GET: Cupons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupom cupom = db.Cupons.Find(id);
            if (cupom == null)
            {
                return HttpNotFound();
            }
            return View(cupom);
        }

        // GET: Cupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CupomId,Valor,Tipo,Quantidade,Validade")] Cupom cupom)
        {
            if (ModelState.IsValid)
            {
                db.Cupons.Add(cupom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cupom);
        }

        // GET: Cupons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupom cupom = db.Cupons.Find(id);
            if (cupom == null)
            {
                return HttpNotFound();
            }
            return View(cupom);
        }

        // POST: Cupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CupomId,Valor,Tipo,Quantidade,Validade")] Cupom cupom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cupom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cupom);
        }

        // GET: Cupons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupom cupom = db.Cupons.Find(id);
            if (cupom == null)
            {
                return HttpNotFound();
            }
            return View(cupom);
        }

        // POST: Cupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cupom cupom = db.Cupons.Find(id);
            db.Cupons.Remove(cupom);
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
