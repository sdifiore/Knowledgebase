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

        public Framework GetFrameById(int id)
        {
            return _context.Frameworks
                .FirstOrDefault(f => f.Id == id);
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