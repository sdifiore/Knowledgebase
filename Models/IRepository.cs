using Knowledgebase.Models;

using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Models
{
    public interface IRepository
    {
        Framework GetFrameById(int id);
        IEnumerable<Framework> GetAllFrameworksSorted();
        IEnumerable<Framework> SearchFrame(string searchString);
        void SaveNewFrame(Framework framework);
        void UpdateFrame(Framework framework);
    }
}