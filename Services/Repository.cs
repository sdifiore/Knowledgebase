using Knowledgebase.Data;
using Knowledgebase.Models;

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
            return _context.Framework
                .OrderBy(f => f.Apelido);
        }
        public Framework GetFrameById(int id)
        {
            return _context.Framework
                    .FirstOrDefault(f => f.Id == id);
        }

        public void SaveNewFrame(Framework framework)
        {
            _context.Framework.Add(framework);
            _context.SaveChanges();
        }

        public IEnumerable<Framework> SearchFrame(string searchString)
        {
            return _context.Framework
                .Where(f => f.Descricao.Contains(searchString))
                .OrderBy(f => f.Apelido);
        }

        public void UpdateFrame(Framework framework)
        {
            _context.Framework.Update(framework);
        }
    }
}