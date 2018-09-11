using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    public class TabelaPreco
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal ValorHora { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Setor")]
        //[Index(IsUnique = true )]
        public int TipoVeiculoId { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }

        
    }
}