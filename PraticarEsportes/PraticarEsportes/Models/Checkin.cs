using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Checkin
    {

        public int CheckinId { get; set; }
        public DateTime Data { get; set; }

        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

    }
}