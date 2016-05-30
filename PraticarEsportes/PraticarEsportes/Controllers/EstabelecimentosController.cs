using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PraticarEsportes.Models;
using PraticarEsportes.Repositories;

namespace PraticarEsportes.Controllers
{
    public class EstabelecimentosController : Controller
    {
        private Context db = new Context();

        // GET: Estabelecimentos
        public ActionResult Index()
        {
            Pessoa usuario = (Pessoa)Funcoes.GetUsuario();
            Pessoa pessoa2 = db.Pessoas.Include("Seguindo").Where(p => p.PessoaId == usuario.PessoaId).FirstOrDefault<Pessoa>();

            ViewBag.Seguindo = pessoa2.Seguindo;

            return View(db.Pessoas.OfType<Estabelecimento>().ToList());
        }

        // GET: Estabelecimentos/Details/5
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

        // GET: Estabelecimentos/Create
       /* public ActionResult Create()
        {
            return View();
        }

        // POST: Estabelecimentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaId,Telefone,Endereco,CEP,Cidade,Estado,Email,Senha,Habilitado,NomeFantasia,RazaoSocial,CNPJ,TelComercial,DataAbertura")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(estabelecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estabelecimento);
        }*/

        // GET: Estabelecimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            Estabelecimento estabelecimento = (Estabelecimento) Funcoes.GetUsuario();
            if (estabelecimento == null)
            {
                return HttpNotFound();
            }
            if (id != null && estabelecimento.PessoaId != id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
            return View(estabelecimento);
        }

        // POST: Estabelecimentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaId,Telefone,Endereco,CEP,Cidade,Estado,Email,NomeFantasia,RazaoSocial,CNPJ,TelComercial,DataAbertura")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estabelecimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Delete/5
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

        // POST: Estabelecimentos/Delete/5
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


        public ActionResult Follow(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Estabelecimentos");
            }
            Pessoa usuario = (Pessoa)Funcoes.GetUsuario();
            Pessoa pessoa2 = db.Pessoas.Include("Seguindo").Where(p => p.PessoaId == usuario.PessoaId).FirstOrDefault<Pessoa>();


            Estabelecimento seguir = (Estabelecimento)db.Pessoas.Find(id);

            bool segue = false;
            if (pessoa2.Seguindo != null)
            {
                foreach (Pessoa p1 in pessoa2.Seguindo)
                {
                    if (p1.PessoaId == id)
                    {
                        segue = true;
                        break;
                    }
                }
            }
            if (!segue)
            {
                pessoa2.Seguindo.Add(seguir);
                db.Entry(pessoa2).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Estabelecimentos");
        }

    }
}
