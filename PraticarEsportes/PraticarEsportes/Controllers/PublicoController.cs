using PraticarEsportes.Models;
using PraticarEsportes.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PraticarEsportes.Controllers
{
    public class PublicoController : Controller
    {
        private Context db = new Context();
        // GET: Publico
        public ActionResult Logar()
        {
            ViewBag.Categoria = db.Categoria.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Logar([Bind(Include = "Email, Senha")] Pessoa pessoa,string email, string senha)
        {
            if (ModelState.IsValid)
            {
                if (Funcoes.AutenticarUsuario(email, senha) == false)
                {
                    ViewBag.Error = "Nome de usuário e/ou senha inválida";
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult AcessoNegado()
        {
            using (Context c = new Context())
            {
                return View();
            }
        }

        public ActionResult Logoff()
        {
            PraticarEsportes.Repositories.Funcoes.Deslogar();
            return RedirectToAction("Logar", "Publico");
        }


        public ActionResult RecuperarSenha()
        {
            using (Context c = new Context())
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult RecuperarSenha(string email)
        {
            //busca o email do candango
            Context _db = new Context();
            var query = (from u in _db.Pessoas
                         where u.Email == email 
                         select u).SingleOrDefault();
            if (query == null)
            {
                ViewBag.Error = "Email nao localizado!";
                return View();
            }
            //cria hash
            string hash = Funcoes.Hash(query.Email + DateTime.Now.ToString());
            System.Web.HttpContext.Current.Session["RecuperarSenha"] = hash;


            GmailEmailService gmail = new GmailEmailService();
            EmailMessage msg = new EmailMessage();
            msg.Body = "<HTML><BODY>Caro Usuario<br />";
            msg.Body += "Para voltar a acessar a sua conta do Praticar Esportes, você precisa criar uma nova senha. <br />";
            msg.Body += "É fácil:<br />";
            msg.Body += "<br />Clique no link abaixo ou copie e cole na barra de enderecos do seu navegador:<br />";
            msg.Body += "<a href='http://localhost:61063/Publico/RecuperarSenha2?email=" + query.Email +  "&uid=" + hash + "'>http://localhost:61063/Publico/RecuperarSenha2?email=" + query.Email + "&uid=" + hash + "</a>";
            msg.isHtml = true;
            msg.Subject = "Recuperacao de senha";
            msg.ToEmail = "juan.pereira@uol.com.br";
            if (gmail.SendEmailService(msg))
            {
                ViewBag.Error = "Email para redefinicao de senha enviado!";
            }
            else
            {
                ViewBag.Error = "Erro ao enviar email. Tente novamente!";
            }            
            return View();
        }

        public ActionResult RecuperarSenha2(string email,string uid)
        {

            if ((System.Web.HttpContext.Current.Session["RecuperarSenha"] == null) || (System.Web.HttpContext.Current.Session["RecuperarSenha"].ToString() == ""))
            {
                return RedirectToAction("RecuperarSenha", "Publico");
            }
            if (String.IsNullOrEmpty(email)){
                return RedirectToAction("RecuperarSenha", "Publico");
            }
            if (String.IsNullOrEmpty(uid))
            {
                return RedirectToAction("RecuperarSenha", "Publico");
            }
            ViewBag.email = email;
            ViewBag.uid = uid;
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarSenha2(string email, string uid, string senha)
        {
            if ((System.Web.HttpContext.Current.Session["RecuperarSenha"] == null) || (System.Web.HttpContext.Current.Session["RecuperarSenha"].ToString() == ""))
            {
                return RedirectToAction("RecuperarSenha", "Publico");
            }
            if (String.IsNullOrEmpty(email))
            {
                return RedirectToAction("RecuperarSenha", "Publico");
            }
            if (String.IsNullOrEmpty(uid))
            {
                return RedirectToAction("RecuperarSenha", "Publico");
            }
            Context _db = new Context();
            var query = (from u in _db.Pessoas
                         where u.Email == email
                         select u).SingleOrDefault();
            query.Senha = senha;
            db.Entry(query).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.Error = "Senha Alterada!";
            System.Web.HttpContext.Current.Session["RecuperarSenha"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult Newsletter(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return View();
            }
            Newsletter newsletter = new Newsletter();
            newsletter.Email = email;
            db.Newsletters.Add(newsletter);
            db.SaveChanges();            
            ViewBag.Error = "Email cadastrado com sucesso!";
            return RedirectToAction("Logar");
        }
    }
}