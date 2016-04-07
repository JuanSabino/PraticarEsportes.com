using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Local
    {
        [Key]
        public int CidadeId { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public String Endereco { get; set; }
        public String CEP { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public bool Habilitado { get; set; }

    }
}