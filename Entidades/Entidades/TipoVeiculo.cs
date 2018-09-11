using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    public class TipoVeiculo
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Campo Obrigatório")]
        [MaxLength(60 , ErrorMessage = "Deve conter no maximo 60 digitos")]
        public string Nome { get; set; }

       
        public virtual IList<TabelaPreco> TabelasPreco { get; set; }
        public virtual IList<ModeloVeiculo> ModelosVeiculo { get; set; }
        public virtual IList<Pessoa> Pessoas { get; set; }
        
    }
}