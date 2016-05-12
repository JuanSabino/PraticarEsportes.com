using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Estabelecimento : Pessoa
    {
        [Required(ErrorMessage = "Preencha o nome fantasia")]
        [DisplayName("Nome Fantasia")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome fantasia deve ter entre 3 e 255 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha a razao social")]
        [DisplayName("Razão Social")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "a razao social deve ter entre 3 e 255 caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o CNPJ")]
        [DisplayName("CNPJ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "o CNPJ deve ter entre 3 e 50 caracteres.")]
        public string CNPJ { get; set; }
        public string TelComercial { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Preencha a data de abertura do estabelecmento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Data de Abertura")]
        public DateTime DataAbertura { get; set; }

    }
}