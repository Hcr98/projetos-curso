using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taba_Digital.Models
{
    public class Necessidades
    {
        [Key]
        [Required]
        public int Id_Necessidades {get; set;}

        [Required]
        public string Tipo {get; set;}

        public ICollection<Solicita> solicita {get; set;}

    }
}