using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Local
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Preencha o nome do local")]
        [DisplayName("Nome da Local")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Latitude")]
        public double Latitude { get; set; }

        [DisplayName("Longitude")]
        public double Longitude { get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [DisplayName("CEP")]
        public string CEP { get; set; }

        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [DisplayName("Estado")]
        public string Estado { get; set; }

        [DisplayName("Habilitado")]
        public Boolean Habilitado { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}