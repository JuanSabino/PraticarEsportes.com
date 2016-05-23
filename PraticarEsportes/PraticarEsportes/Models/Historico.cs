using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Historico
    {
        public int HistoricoId { get; set; }
        [DisplayName("Horário")]
        public DateTime Horario { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }


        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}