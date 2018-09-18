using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    public class DocumentoFinanceiro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Pessoa")]
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Vencimento")]
        public DateTime DataVencimento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data do Processamento")]
        public DateTime DataProcessamento { get; set; }

        public string Tipo { get; set; }

        public string Status { get; set; }

        public string NumeroDocumento { get; set; }
    }
}