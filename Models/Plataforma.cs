using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowledgeBase.Models
{
    [Table("Plataformas")]
    public class Plataforma
    {
        public int Id { get; set; }

        [Required]
        [StringLength(4)]
        public string? Apelido { get; set; } = string.Empty;

        [Required]
        [StringLength(64)]
        public string? Descricao { get; set; } = string.Empty;

        [Required]
        [StringLength(16)]
        public string? Versao { get; set; } = string.Empty;

        public int FrameworkId { get; set; }

        public Framework? Framework { get; set; }
    }
}
