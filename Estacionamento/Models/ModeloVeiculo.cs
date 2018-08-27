using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    public class ModeloVeiculo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60)]
        public string Marca  { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Tipo de Veiculos")]
        public int TipoVeiculoId { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }

        public IList<Cliente> Clientes { get; set; }

    }
}