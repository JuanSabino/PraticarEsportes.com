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
    public class CheckinsController : Controller
    {
        private Context db = new Context();

        // GET: Checkins
        public ActionResult Index()
        {
            var checkins = db.Checkins.Include(c => c.Pessoa);
            return View(checkins.ToList());
        }

        // GET: Checkins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkin checkin = db.Checkins.Find(id);
            if (checkin == null)
            {
                return HttpNotFound();
            }
            return View(checkin);
        }

        // GET: Checkins/Create
        public ActionResult Create()
        {
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Telefone");
            return View();
        }

        // POST: Checkins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CheckinId,Data,PessoaId")] Checkin checkin)
        {
            if (ModelState.IsValid)
            {
                db.Checkins.Add(checkin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Telefone", checkin.PessoaId);
            return View(checkin);
        }

        // GET: Checkins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkin checkin = db.Checkins.Find(id);
            if (checkin == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Telefone", checkin.PessoaId);
            return View(checkin);
        }

        // POST: Checkins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CheckinId,Data,PessoaId")] Checkin checkin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Telefone", checkin.PessoaId);
            return View(checkin);
        }

        // GET: Checkins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkin checkin = db.Checkins.Find(id);
            if (checkin == null)
            {
                return HttpNotFound();
            }
            return View(checkin);
        }

        // POST: Checkins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Checkin checkin = db.Checkins.Find(id);
            db.Checkins.Remove(checkin);
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
