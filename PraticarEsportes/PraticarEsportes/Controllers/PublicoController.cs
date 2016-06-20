using Facebook;
using PraticarEsportes.Models;
using PraticarEsportes.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Dynamic;
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
            ViewBag.Title = "Praticar Esportes";
            ViewBag.UrlFb = GetFacebookLoginUrl();
            try
            {
                ViewBag.Categoria = db.Categoria.ToList();
            }
            catch(Exception e)
            {
                ViewBag.Categoria = new List<Categoria>();
            }            
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
            var context = HttpContext;
            var appPath = string.Format("{0}://{1}{2}",
                                    context.Request.Url.Scheme,
                                    context.Request.Url.Host,
                                    context.Request.Url.Port == 80
                                        ? string.Empty
                                        : ":" + context.Request.Url.Port);

            GmailEmailService gmail = new GmailEmailService();
            EmailMessage msg = new EmailMessage();
            msg.Body = "<HTML><BODY>Caro Usuario<br />";
            msg.Body += "Para voltar a acessar a sua conta do Praticar Esportes, você precisa criar uma nova senha. <br />";
            msg.Body += "É fácil:<br />";
            msg.Body += "<br />Clique no link abaixo ou copie e cole na barra de enderecos do seu navegador:<br />";
            msg.Body += "<a href='" + appPath  + "/Publico/RecuperarSenha2?email=" + query.Email +  "&uid=" + hash + "'>" + appPath + "/Publico/RecuperarSenha2?email=" + query.Email + "&uid=" + hash + "</a>";
            msg.isHtml = true;
            msg.Subject = "Recuperacao de senha";
            msg.ToEmail = query.Email;
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

        public ActionResult Politica()
        {
            return View();
        }

        public ActionResult RetornoFb()
        {
            var _fb = new FacebookClient();
            FacebookOAuthResult oauthResult;

            _fb.TryParseOAuthCallbackUrl(Request.Url, out oauthResult);

            if (oauthResult.IsSuccess)
            {
                var context = HttpContext;
                var appPath = string.Format("{0}://{1}{2}",
                                        context.Request.Url.Scheme,
                                        context.Request.Url.Host,
                                        context.Request.Url.Port == 80
                                            ? string.Empty
                                            : ":" + context.Request.Url.Port);

                //Pega o Access Token "permanente"
                dynamic parameters = new ExpandoObject();
                parameters.client_id = "1728002444152079";
                parameters.redirect_uri = appPath + "/publico/retornofb";
                parameters.client_secret = "9a5728d23d39d3c9f45e53682d07526a";
                parameters.code = oauthResult.Code;

                dynamic result = _fb.Get("/oauth/access_token", parameters);
                

                var accessToken = result.access_token;

                //TODO: Guardar no banco
                Session.Add("FbUserToken", accessToken);


                _fb = new FacebookClient(Session["FbuserToken"].ToString());
                dynamic request = _fb.Get("me?fields=name,email");
                string email = request.email;

                //busca o email no banco
                Context _db = new Context();
                var query = (from u in _db.Pessoas
                             where u.Email == email
                             select u).SingleOrDefault();
                //se nao existe, cadastra com as informacoes basicas
                if (query == null)
                {
                    Praticante praticante = new Praticante();
                    praticante.Nome = request.name;
                    praticante.Email = request.email;
                    praticante.Habilitado = true;
                    db.Pessoas.Add(praticante);
                    db.SaveChanges();
                }               

                //puxa as informacoes do banco
                if (Funcoes.AutenticarUsuario(email, "", true) == true)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Logar");
            }

            return RedirectToAction("Logar");
        }

        public string GetFacebookLoginUrl()
        {
            dynamic parameters = new ExpandoObject();
            parameters.client_id = "1728002444152079";
            var context = HttpContext;
            var appPath = string.Format("{0}://{1}{2}",
                                    context.Request.Url.Scheme,
                                    context.Request.Url.Host,
                                    context.Request.Url.Port == 80
                                        ? string.Empty
                                        : ":" + context.Request.Url.Port);

            parameters.redirect_uri = appPath + "/publico/retornofb";
            parameters.response_type = "code";
            parameters.display = "page";

            var extendedPermissions = "public_profile,email";
            parameters.scope = extendedPermissions;

            var _fb = new FacebookClient();
            var url = _fb.GetLoginUrl(parameters);

            return url.ToString();
        }
    }
}