using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    public class Vaga
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(0 , 200 , ErrorMessage = "Limite de Vagas é 200")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Situacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Setor")]
        public int SetorId { get; set; }
        public Setor setor { get; set; }
    }
}