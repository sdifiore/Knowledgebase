using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Knowledgebase.Models
{
    [Table("Fontes")]
    public class Fonte
    {

        public Fonte()
        {
            Artigos = new HashSet<Artigo>();
        }
        
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public int ErroId { get; set; }

        public Erro Erro { get; set; }

        public ICollection<Artigo> Artigos { get; set; }
    }
}
