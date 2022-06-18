using KnowledgeBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Knowledgebase.Models;

namespace Knowledgebase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artigo>? Artigos { get; set; }
        public DbSet<Erro>? Erros { get; set; }
        public DbSet<Fonte>? Fontes { get; set; }
        public DbSet<Framework>? Frameworks { get; set; }
        public DbSet<Plataforma>? Plataformas { get; set; }
    }
}
