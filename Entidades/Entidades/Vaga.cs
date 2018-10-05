using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Estacionamento.Models.Enuns;

namespace Estacionamento.Models
{
    public class Vaga
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(0, 200, ErrorMessage = "Limite de Vagas é 200")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Situação")]
        public TipoSituacao Situacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Setor")]
        public int SetorId { get; set; }
        public Setor Setor { get; set; }

       

    }
}