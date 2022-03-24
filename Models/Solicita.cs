using System.ComponentModel.DataAnnotations;

namespace Taba_Digital.Models
{
    public class Solicita
    {
        [Key]
        [Required]
        public int Id_Solicita {get; set;}
        [Required]
        public string Descricao {get; set;}

         public int AldeiaId_Aldeia {get; set;}
        public virtual Aldeia aldeia {get; set;}

         public int NecessidadesId_necessidades {get; set;}
        public virtual Necessidades necessidades {get; set;}

        

    }
}