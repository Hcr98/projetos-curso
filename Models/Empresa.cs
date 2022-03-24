using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taba_Digital.Models
{
    public class Empresa
    {
        [Key]
        [Required]
        public int Id_Empresa {get; set;}
        [Required]
        public string Nome {get; set;}

        public string Email {get; set;}
        
        public string CNPJ {get; set;}

        public ICollection<Doacoes> doacoes {get; set;}
    }
}