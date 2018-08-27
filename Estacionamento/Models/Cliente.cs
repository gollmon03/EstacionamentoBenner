using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Index(IsUnique = true)]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(11, ErrorMessage = "CPF deve conter no maximo 11 digitos")]
        [MinLength(11, ErrorMessage = "CPF deve conter no minimo 11 digitos")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Modelo do Veículo")]
        public int ModeloVeiculoId { get; set; }
        
        public ModeloVeiculo ModeloVeiculo { get; set; }
    }
}