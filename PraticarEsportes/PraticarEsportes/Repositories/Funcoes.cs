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
            HttpContext.Current.Session["Usuario"] = query.Email;
            HttpContext.Current.Session["Id"] = query.PessoaId;
            if (query.GetType().Name == "Estabelecimento")

            {
                HttpContext.Current.Session["Tipo"] = 1;
                HttpContext.Current.Session["Nome"] = ( (Estabelecimento) query).NomeFantasia;
            }
            else
            {
                HttpContext.Current.Session["Tipo"] = 2;
                HttpContext.Current.Session["Nome"] = ( (Praticante) query).Nome;
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

        public static void InsereHistorico(int PessoaId, string Descricao)
        {
            Context db = new Context();
            Historico historico = new Historico();
            historico.Horario = DateTime.Now;
            historico.PessoaId = PessoaId;
            historico.Descricao = Descricao;
            db.Historicos.Add(historico);
            db.SaveChanges();
        }




    }
}