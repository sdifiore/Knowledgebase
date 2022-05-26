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

        public IEnumerable<Framework> GetAllFrameworks()
        {
            return _context.Frameworks.ToList();
        }
    }
}
