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
using System.Web.Security;

namespace PraticarEsportes.Controllers
{
    public class EventoController : Controller
    {
        private Context db = new Context();

        public ActionResult EventoCategoria(int? id)
        {
            //Evento evento = db.Evento.Find(id);
            var evento = db.Evento.Include(e => e.Categoria).Include(e => e.Local);
            ViewBag.EventoCategoria = evento.Where(e => e.CategoriaID == id).ToList();
            return View();
        }

        public ActionResult Contador(int? id)
        {
            //Evento evento = db.Evento.Find(id);
            var evento = db.Evento.Include(e => e.Categoria).Include(e => e.Local);
            ViewBag.Contador = evento.Where(e => e.LocalID == id).ToList();

            var local = db.Local.Include(e => e.Evento);
            ViewBag.Local = local.Where(e => e.ID== id).ToList();
            return View();
        }

        // GET: Evento
        public ActionResult Index()
        {
            var evento = db.Evento.Include(e => e.Categoria).Include(e => e.Local);
            return View(evento.ToList());
        }

        // GET: Evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Include("PessoasConfirmadas").Where(e => e.ID == id).FirstOrDefault<Evento>();
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome");
            ViewBag.LocalID = new SelectList(db.Local, "ID", "Nome");
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao,DataInicio,DataTermino,Capacidade,Dificuldade,LocalID,CategoriaID,Habilitado")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                int PessoaId = Convert.ToInt32(System.Web.HttpContext.Current.Session["Id"]);
                evento.PessoaId = PessoaId;
                db.Evento.Add(evento);
                db.SaveChanges();
                //insere no historico
                
                string Descricao = "Criou evento #" + evento.ID.ToString() + " - " + evento.Nome;
                Funcoes.InsereHistorico(PessoaId, Descricao);
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome", evento.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Local, "ID", "Nome", evento.LocalID);
            return View(evento);
        }

        // GET: Evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome", evento.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Local, "ID", "Nome", evento.LocalID);
            return View(evento);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao,DataInicio,DataTermino,Capacidade,Dificuldade,LocalID,CategoriaID,Habilitado")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                evento.PessoaId = 1;
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "Nome", evento.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Local, "ID", "Nome", evento.LocalID);
            return View(evento);
        }

        // GET: Evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Evento.Find(id);
            db.Evento.Remove(evento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
       
        public ActionResult ConfirmarPresenca(int id)
        {
            Evento evento = db.Evento.Find(id);

            Pessoa pessoa = (Pessoa) Funcoes.GetUsuario();

            Pessoa pessoa2 = db.Pessoas.Include("EventosConfirmados").Where(p => p.PessoaId == pessoa.PessoaId).FirstOrDefault<Pessoa>();


            pessoa2.EventosConfirmados.Add(evento);

            db.SaveChanges();

            string Descricao = "Confirmou presença no evento #" + evento.ID.ToString() + " - " + evento.Nome;
            Funcoes.InsereHistorico(pessoa2.PessoaId, Descricao);
            return RedirectToAction("Index");
        }

        public ActionResult CancelarPresenca(int id)
        {
            return View();
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
