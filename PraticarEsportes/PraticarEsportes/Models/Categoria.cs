using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}