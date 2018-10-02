using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Entidades.Entidades.Enuns;
using Estacionamento.Models;

namespace Estacionamento.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60)]
        public string Nome { get; set; }

        //[Index(IsUnique = true)]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(11, ErrorMessage = "CPF deve conter no maximo 11 digitos")]
        [MinLength(11, ErrorMessage = "CPF deve conter no minimo 11 digitos")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(15, ErrorMessage = "Deve conter no maximo 15 digitos")]
        [MinLength(6, ErrorMessage = "Deve conter no minimo 6 digitos")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        public TipoUsuario Papel { get; set; }

        public virtual IList<MovimentacaoVeiculo> MovimentacaoVeiculos { get; set; }

    }


}