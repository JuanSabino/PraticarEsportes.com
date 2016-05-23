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
        /* Campos de Pessoa */
        // Deixe PessoaId apenas se for fazer a edição da mesma forma.
        public int PessoaId { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o endereço")]
        [DisplayName("Endereço")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O endereço deve ter entre 3 e 255 caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Preencha o CEP")]
        [ValidaCEP]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Preencha a cidade")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "A cidade deve ter entre 3 e 255 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o estado")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve ter 2 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Preencha o e-mail")]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O e-mail deve ter entre 3 e 255 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 3 e 30 caracteres.")]
        public string Senha { get; set; }

        [DisplayName("Confirmar senha")]
        [Required(ErrorMessage = "Preencha o confirmar senha")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 3 e 30 caracteres.")]
        public string ConfirmarSenha { get; set; }

        [DefaultValue(true)]
        public bool Habilitado { get; set; }

        /* Campos de Praticante */
        [Required(ErrorMessage = "Preencha o nome")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 255 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o CPF")]
        //[StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 números.")]
        [ValidaCPF]
        public string CPF { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Profissão")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "A profissão deve ter entre 3 e 255 caracteres.")]
        public string Profissao { get; set; }

        [DisplayName("Estado Civil")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "O estado civil deve ter entre 3 e 15 caracteres.")]
        [DefaultValue("Solteiro")]
        public string EstadoCivil { get; set; }

        [DefaultValue(0)]
        public int Pontos { get; set; }

        /* Campos de Estabelecimento */
        [DisplayName("Nome Fantasia")]
        [Required(ErrorMessage = "Preencha o nome fantasia")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome fantasia deve ter entre 3 e 255 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha a razão social")]
        [DisplayName("Razão Social")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "A razão social deve ter entre 3 e 255 caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o CNPJ")]
        [ValidaCNPJ]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Preencha o telefone comercial")]
        [DisplayName("Telefone Comercial")]
        [DataType(DataType.PhoneNumber)]
        public string TelComercial { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Data de abertura do estabelecimento")]
        public DateTime DataAbertura { get; set; }
    }
}
