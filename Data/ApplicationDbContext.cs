using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Knowledgebase.Models;
using KnowledgeBase.Models;

namespace Knowledgebase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Plataforma>? Plataforma { get; set; }
        
        public DbSet<Framework>? Framework { get; set; }
        
        public DbSet<Erro>? Erro { get; set; }
    }
}
