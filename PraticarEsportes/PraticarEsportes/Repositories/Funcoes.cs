using PraticarEsportes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace PraticarEsportes.Repositories
{
    public class Funcoes
    {
        public static bool AutenticarUsuario(string login, string senha, bool facebook = false)
        {
            Context _db = new Context();
            if (facebook)
            {
                var query = (from u in _db.Pessoas
                             where u.Email == login 
                             select u).SingleOrDefault();
                if (query == null)
                {
                    return false;
                }
                if (query.Habilitado == false)
                {
                    return false;
                }
                System.Web.Security.FormsAuthentication.SetAuthCookie(query.Email, false);
                HttpContext.Current.Session["Usuario"] = query.Email;
                HttpContext.Current.Session["Id"] = query.PessoaId;
                if (query.GetType().Name == "Estabelecimento")
                {
                    HttpContext.Current.Session["Tipo"] = 1;
                    HttpContext.Current.Session["Nome"] = ((Estabelecimento)query).NomeFantasia;
                }
                else
                {
                    HttpContext.Current.Session["Tipo"] = 2;
                    HttpContext.Current.Session["Nome"] = ((Praticante)query).Nome;
                }
            }
            else
            {
                var query = (from u in _db.Pessoas
                             where u.Email == login &&
                             u.Senha == senha
                             select u).SingleOrDefault();
                if (query == null)
                {
                    return false;
                }
                if (query.Habilitado == false)
                {
                    return false;
                }
                System.Web.Security.FormsAuthentication.SetAuthCookie(query.Email, false);
                HttpContext.Current.Session["Usuario"] = query.Email;
                HttpContext.Current.Session["Id"] = query.PessoaId;
                if (query.GetType().Name == "Estabelecimento")
                {
                    HttpContext.Current.Session["Tipo"] = 1;
                    HttpContext.Current.Session["Nome"] = ((Estabelecimento)query).NomeFantasia;
                }
                else
                {
                    HttpContext.Current.Session["Tipo"] = 2;
                    HttpContext.Current.Session["Nome"] = ((Praticante)query).Nome;
                }
            }
            
           
            
            return true;
        }

        public static Object GetUsuario()
        {
            string _login = HttpContext.Current.User.Identity.Name;
            int _tipo;
            if (HttpContext.Current.Session.Count > 0 && HttpContext.Current.Session["Usuario"] != "")
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
            HttpContext.Current.Session["Nome"] = "";
            HttpContext.Current.Session["Id"] = "";
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

        //criptografia
        public static string Hash(string Valor)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, Valor);                

                return hash;
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static bool ValidaCep(string cep)
        {
            if (cep.Length == 8)
            {
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
                //txt.Text = cep;
            }
            return System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"));
        }

        public static bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");
            if (valor.Length != 11) return false;
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0]) igual = false;
            if (igual || valor == "12345678909")
                return false;
            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++) numeros[i] = int.Parse(valor[i].ToString());
            int soma = 0;
            for (int i = 0; i < 9; i++) soma += (10 - i) * numeros[i];
            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false; soma = 0;
            for (int i = 0; i < 10; i++) soma += (11 - i) * numeros[i];
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0) return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;
            return true;
        }

        public static bool ValidaCNPJ(string vrCNPJ)
        {
            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");
            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;
            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2]; soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;
            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11) soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));
                    if (nrDig <= 12) soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }
                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1)) CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }


    }
}