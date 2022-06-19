using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Knowledgebase.Models
{
    [Table("Erros")]
    public class Erro
    {
        public Erro()
        {
            Fontes = new HashSet<Fonte>();
        }
        
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string? Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(256)]
        public string? Codigo { get; set; } = string.Empty;

        public int FrameworkId { get; set; }

        public Framework Framework { get; set; }

        public ICollection<Fonte> Fontes { get; set; }
    }
}
