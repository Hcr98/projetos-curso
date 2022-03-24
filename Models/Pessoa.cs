using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taba_Digital.Models
{
    public class Pessoa
    {
        [Key]
        [Required]
        public int Id_Pessoa {get; set;}
        [Required]
        public string Nome {get; set;}

        public string Email {get; set;}
        
        public string CPF {get; set;}

        public ICollection<Doacoes> doacoes {get; set;}
    }
}