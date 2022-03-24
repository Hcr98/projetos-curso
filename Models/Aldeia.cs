using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taba_Digital.Models
{
    public class Aldeia
    {
        [Key]
        [Required]
        public int Id_Aldeia {get; set;}
        [Required]
        public string Nome {get; set;}

        public string Responsavel {get; set;}
        
        public string localizacao {get; set;}

        public ICollection<Doacoes> doacoes {get; set;}

         public ICollection<Solicita> solicita {get; set;}
         
    }
}