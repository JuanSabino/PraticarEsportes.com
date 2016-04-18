using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Estabelecimento : Pessoa
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string TelComercial { get; set; }
        public DateTime DataAbertura { get; set; }

    }
}