using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticarEsportes.Models
{
    public class ViewModelPessoas
    {
        // Deixe PessoaId apenas se for fazer a edição da mesma forma.
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Preencha o telefone")]
        [DisplayName("Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o endereço")]
        [DisplayName("Endereço")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O endereço deve ter entre 3 e 255 caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Preencha o CEP")]
        [DisplayName("CEP")]
        [ValidaCEP]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Preencha a cidade")]
        [DisplayName("Cidade")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "A cidade deve ter entre 3 e 255 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o estado")]
        [DisplayName("Estado")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O estado deve ter entre 3 e 255 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Preencha o email")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O email deve ter entre 3 e 255 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]
        [DisplayName("Senha")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 3 e 50 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DisplayName("Habilitado")]
        public bool Habilitado { get; set; }

        /* Campos de Praticante */
        [Required(ErrorMessage = "Preencha o nome")]
        [DisplayName("Nome")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 255 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o CPF")]
        [DisplayName("CPF")]
        [ValidaCPF]
        public string CPF { get; set; }

        [DisplayName("Data de Nascimento")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de data inválido")]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha a profissão")]
        [DisplayName("Profissão")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "A profissão deve ter entre 3 e 255 caracteres.")]
        public string Profissao { get; set; }

        [Required(ErrorMessage = "Preencha o estado civil")]
        [DisplayName("Estado Civil")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O estado civil deve ter entre 3 e 255 caracteres.")]
        public string EstadoCivil { get; set; }

        [DisplayName("Pontos")]
        public int Pontos { get; set; }

        /* Campos de Estabelecimento */
        [Required(ErrorMessage = "Preencha o nome fantasia")]
        [DisplayName("Nome Fantasia")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome fantasia deve ter entre 3 e 255 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha a razão social")]
        [DisplayName("Razão Social")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "A razão social deve ter entre 3 e 255 caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o CNPJ")]
        [DisplayName("CNPJ")]
        [ValidaCNPJ]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Preencha o telefone comercial")]
        [DisplayName("Telefone Comercial")]
        [DataType(DataType.PhoneNumber)]
        public string TelComercial { get; set; }

        [DisplayName("Data de Abertura")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de data inválido")]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataAbertura { get; set; }
    }
}
