using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pesinho_2._0.Models.ViewsModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Sobrenome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public double Altura { get; set; }

    }
}
