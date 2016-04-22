using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Evento
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Preencha o nome do evento")]
        [DisplayName("Evento")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Preencha a data de incío do evento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Data Início")]
        public DateTime DataInicio { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Preencha a data de término do evento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Data Término")]
        public DateTime DataTermino { get; set; }

        [Required(ErrorMessage = "Preencha a capacidade")]
        [DisplayName("Capacidade")]
        public string Capacidade { get; set; }

        [Required(ErrorMessage = "Escolha uma dificuldade para o evento")]
        [DisplayName("Dificuldade")]
        public int Dificuldade { get; set; }

        public int LocalID { get; set; }
        public virtual Local Local { get; set; }

        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}