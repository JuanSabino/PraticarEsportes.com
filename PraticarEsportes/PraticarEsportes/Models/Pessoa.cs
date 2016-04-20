using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<Checkin> Checkins { get; set; }
    }
}
