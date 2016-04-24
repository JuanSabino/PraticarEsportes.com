using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Historico
    {
        public int HistoricoId { get; set; }        
        public DateTime Horario { get; set; }
        public string Descricao { get; set; }


        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}