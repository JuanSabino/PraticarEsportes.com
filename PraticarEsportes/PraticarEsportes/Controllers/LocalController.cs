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
    public class LocalController : Controller
    {
        private Context db = new Context();
        [HttpPost]
        public ActionResult Pesquisa(FormCollection fc, string searchString)
        {
            Pessoa usuario = (Pessoa)Funcoes.GetUsuario();
            Pessoa pessoa2 = db.Pessoas.Include("LocaisCurtidos").Where(p => p.PessoaId == usuario.PessoaId).FirstOrDefault<Pessoa>();

            ViewBag.LocaisCurtidos = pessoa2.LocaisCurtidos;

            if (!String.IsNullOrEmpty(searchString))
            {
                var local = db.Local.Where(c => c.Nome.Contains(searchString) || c.Descricao.Contains(searchString) || c.Estado.Contains(searchString) || c.Endereco.Contains(searchString) || c.Cidade.Contains(searchString)).OrderBy(o => o.Nome);
                return View("Index", local.ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Local
        public ActionResult Index()
        {
            Pessoa usuario = (Pessoa)Funcoes.GetUsuario();
            Pessoa pessoa2 = db.Pessoas.Include("LocaisCurtidos").Where(p => p.PessoaId == usuario.PessoaId).FirstOrDefault<Pessoa>();

            ViewBag.LocaisCurtidos = pessoa2.LocaisCurtidos;

            return View(db.Local.ToList());
        }

        // GET: Local/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local local = db.Local.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // GET: Local/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Local/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao,Latitude,Longitude,Endereco,CEP,Cidade,Estado")] Local local)
        {
            //if (ModelState.IsValid)
            //{

                string latitude = Request["Latitude"];
                latitude = latitude.Replace(".", ",");

                string longitude = Request["Longitude"];
                longitude = longitude.Replace(".", ",");

                local.Latitude = Convert.ToDouble(latitude);
                local.Longitude = Convert.ToDouble(longitude);
                local.Habilitado = false;
                ViewBag.salvo = 1;
                db.Local.Add(local);
                db.SaveChanges();
                ViewBag.Mensagem = "Cadastrado com sucesso!";
                return View(local);
            //}

            //return PartialView(local);
        }

        // GET: Local/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local local = db.Local.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }
                        
            return View(local);
        }

        // POST: Local/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao,Latitude,Longitude,Endereco,CEP,Cidade,Estado,Habilitado")] Local local)
        {
            //if (ModelState.IsValid)
            //{
                string latitude = Request["Latitude"];
                latitude = latitude.Replace(".", ",");

                string longitude = Request["Longitude"];
                longitude = longitude.Replace(".", ",");

                local.Latitude = Convert.ToDouble(latitude);
                local.Longitude = Convert.ToDouble(longitude);

                db.Entry(local).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //return View(local);
        }

        // GET: Local/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local local = db.Local.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // POST: Local/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Local local = db.Local.Find(id);
            db.Local.Remove(local);
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

        public ActionResult Like(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Local");
            }
            Pessoa usuario = (Pessoa)Funcoes.GetUsuario();
            Pessoa pessoa2 = db.Pessoas.Include("LocaisCurtidos").Where(p => p.PessoaId == usuario.PessoaId).FirstOrDefault<Pessoa>();


            Local curtir = db.Local.Find(id);

            bool segue = false;
            if (pessoa2.LocaisCurtidos != null)
            {
                foreach (Local p1 in pessoa2.LocaisCurtidos)
                {
                    if (p1.ID == id)
                    {
                        segue = true;
                        break;
                    }
                }
            }
            if (!segue)
            {
                pessoa2.LocaisCurtidos.Add(curtir);
                db.Entry(pessoa2).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Local");
        }
    }
}
