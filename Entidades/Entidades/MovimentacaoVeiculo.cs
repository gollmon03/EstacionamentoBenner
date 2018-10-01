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
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Hora Entrada")]
        public DateTime? DataHoraEntrada { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Hora Saida")]
        public DateTime? DataHoraSaida { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [RegularExpression(@"^[a-zA-Z]{3}\-\d{4}$" , ErrorMessage = "Placa invalida")]
        [Display(Name = "Placa do Veículo")]
        public string PlacaVeiculo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Tipo de Veiculo")]
        public int TipoVeiculoId { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }

        public decimal ValorTotal { get; set; }

        [Required]
        public bool Gerado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Mensalista")]
        public int? MensalistaId  { get; set; }
        public Mensalista Mensalista { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Vaga")]
        public int VagaId { get; set; }
        public Vaga Vaga { get; set; }
    }
}