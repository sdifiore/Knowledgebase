using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Knowledgebase.Models
{   
    [Table("Frameworks")]
    public class Framework
    {
        public Framework()
        {
            Erros = new HashSet<Erro>();
        }
        
        [Key]
        public int Id { get; set; }

        public int Plataforma { get; set; }

        [StringLength(6)]
        public string Apelido { get; set; } = null!;

        [StringLength(64)]
        public string Descricao { get; set; } = null!;

        [StringLength(10)]
        public string? Versao { get; set; }

        private string showItem;

        public string ShowItem
        {
            get { return Descricao + " vs. " + Versao; }
        }

        [ForeignKey(nameof(Plataforma))]
        [InverseProperty("Frameworks")]
        public virtual Plataforma PlataformaNavigation { get; set; } = null!;

        public ICollection<Erro> Erros { get; set; }
    }
}
