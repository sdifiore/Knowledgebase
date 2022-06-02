using Knowledgebase.Data;

using KnowledgeBase.Models;

namespace Knowledgebase.Services
{
    public class RepositoryBase
    {
        private readonly ApplicationDbContext _context;

        public IEnumerable<Framework> GetAllFrameworksSorted()
        {
            return _context.Frameworks
                .OrderBy(f => f.Apelido);
        }

        public async Task SaveNewFrame(Framework framework)
        {
            _context.Frameworks.Add(framework);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Framework> SearchFrame(string searchString)
        {
            return _context.Frameworks
                .Where(f => f.Descricao.Contains(searchString))
                .OrderBy(f => f.Apelido);
        }
    }
}