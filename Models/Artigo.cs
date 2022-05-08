using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowledgeBase.Models
{
    [Table("Artigos")]
    public class Artigo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string? Chamada { get; set; } = string.Empty;

        [Required]
        [StringLength(10240)]
        public string? Corpo { get; set; } = string.Empty;

        [Required]
        [StringLength(1040)]
        public HashSet<Autor>? Autores { get; set; }

        public DateTime DiaMesAno { get; set; }

        public HashSet<Fonte>? Fontes { get; set; }

        public HashSet<Framework>? Frameworks { get; set; }

        public HashSet<Plataforma>? Plataformas { get; set; }
    }
}
