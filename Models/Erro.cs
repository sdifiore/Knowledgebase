using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowledgeBase.Models
{
    [Table("Erros")]
    public class Erro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string? Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(256)]
        public string? Codigo { get; set; } = string.Empty;

        [StringLength(64)]
        public string? Fonte { get; set; } = string.Empty;

        public List<Autor>? Autores { get; set; }

        public HashSet<Fonte>? Fontes { get; set; }

        public HashSet<Plataforma>? Plataformas { get; set; }
    }
}
