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
            Praticante praticante = (Praticante)Funcoes.GetUsuario();
            if (praticante == null)
            {
                return HttpNotFound();
            }
            if (id != null && praticante.PessoaId != id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }    
            return View(praticante);
        }

        // POST: Praticantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaId,Telefone,Endereco,CEP,Cidade,Estado,Email,Nome,CPF,DataNascimento,Profissao,EstadoCivil,Pontos")] Praticante praticante)
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
            Praticante praticante = (Praticante)Funcoes.GetUsuario();
            if (id == null || praticante.PessoaId != id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            praticante = (Praticante)db.Pessoas.Find(id);
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

        public ActionResult Denuncia(int? id)
        {
            Praticante praticante;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                praticante = (Praticante)db.Pessoas.Find(id);
            }
            catch(Exception ex)
            {
                return HttpNotFound();
            }            
            if (praticante == null)
            {
                return HttpNotFound();
            }
            return View(praticante);
        }

        [HttpPost]
        public ActionResult Denuncia(int id, string Motivo,  HttpPostedFileBase Arquivo)
        {
            if (String.IsNullOrEmpty(Motivo))
            {
                ViewBag.Error = "Você deve preencher o motivo!";
                return View();
            }
            Praticante praticante = (Praticante)db.Pessoas.Find(id);


            GmailEmailService gmail = new GmailEmailService();
            EmailMessage msg = new EmailMessage();

            msg.Body = "<HTML><BODY>Usuário " + System.Web.HttpContext.Current.Session["Nome"] + " acabou de realizar uma denúncia!<br />";
            msg.Body += "Usuário denunciado: " + praticante.Nome;
            msg.Body += "<br />Motivo:</br>";
            msg.Body += Motivo;
            msg.isHtml = true;
            msg.Subject = "Denuncia de usuário";
            msg.ToEmail = "praticaresportes.com@gmail.com";
            if (gmail.SendEmailService(msg))
            {
                ViewBag.Error = "Muito obrigado, a administração irá analizar sua denúncia.";
            }
            else
            {
                ViewBag.Error = "Erro. Tente novamente!";
            }
            return View();
        }


        public ActionResult AlterarSenha()
        {
            Praticante praticante;
            try
            {
                praticante = (Praticante) Funcoes.GetUsuario();
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }
            if (praticante == null)
            {
                return HttpNotFound();
            }
            return View(praticante);
        }

        [HttpPost]
        public ActionResult AlterarSenha(string SenhaAtual, string NovaSenha1, string NovaSenha2)
        {
            Praticante praticante = (Praticante)Funcoes.GetUsuario();
            if ( praticante.Senha != SenhaAtual)
            {
                ViewBag.Error = "Senha atual incorreta!";
                return View(praticante);
            }
            if (NovaSenha1 != NovaSenha2)
            {
                ViewBag.Error = "Novas senhas diferentes!";
                return View(praticante);
            }
            if (NovaSenha1 != SenhaAtual)
            {
                ViewBag.Error = "Nova senha deve ser diferente da anterior!";
                return View(praticante);
            }

            Context _db = new Context();
            var query = (from u in _db.Pessoas
                         where u.Email == praticante.Email
                         select u).SingleOrDefault();
            query.Senha = NovaSenha1;
            db.Entry(query).State = EntityState.Modified;
            db.SaveChanges();

            ViewBag.Error = "Senha Alterada!";
            return View(praticante);
        }

        [HttpPost]
        public ActionResult Desativar(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                Praticante praticante = (Praticante)Funcoes.GetUsuario();
                if (praticante == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                Context _db = new Context();
                var query = (from u in _db.Pessoas
                             where u.Email == email
                             select u).SingleOrDefault();
                query.Habilitado = false;
                db.Entry(query).State = EntityState.Modified;
                db.SaveChanges();

                Funcoes.Deslogar();

            }    
            return RedirectToAction("Index", "Home");
        }


    }
}
