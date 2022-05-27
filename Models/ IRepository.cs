namespace KnowledgeBase.Models
{
    public interface IRepository
    {
        IEnumerable<Framework> GetAllFrameworksSorted();
        IEnumerable<Framework> SearchFrame(string searchString);

    }
}