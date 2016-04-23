using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Praticante:Pessoa
    {
        [Required(ErrorMessage = "Preencha o nome")]
        [DisplayName("Nome")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 255 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o CPF")]
        [DisplayName("CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "o CPF deve ter 11 numeros.")]
        public string CPF { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Preencha a data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Data de Nascimento:")]
        public DateTime DataNascimento { get; set; }


        public string Profissao { get; set; }

        [DefaultValue("Solteiro")]
        public string EstadoCivil { get; set; }

        [DefaultValue(0)]
        public int Pontos { get; set; }
    }
}