using System.ComponentModel.DataAnnotations;

namespace Taba_Digital.Models
{
    public class Doacoes
    {
        [Key]
        [Required]
        public int Id_Doacoes {get; set;}
        [Required]
        public string Data_contribuicoes {get; set;}

        public int PessoaId_Pessoa {get; set;}
        public virtual Pessoa pessoa {get; set;}

        public int AldeiaId_Aldeia {get; set;}
        public virtual Aldeia aldeia {get; set;}

        public int EmpresaId_Empresa {get; set;}
        public virtual Empresa empresa {get; set;}

    }
}
