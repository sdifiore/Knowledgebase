using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowledgeBase.Models

{
    [Table("Fontes")]
    public class Fonte
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        
        public ICollection<Autor>? Autores { get; set; }

        public Artigo? Artigo { get; set; }

        public Erro? Erro { get; set; }
    }
}
