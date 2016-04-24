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
    public class PraticantesController : Controller
    {
        private Context db = new Context();

        // GET: Praticantes
        public ActionResult Index()
        {
            return View(db.Pessoas.OfType<Praticante>().ToList());
        }

        // GET: Praticantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Praticante praticante = (Praticante) db.Pessoas.Find(id);
            if (praticante == null)
            {
                return HttpNotFound();
            }
            return View(praticante);
        }

        // GET: Praticantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Praticantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PessoaId,Telefone,Endereco,CEP,Cidade,Estado,Email,Senha,Habilitado,Nome,CPF,DataNascimento,Profissao,EstadoCivil,Pontos")] Praticante praticante)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Pessoas.Add(praticante);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(praticante);
        //}

        // GET: Praticantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Praticante praticante = (Praticante) db.Pessoas.Find(id);
            if (praticante == null)
            {
                return HttpNotFound();
            }
            return View(praticante);
        }

        // POST: Praticantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaId,Telefone,Endereco,CEP,Cidade,Estado,Email,Senha,Habilitado,Nome,CPF,DataNascimento,Profissao,EstadoCivil,Pontos")] Praticante praticante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(praticante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(praticante);
        }

        // GET: Praticantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Praticante praticante = (Praticante)db.Pessoas.Find(id);
            if (praticante == null)
            {
                return HttpNotFound();
            }
            return View(praticante);
        }

        // POST: Praticantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Praticante praticante = (Praticante)db.Pessoas.Find(id);
            db.Pessoas.Remove(praticante);
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
