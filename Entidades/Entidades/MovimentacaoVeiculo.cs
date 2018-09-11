using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    public class MovimentacaoVeiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Hora Entrada")]
        public DateTime DataHoraEntrada { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Hora Saida")]
        public DateTime? DataHoraSaida { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [RegularExpression(@"^[a-zA-Z]{3}\-\d{4}$" , ErrorMessage = "Placa invalida")]
        [Display(Name = "Placa do Veículo")]
        public string PlacaVeiculo { get; set; }

        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Modelo do Veículo")]
        public int ModeloVeiculoId { get; set; }
        public ModeloVeiculo ModeloVeiculo { get; set; } 

        [Display(Name = "Mensalista")]
        public int? MensalistaId  { get; set; }
        public Mensalista Mensalista { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Vaga")]
        public int VagaId { get; set; }
        public Vaga Vaga { get; set; }

        

    }
}