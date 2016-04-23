using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class Pessoa
    {
        [Key]
        public int PessoaId { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        [Required(ErrorMessage = "Preencha o e-mail")]
        [DisplayName("E-mail")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "o e-mail deve ter entre 3 e 50 caracteres.")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]
        [DisplayName("Senha")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 3 e 50 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DefaultValue(true)]
        public bool Habilitado { get; set; }

        public virtual ICollection<Checkin> Checkins { get; set; }


        public Pessoa()
        {
            Habilitado = true;
        }
    }
}
