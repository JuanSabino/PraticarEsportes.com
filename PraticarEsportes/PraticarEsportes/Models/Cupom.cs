using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Cupom
    {

        public int CupomId { get; set; }
        public double Valor { get; set; }
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }

    }
}