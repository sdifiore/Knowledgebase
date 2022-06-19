using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Knowledgebase.Models
{
    [Table("Autores")]
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public int ArtigoId { get; set; }

        public Artigo Artigo { get; set; }
    }
}
