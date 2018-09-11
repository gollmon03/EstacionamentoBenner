using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    public class Mensalista
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [RegularExpression(@"^[a-zA-Z]{3}\-\d{4}$", ErrorMessage = "Placa invalida")]
        [Display(Name = "Placa do Veículo")]
        public string PlacaVeiculo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public decimal ValorMensal { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Pessoa")]
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Modelo do Veículo")]
        public int ModeloVeiculoId { get; set; }
        public ModeloVeiculo ModeloVeiculo { get; set; }

    }
}