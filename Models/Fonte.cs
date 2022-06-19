using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Knowledgebase.Models
{
    [Table("Fontes")]
    public class Fonte
    {
        public Fonte()
        {
            Erros = 
        }
        
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public int ErroId { get; set; }

        public ICollection<Erro> Erros { get; set; }
    }
}
