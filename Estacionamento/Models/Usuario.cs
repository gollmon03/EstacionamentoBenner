using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Estacionamento.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [MaxLength (11)]
        [MinLength (11)]
        
        public string Cpf { get; set; }
    }


}