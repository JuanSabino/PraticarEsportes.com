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
        public int PessoaId { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<Checkin> Checkins { get; set; }
        public virtual ICollection<Historico> Historicos { get; set; }
        //eventos criados
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Evento> EventosConfirmados { get; set; }

        //pessoas que voce segue
        public virtual ICollection<Pessoa> Seguindo { get; set; }
        //eventos curtidos
        public virtual ICollection<Evento> EventosCurtidos { get; set; }
        //locais curtidos
        public virtual ICollection<Local> LocaisCurtidos { get; set; }

        public Pessoa()
        {
            Habilitado = true;
            //Eventos = new ICollection<Evento>();
        }
    }
}
