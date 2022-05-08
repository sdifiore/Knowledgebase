using Knowledge.Models;
using Knowledgebase.Data;

namespace Knowledgebase.Services
{
    public class Repository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Framework> GetFrameworks()
        {
            return _context.Frameworks;
        }
    }
}
