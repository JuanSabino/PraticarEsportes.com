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
            if (query.GetType().Name == "Estabelecimento")

            {
                HttpContext.Current.Session["Tipo"] = 1;
            }
            else
            {
                HttpContext.Current.Session["Tipo"] = 2;
            }
            
            return true;
        }

        public static Object GetUsuario()
        {
            string _login = HttpContext.Current.User.Identity.Name;
            int _tipo;
            if (HttpContext.Current.Session.Count > 0 || HttpContext.Current.Session["Usuario"] != null)
            {
                _login = HttpContext.Current.Session["Usuario"].ToString();
                if (_login == "")
                {
                    return null;
                }
                else
                {
                    _tipo = Convert.ToInt32(HttpContext.Current.Session["Tipo"].ToString());
                    Context _db = new Context();
                    Object retorno;
                    if (_tipo == 2)
                    {
                        Praticante cliente = (Praticante) (from u in _db.Pessoas
                                              where u.Email == _login
                                              select u).SingleOrDefault();
                        retorno = cliente;
                    }
                    else
                    {
                        Estabelecimento cliente =(Estabelecimento) (from u in _db.Pessoas
                                                   where u.Email == _login
                                                   select u).SingleOrDefault();
                        retorno = cliente;
                    }               
                    return retorno;
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