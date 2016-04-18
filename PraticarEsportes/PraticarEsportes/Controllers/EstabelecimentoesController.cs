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
    public class EstabelecimentoesController : Controller
    {
        private Context db = new Context();

        // GET: Estabelecimentoes
        public ActionResult Index()
        {
            return View(db.Pessoas.ToList());
        }

        // GET: Estabelecimentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = (Estabelecimento) db.Pessoas.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estabelecimentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaId,Telefone,Endereco,CEP,Cidade,Estado,Habilitado,NomeFantasia,RazaoSocial,CNPJ,TelComercial,DataAbertura")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(estabelecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estabelecimento);
        }

        // GET: Estabelecimentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = (Estabelecimento) db.Pessoas.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // POST: Estabelecimentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaId,Telefone,Endereco,CEP,Cidade,Estado,Habilitado,NomeFantasia,RazaoSocial,CNPJ,TelComercial,DataAbertura")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estabelecimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimento estabelecimento = (Estabelecimento) db.Pessoas.Find(id);
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimento);
        }

        // POST: Estabelecimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estabelecimento estabelecimento = (Estabelecimento) db.Pessoas.Find(id);
            db.Pessoas.Remove(estabelecimento);
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
