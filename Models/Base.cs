using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controleJornadas.Models
{
    [Table("Base")]
    [Index(nameof(Base.Sigla), IsUnique = true)]
    public class Base
    {
        private const string ErroPadrao = "O campo {0} é de preenchimento obrigatório";

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(100)]
        public required string Nome { get; set; }

        [MaxLength(200)]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = ErroPadrao)]
        [MaxLength(20)]
        public required string Sigla { get; set; }
    }
}