using PraticarEsportes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PraticarEsportes.Repositories
{
    public class Funcoes
    {
        public static bool AutenticarUsuario(string login, string senha)
        {
            Context _db = new Context();
            var query = (from u in _db.Pessoas
                         where u.Email == login &&
                         u.Senha == senha
                         select u).SingleOrDefault();
            if (query == null)
            {
                return false;
            }
            System.Web.Security.FormsAuthentication.SetAuthCookie(query.Email, false);
            //HttpContext.Current.Response.Cookies["Usuario"].Value = query.Email;
            //HttpContext.Current.Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(10);
            HttpContext.Current.Session["Usuario"] = query.Email;
            return true;
        }

        public static Pessoa GetUsuario()
        {
            string _login = HttpContext.Current.User.Identity.Name;
            if (HttpContext.Current.Session.Count > 0 || HttpContext.Current.Session["Usuario"] != null)
            {
                _login = HttpContext.Current.Session["Usuario"].ToString();
                //_login = HttpContext.Current.Request.Cookies["Usuario"].Value.ToString();
                if (_login == "")
                {
                    return null;
                }
                else
                {
                    Context _db = new Context();
                    Pessoa cliente = (from u in _db.Pessoas
                                       where u.Email == _login
                                       select u).SingleOrDefault();
                    return cliente;
                }
            }
            else
            {
                return null;
            }
        }

        public static Pessoa GetUsuario(string _login)
        {
            if (_login == "")
            {
                return null;
            }
            else
            {
                Context _db = new Context();
                Pessoa cliente = (from u in _db.Pessoas
                                   where u.Email == _login
                                   select u).SingleOrDefault();
                return cliente;
            }
        }


        public static void Deslogar()
        {
            HttpContext.Current.Session["Usuario"] = "";
            HttpContext.Current.Session["Tipo"] = "";
            //HttpContext.Current.Response.Cookies["Usuario"].Value = "";
            FormsAuthentication.SignOut();
        }


    }
}