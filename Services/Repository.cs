using Knowledgebase.Data;
using KnowledgeBase.Models;

using Microsoft.AspNetCore.Mvc;

namespace Knowledgebase.Services
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Framework> GetAllFrameworksSorted()
        {
            return _context.Frameworks
                .OrderBy(f => f.Apelido);
        }

        public void SaveNewFrame(Framework framework)
        {
            _context.Frameworks.Add(framework);
            _context.SaveChanges();
        }

        public IEnumerable<Framework> SearchFrame(string searchString)
        {
            return _context.Frameworks
                .Where(f => f.Descricao.Contains(searchString))
                .OrderBy(f => f.Apelido);
        }
    }
}
