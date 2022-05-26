using Knowledgebase.Data;
using KnowledgeBase.Models;

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
                .OrderBy(f => f.Apelido)
                .ToList();
        }
    }
}
