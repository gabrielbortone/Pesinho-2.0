using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pesinho_2._0.Models
{
    public class Peso
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataPesagem { get; set; }
        [Required]
        public double Pesagem { get; set; }
        public Usuario Usuario { get; set; }
    }
}
