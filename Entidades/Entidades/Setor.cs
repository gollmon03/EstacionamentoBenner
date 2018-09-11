using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Estacionamento.Models.Enuns;

namespace Estacionamento.Models
{
    public class Setor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60)]
        public string Nome { get; set; }

        //[Index(IsUnique = true)]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(2, ErrorMessage = "A Sigla deve conter apenas 2 caracteres")]
        [MinLength(2, ErrorMessage = "A Sigla deve conter apenas 2 caracteres")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Situação")]
        public TipoSituacao Situacao { get; set; }

        public ICollection<Vaga> vagas { get; set; }
    }
}