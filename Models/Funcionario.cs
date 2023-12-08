using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controleJornadas.Models
{
    [Table("Funcionario")]
    public class Funcionario
    {
        private const string ErroPadrao = "O campo {0} é de preenchimento obrigatóio";
        
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(200)]
        public required string Nome { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(400)]
        public string? Cargo { get; set; }

        [Display(Name = "Data de Admissão")]
        [Required(ErrorMessage = ErroPadrao)]
        public required DateTime DataAdmissao { get; set; }

        [Display(Name = "Chave Pix")]
        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(200)]
        public required string CodPix { get; set; }

        public int BaseId { get; set; }

        [Display(Name = "Filial")]
        public Base? Base { get; set; }

        public List<Jornada>? Jornada { get; set; }
    }
}
