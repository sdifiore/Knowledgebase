using KnowledgeBase.Models;

namespace KnowledgeBase.Services

public class Repository : IRepository
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
