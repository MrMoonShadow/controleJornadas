using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controleJornadas.Models
{
    [Table("Jornada")]
    public class Jornada
    {
        private const string ErroPadrao = "O campo {0} é de preenchimento obrigatóio";

        [Key]
        public required int Id { get; set; }

        [Required(ErrorMessage = ErroPadrao)]
        [Display(Name = "Data inicio da Jornada")]
        public required DateTime HrInicio { get; set; }

        [Required(ErrorMessage = ErroPadrao)]
        [Display(Name = "Data inicio da Jornada")]
        public required DateTime HrFim { get; set; }

        [Required(ErrorMessage = ErroPadrao)]
        [Display(Name = "Turno")]
        public required string Turno { get; set; }

        [Display(Name = "Valor R$")]
        [Required(ErrorMessage = ErroPadrao)]
        public required decimal Valor { get; set; }

        [Display(Name = "Funcionario")]
        public int FuncionarioId { get; set; }

        [Display(Name = "Funcionario")]
        public Funcionario? Funcionario { get; set; }
    }
}
