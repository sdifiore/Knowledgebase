using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Knowledgebase.Models
{
    [Table("Artigos")]
    public class Artigo
    {

        public Artigo()
        {
            Autores = new HashSet<Autor>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string? Chamada { get; set; } = string.Empty;

        [Required]
        [StringLength(10240)]
        public string? Corpo { get; set; } = string.Empty;

        public int FonteId { get; set; }

        public Fonte Fonte { get; set; }

        private ICollection<Autor> Autores { get; set; }
    }
}
