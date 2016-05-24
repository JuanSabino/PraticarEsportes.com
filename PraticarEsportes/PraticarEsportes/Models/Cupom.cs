using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Cupom
    {
        [Key]
        public int CupomId { get; set; }

        [Required(ErrorMessage = "Digite o valor do cupom")]
        [DisplayName("Valor")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Digite o tipo de cupom")]
        [DisplayName("Tipo")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de cupons")]
        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Escolha a validade do cupom")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Validade")]
        public DateTime Validade { get; set; }

        [Required(ErrorMessage = "Escolha um evento para o cupom")]
        [DisplayName("Evento")]
        public int EventoID { get; set; }
        public virtual Evento Evento { get; set; }

    }
}