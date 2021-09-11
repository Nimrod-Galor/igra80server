using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Igra80.Models
{
    public class Incidence
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Msg { get; set; }
        [Required]
        public int CaId { get; set; }
    }
}
