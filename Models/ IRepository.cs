using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Models
{
    public interface IRepository
    {
        Task SaveNewFrame(Framework framework);
        IEnumerable<Framework> SearchFrame(string searchString);
        IEnumerable<Framework> GetAllFrameworksSorted();

    }
}