using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Estacionamento.Models.Enuns;

namespace Estacionamento.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public TipoPessoa Tipo { get; set; }
      
        [MaxLength(11, ErrorMessage = "CPF deve conter no maximo 11 digitos")]
        [MinLength(11, ErrorMessage = "CPF deve conter no minimo 11 digitos")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
            
        [MaxLength(14, ErrorMessage = "CPF deve conter no maximo 14 digitos")]
        [MinLength(14, ErrorMessage = "CPF deve conter no minimo 14 digitos")]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        public virtual IList<Mensalista> Mensalistas { get; set; }
    }
}